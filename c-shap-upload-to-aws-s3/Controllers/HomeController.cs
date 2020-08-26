using Amazon.S3;
using Amazon.S3.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using c_shap_upload_to_aws_s3.Services;


namespace c_shap_upload_to_aws_s3.Controllers
{
    public class HomeController : Controller
    {
        UploadObjectService uploadService = new UploadObjectService();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            try
            {
                if (file != null)
                {
                    var response = uploadService.UploadObject(file);
                }
            }
            catch (Exception e)
            {

                throw;
            }

            return RedirectToAction("Index");

        }
    }
}