using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using webapp2.Helpers;
using webapp2.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webapp2.Authentication
{
    [Route("api")]
    [ApiController]
    
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;

        public AuthenticateController(UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
        }
       
        // Login controller
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login ([FromBody] Login model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user !=null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidateIssuer"],
                    audience: _configuration["JWT:ValidateAudience"],
                    expires: DateTime.Now.AddDays(1),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );
                return StatusCode(
                    StatusCodes.Status200OK, 
                    new { 
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo 
                    });
            }
            return StatusCode(StatusCodes.Status403Forbidden, new Response { Status = "Failed", Message = "User unauthorized" });
        }

        // POST api/<AuthenticateController>
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register ([FromBody] Register model)
        {
            var userExists = await userManager.FindByEmailAsync(model.Email);
            if (userExists != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already existes" });
            }

            ApplicationUser user = new ApplicationUser()
            {
                UserName=model.Email,
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status= "Error", Message = "User creation failed" });
            }

            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await roleManager.RoleExistsAsync(UserRoles.User))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.User));
            if (!await roleManager.RoleExistsAsync(UserRoles.Company))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Company));

            switch (model.UserType)
            {
                case 0:
                    await userManager.AddToRoleAsync(user, UserRoles.User);
                    break;
                case 1:
                    await userManager.AddToRoleAsync(user, UserRoles.Company);
                    break;
                default:
                    return StatusCode(StatusCodes.Status206PartialContent, new Response { Status = "Error", Message = "Cannot find the defined user type" });
            }

            // generate confirm email
            var token = await userManager.GenerateEmailConfirmationTokenAsync(user);

            // generate the url
            var confirmatinLink = Url.Action("ConfirmEmail", "Email", new { token, email = user.Email }, Request.Scheme);
            MailTrapEmailGenerator emailhelper = new MailTrapEmailGenerator();

            //Generate email attributes
            MailTrapSendMail mailBody = new MailTrapSendMail();
            mailBody.To = model.Email;
            mailBody.Header = "Confirm Email address";
            mailBody.Body = confirmatinLink;

            //send the email
            var emailResponse = emailhelper.MailGenerator(mailBody);
;
            return StatusCode(StatusCodes.Status201Created, new Response { Status = "Success", Message = "User Creation successful" });
        }

        // PUT api/<AuthenticateController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AuthenticateController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
