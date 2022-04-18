using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Techo.Contracts;
using Techo.Models;
using Techo.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Techo.Services
{
    public class LoginService : ILoginService
    {
        private readonly TechoContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly ILoggerManager _loggerManager;

        public LoginService(TechoContext context, IMapper mapper, IConfiguration configuration, ILoggerManager loggerManager)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
            _loggerManager = loggerManager;
        }

        public List<Usuario> GetAll()
        {
            throw new NotImplementedException();
        }

        public Usuario GetById(int id)
        {
            if(Exists(id))
               return _context.Usuarios.First(x => x.Id == id);

            return null;
        }

        public Usuario GetByName(string username)
        {
            if (Exists(username))
                return _context.Usuarios.First(x => x.Nombre.ToUpper() == username.ToUpper());

            return null;
        }

        public bool Login(UsuarioViewModel model)
        {
            try
            {
                if (Exists(model.Nombre) && ValidCredentials(model.Nombre, model.Password))
                {
                    var user = GetByName(model.Nombre);

                    var secretKey = _configuration.GetValue<string>("SecretKey");
                    var duration = _configuration.GetValue<int>("AuthenticationDuration");
                    var key = Encoding.ASCII.GetBytes(secretKey);

                    // Creamos los claims (pertenencias, características) del usuario
                    var claims = new[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.Nombre)
                    };

                    var claimsIdentity = new ClaimsIdentity(claims);

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = claimsIdentity,
                        // Nuestro token va a durar un día
                        //Expires = DateTime.UtcNow.AddDays(1),
                        Expires = DateTime.UtcNow.AddMinutes(duration),
                        // Credenciales para generar el token usando nuestro secretykey y el algoritmo hash 256
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var createdToken = tokenHandler.CreateToken(tokenDescriptor);

                    model.Token = tokenHandler.WriteToken(createdToken);

                    _loggerManager.LogInfo("Login ok");

                    return true;
                }
            }
            catch(Exception ex)
            {
                _loggerManager.LogError($"Error at login. Message: {ex.Message}", ex);
            }

            return false;
        }

        private bool Exists(int id)
        {
            return _context.Usuarios.Any(x => x.Id == id);
        }

        private bool Exists(string username)
        {
            return _context.Usuarios.Any(x => x.Nombre.ToUpper() == username.ToUpper());
        }

        private bool ValidCredentials(string usuario, string password)
        {
            return _context.Usuarios.Any(x => x.Nombre.ToUpper() == usuario.ToUpper() && x.Password == password && x.Activo);
        }
    }
}