using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using webapp2.Models;

namespace webapp2.Helpers
{
    public class S3Upload
    {
        private static IAmazonS3 s3Client;

        public S3Upload(IAmazonS3 S3Client)
        {
            s3Client = S3Client;
        }
        

        public static async Task<bool> UploadFileAsync(Stream FileStream, string keyName)
                        
        {
            var request = new PutObjectRequest
            {
                InputStream = FileStream,
                BucketName = "Test",
                Key = keyName,
                CannedACL = S3CannedACL.PublicRead

            };

            try
            {

                PutObjectResponse response = await s3Client.PutObjectAsync(request);

                if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
                    return true;

                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;


            }
        }
    }
}
