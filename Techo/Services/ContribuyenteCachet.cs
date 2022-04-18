using Microsoft.Extensions.Caching.Memory;
using Techo.Contracts;
using Techo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Techo.Services
{
    public class ContribuyenteCachet : IContribuyenteServiceCache
    {
        private MemoryCache _cache;
        private IContribuyenteService _serviceCliente;

        public ContribuyenteCachet(IContribuyenteService service)
        {
            _cache = new MemoryCache(new MemoryCacheOptions());
            _serviceCliente = service;
        }

        public List<Contribuyente> GetAll()
        {
            return _serviceCliente.GetAll();
        }

        public Contribuyente GetById(short id)
        {
            if(!_cache.TryGetValue(id, out Contribuyente cliente))
            {
                cliente = _serviceCliente.GetById(id);
                _cache.Set(id, cliente);
                return cliente;
            }
            return cliente;
        }
        
        public int Save(Contribuyente model)
        {
            throw new NotImplementedException();
        }

        public bool Update(Contribuyente model)
        {
            throw new NotImplementedException();
        }
    }
}
