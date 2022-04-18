using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Techo.Contracts;
using Techo.ViewModels;

namespace Techo.Controllers
{
    [AllowAnonymous]
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILoginService _service;
        private readonly ILoggerManager _loggerManager;

        public LoginController(IConfiguration configuration, ILoginService service, ILoggerManager loggerManager)
        {
            _configuration = configuration;
            _service = service;
            _loggerManager = loggerManager;
        }

        [HttpPost]
        public IActionResult Login([FromBody]UsuarioViewModel user)
        {
            _loggerManager.LogInfo($"Trying login to user {user.Nombre}");
            _loggerManager.LogDebug($"With password: {user.Password}");

            if (!_service.Login(user))
            {
                _loggerManager.LogInfo("Login invalid");
                return BadRequest();
            }

            _loggerManager.LogInfo("Login ok");

            return RedirectToPage("/Index");
        }
    }
}