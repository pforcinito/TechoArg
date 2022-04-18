using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Techo.Contracts;
using Techo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Techo.Services
{
    public class ContribuyenteService : IContribuyenteService
    {

        private readonly TechoContext _context;
        

        public ContribuyenteService(TechoContext context)
        {
            _context = context;
            
        }

        public List<Contribuyente> GetAll()
        {
            return _context.Contribuyentes.Include(c => c.EntidadParticipativa).ToList();
        }

        public Contribuyente GetById(short id)
        {
            if (Exists(id))
                return _context.Contribuyentes.Include(c => c.EntidadParticipativa).First(c => c.Id == id);

            return null;
        }

        public int Save(Contribuyente model)
        {
            //model.Id = null;

            _context.Contribuyentes.Add(model);

            return _context.SaveChanges();
        }

        public bool Update(Contribuyente model)
        {
            if (Exists(model.Id))
            {
                _context.Contribuyentes.Update(model);
                return _context.SaveChanges() > 0;
            }

            return false;
        }

        private bool Exists(int id)
        {
            return _context.Contribuyentes.Any(c => c.Id == id);
        }
    }
}
