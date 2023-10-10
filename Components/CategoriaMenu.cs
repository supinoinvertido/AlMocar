using AlMocar.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AlMocar.Components
{
    public class CategoriaMenu : ViewComponent
    {
        private readonly ICategoriaRepository _categoriaRepository;
        public CategoriaMenu(ICategoriaRepository categoriaRespository)
        {
            _categoriaRepository = categoriaRespository;
        }
        public IViewComponentResult Invoke()
        {
            var categoria = _categoriaRepository.Categorias.OrderBy(c =>

            c.NomeCategoria);

            return View(categoria);
        }
    }
}