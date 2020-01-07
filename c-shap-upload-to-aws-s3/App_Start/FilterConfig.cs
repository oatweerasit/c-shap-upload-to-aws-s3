using System.Web;
using System.Web.Mvc;

namespace c_shap_upload_to_aws_s3
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
