using AlMocar.Context;
using AlMocar.Models;
namespace AlMocar.Repositories.Interfaces
{
    public interface ICategoriaRepository 
    {
        public IEnumerable<Categoria> Categorias{get;}
    }
}