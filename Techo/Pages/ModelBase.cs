using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Techo.ViewModels;

namespace Techo.Pages
{
    public class ModelBase : PageModel
    {
        public ModelBase()
        {
        }

        public string Username { get; set; }
        public bool IsLogged { get; set; }
        [BindProperty]
        public string ResultMessage { get; set; }
        [BindProperty]
        public bool Error { get; set; }

        [BindProperty]
        public string SuccessMessage { get; set; }

        [BindProperty]
        public string ErrorMessage { get; set; }

        public void CheckLogin()
        {
            if (string.IsNullOrWhiteSpace(HttpContext.Session.GetString("userLogged")))
            {
                HttpContext.Items.Add("timeout", true);
                HttpContext.Session.SetString("Login", "0");
                Response.Redirect("Login");
            }

            IsLogged = true;
            Username = HttpContext.Session.GetString("userLogged");
        }

        protected void AddResultMessage(string msg, bool error)
        {
            //ResultMessage = msg;
            //Error = error;
            TempData["Success"] = msg;
            TempData["Error"] = error;
        }

        protected void FillResultMessages(string successMessage, string errorMessage)
        {
            SuccessMessage = successMessage;
            ErrorMessage = errorMessage;
        }
    }
}