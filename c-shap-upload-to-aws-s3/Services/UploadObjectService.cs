using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Amazon.S3;
using Amazon.S3.Model;
using c_shap_upload_to_aws_s3.Models;

namespace c_shap_upload_to_aws_s3.Services
{
    public  class UploadObjectService
    {
        private static String accessKey = "-";
        private static String accessSecret = "-";
        private static String bucket = "-";

        public  UploadPhotoModel UploadObject(HttpPostedFileBase file)
        {
            var client = new AmazonS3Client(accessKey, accessSecret, Amazon.RegionEndpoint.APSoutheast1);
            MemoryStream target = new MemoryStream();
            file.InputStream.CopyTo(target);
            byte[] fileBytes = target.ToArray();
            string s3FileName = Path.GetFileName(file.FileName);
            string folderPath = @"images/sub-folder/";
            string fileName = folderPath + Guid.NewGuid() + s3FileName;

            PutObjectResponse response = null;

            using (var stream = new MemoryStream(fileBytes))
            {
                var request = new PutObjectRequest
                {
                    BucketName = bucket,
                    Key = fileName,
                    InputStream = stream,
                    ContentType = file.ContentType
                    //CannedACL = S3CannedACL.PublicRead
                };

                response = client.PutObject(request);
            };

            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                return new UploadPhotoModel
                {
                    Success = true,
                    FileName = fileName
                };
            }
            else
            {
                return new UploadPhotoModel
                {
                    Success = false,
                    FileName = fileName
                };
            }
        }
    }
}