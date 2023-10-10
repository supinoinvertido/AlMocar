using AlMocar.Context;
using AlMocar.Models;
using AlMocar.Repositories.Interfaces;

namespace AlMocar.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;
        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> Categorias => _context.Categorias;
    }
}