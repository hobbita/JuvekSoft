using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JuvekSoft.Models;

namespace JuvekSoft
{
    /// <summary>
    /// Сводное описание для Handler1
    /// </summary>
    public class Handler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "image/jpeg";
            context.Response.Write("Привет всем!");
            var param = context.Request.QueryString["id"];
            int id = 0;
            if(param != null && int.TryParse(param, out id))
            {
                byte[] image = null;
                using (Model1 dc = new Model1())
                {
                    image = dc.InsertStores.Where(a => a.id.Equals(id)).FirstOrDefault().Photo;
                    
                }

                TimeSpan CacheTime = new TimeSpan(1, 0, 0);
                context.Response.Cache.VaryByParams["*"] = true;
                context.Response.Cache.SetExpires(DateTime.Now.Add(CacheTime));
                context.Response.Cache.SetMaxAge(CacheTime);
                context.Response.Cache.SetCacheability(HttpCacheability.Public);
                context.Response.BinaryWrite(image);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}