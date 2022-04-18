using Techo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Techo.Contracts
{
    public interface IEntidadParticipativaService
    {
        List<EntidadParticipativa> GetAll();
        EntidadParticipativa GetById(short id);

        //int Save(TipoDocumento model);
        //bool Update(TipoDocumento model);
    }
}
