using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapp2.Models
{
    public class AbsoluteDbContext : DbContext
    {
        public AbsoluteDbContext(DbContextOptions<AbsoluteDbContext> options) : base(options)
        {}
        public DbSet<StoreS3Detail> storeS3Details { get; set; }

    }
}
