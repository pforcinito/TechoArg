using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Techo.Pages;
using Techo.Contracts;
using Techo.ViewModels;

namespace Techo.Views
{
    [AllowAnonymous]
    //public class LoginModel : PageModel
    public class LoginModel : ModelBase
    {
        private readonly ILoginService _service;
        private readonly IDatabaseService _dbService;
        private readonly ILoggerManager _loggerManager;

        [BindProperty]
        public UsuarioViewModel Usuario { get; set; }
        //public string ErrorMessage { get; set; }
        public bool ShowErrorMessage { get { return !string.IsNullOrWhiteSpace(ErrorMessage); } }

        public LoginModel(ILoginService service, IDatabaseService dbService, ILoggerManager loggerManager)
        {
            _service = service;
            _dbService = dbService;
            _loggerManager = loggerManager;
        }

        public void OnGet()
        {
            Usuario = new UsuarioViewModel();
        }

        public IActionResult OnGetDatabaseStatus()
        {
            return _dbService.IsOnline() ? new StatusCodeResult(200) : BadRequest();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _loggerManager.LogInfo($"Trying login to user {Usuario.Nombre}");
                _loggerManager.LogDebug($"With password: {Usuario.Password}");
                
                var res = _service.Login(Usuario);

                if(res)
                {
                    HttpContext.Session.SetString("userLogged", Usuario.Nombre);
                    HttpContext.Session.SetString("token", Usuario.Token);
                    return RedirectToPage("Index");
                }

                _loggerManager.LogInfo("Invalid Login");
                ErrorMessage = "Invalid Login";
            }

            _loggerManager.LogInfo("Login ok");

            return Page();
        }

        public void OnGetCloseSession()
        {
            if (!string.IsNullOrWhiteSpace(HttpContext.Session.GetString("userLogged")))
            {
                HttpContext.Session.Remove("userLogged");
                HttpContext.Session.Remove("Login");
            }

            Response.Redirect("Login");
        }
    }
}