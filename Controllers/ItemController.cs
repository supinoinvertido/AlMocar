using AlMocar.Models;
using AlMocar.Repositories.Interfaces;
using AlMocar.ViewModel;
using Microsoft.AspNetCore.Mvc;


namespace AlMocar.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemRepository _itemRepository;
        public ItemController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        public IActionResult List(string categoria)
        {
            IEnumerable<Item> items;
            var categoriaAtual = string.Empty;
            if (string.IsNullOrEmpty(categoria))
            {
                items = _itemRepository.Items.OrderBy(m => m.itemid);
                categoriaAtual = "Todos os itens";
            }
            else
            {
                items = _itemRepository.Items.Where(m =>
                m.Categoria.NomeCategoria.Equals(categoria)).OrderBy(m => m.itemid);

                categoriaAtual = categoria;
            }
            var itemListViewModel = new ItemListViewModel
            {
                Items = items,
                CategoriaAtual = categoriaAtual
            };

            return View(itemListViewModel);
        }
        public IActionResult Details(int itemid)
        {

            var item = _itemRepository.Items.FirstOrDefault(m => m.itemid == itemid);

            return View(item);
        }
        public IActionResult Search(string searchString)
        {

            IEnumerable<Item> Items;
            string categoriaAtual = string.Empty;
            if (string.IsNullOrEmpty(searchString))
            {
                Items = _itemRepository.Items.OrderBy(m => m.Nome);
                categoriaAtual = "Todos os Itens";
            }
            else
            {
                Items = _itemRepository.Items.Where(m => m.Nome.ToLower() == searchString.ToLower()).OrderBy(m => m.Nome);

                if (Items.Any())
                {
                    categoriaAtual = "Itens";
                }
                else
                {
                    categoriaAtual = "Nada encontrado";
                }
            }
            return View("~/Views/item/List.cshtml", new ItemListViewModel
            {
                CategoriaAtual = categoriaAtual,
                Items = Items
            });

        }
    }
}