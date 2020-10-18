using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Localization
{
    public class language
    {
        private string prmLang = "EN";
        public language(IHttpContextAccessor context,HttpContext httpContext=null)
        {
            if (context!=null)
            {
                if (context.HttpContext.Request.Headers["X-Language"].ToString() != "")
                {
                    prmLang = context.HttpContext.Request.Headers["X-Language"].ToString();
                }
            }
            else
            {
                if (httpContext.Request.Headers["X-Language"].ToString() != "")
                {
                    prmLang = httpContext.Request.Headers["X-Language"].ToString();
                }
            }
        }
        private Dictionary<string, string> langDic
        {
            get
            {
                return new Dictionary<string, string>()
                {
                    { "EN_1001", "Your access is denied." },
                    { "TR_1001", "Erişiminiz engellendi." },
                    { "EN_1002", "User-agent information could not be found." },
                    { "TR_1002", "User-agent bilgisine ulaşılamadı." },
                    { "EN_1003", "No such product is in stock." },
                    { "TR_1003", "Böyle bir ürün stokta bulunamadı." },
                    { "EN_1004", "The product has run out." },
                    { "TR_1004", "Ürün tükendi." },
                    { "EN_1005", "Stock of this product is not available for sale." },
                    { "TR_1005", "Bu ürüne ait stok satışa kapalı." },
                    { "EN_1006", "No such product found." },
                    { "TR_1006", "Böyle bir ürün bulunamadı." },
                    { "EN_1007", "This product is currently unavailable." },
                    { "TR_1007", "Bu ürün şu anda kullanım dışı." },
                    { "EN_1008", "The stock for the product has expired." },
                    { "TR_1008", "Ürüne ait stoğun kullanılabilir tarihi geçmiş." }
                };
            }
        }

        public string GetErrorString(string prmKey)
        {
            string retString = "";
            langDic.TryGetValue(prmLang.ToUpper() + "_" + prmKey, out retString);
            return retString;
        }
    }

}
