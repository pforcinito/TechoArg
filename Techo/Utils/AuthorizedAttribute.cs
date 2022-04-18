//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc.Filters;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Sanitarios.Utils
//{
//    public class Authorized : IAuthorizationFilter
//    {
//        public void OnAuthorization(AuthorizationFilterContext context)
//        {
//            if (string.IsNullOrWhiteSpace(context.HttpContext.Session.GetString("userLogged")))
//            {
//                context.HttpContext.Items.Add("timeout", true);
//                context.HttpContext.Session.SetString("Login", "0");
//                context.HttpContext.Response.Redirect("Login");
//            }

//            //IsLogged = true;
//            //Username = HttpContext.Session.GetString("userLogged");
//        }
//    }
//}