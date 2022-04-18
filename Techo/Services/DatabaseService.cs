using Techo.Contracts;
using Techo.Models;

namespace Techo.Services
{
    public class DatabaseService : IDatabaseService
    {
        private readonly TechoContext _context;

        public DatabaseService(TechoContext context)
        {
            _context = context;
        }

        public bool IsOnline() => _context.Database.CanConnect();
    }
}