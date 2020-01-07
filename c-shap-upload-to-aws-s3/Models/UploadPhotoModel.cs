using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace c_shap_upload_to_aws_s3.Models
{
    public class UploadPhotoModel
    {
        public bool Success { get; set; }
        public string FileName { get; set; }
    }
}