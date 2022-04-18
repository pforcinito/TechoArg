using Techo.Models;
using Techo.ViewModels;
using System.Collections.Generic;

namespace Techo.Contracts
{
    public interface ILoginService
    {
        List<Usuario> GetAll();

        Usuario GetById(int id);

        bool Login(UsuarioViewModel model);
    }
}