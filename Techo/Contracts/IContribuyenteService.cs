using Techo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Techo.Contracts
{
    public interface IContribuyenteService
    {
        List<Contribuyente> GetAll();
        Contribuyente GetById(short id);
        int Save(Contribuyente model);
        bool Update(Contribuyente model);
    }
    public interface IContribuyenteServiceCache
    {
        List<Contribuyente> GetAll();
        Contribuyente GetById(short id);
        int Save(Contribuyente model);
        bool Update(Contribuyente model);
    }
}
