using Techo.Contracts;
using Techo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Techo.Services
{
    public class EntidadParticipativaService : IEntidadParticipativaService
    {
        private readonly TechoContext _context;

        public EntidadParticipativaService(TechoContext context)
        {
            _context = context;
        }

        public List<EntidadParticipativa> GetAll()
        {
            var res = _context.EntidadParticipativas.ToList();
            return res;
        }

        public EntidadParticipativa GetById(short id)
        {
            return _context.EntidadParticipativas.FirstOrDefault(t => t.Id == id);
        }
    }
}
