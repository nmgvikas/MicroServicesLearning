using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QGMDemo
{
    public class MyQGMClass : IHttpHandler
    {
        public bool IsReusable => false;

        public void ProcessRequest(HttpContext context)
        {
            HttpContext.Current.Response.Write($"<h1> {DateTime.Now.ToLongDateString()} </h1>");
        }
    }
}