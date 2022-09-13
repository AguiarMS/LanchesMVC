using LanchesMVC.Context;
using LanchesMVC.Models;
using LanchesMVC.Repository.Interfaces;

namespace LanchesMVC.Repository
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
