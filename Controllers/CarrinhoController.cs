using AlMocar.Models;
using AlMocar.Repositories.Interfaces;
using AlMocar.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AlMocar.Controllers
{
    public class CarrinhoController : Controller
    {
        private readonly Carrinho _carrinho;
        private readonly IItemRepository _ItemRepository;
        public CarrinhoController(Carrinho carrinho, IItemRepository itemRepository)
        {
            _carrinho = carrinho;
            _ItemRepository = itemRepository;
        }
        public IActionResult Index()
        {
            var itens = _carrinho.GetCarrinhoCompraItems();
            _carrinho.CarrinhoItens = itens;
            var carrinhoVM = new CarrinhoViewModel
            {
                Carrinho = _carrinho,
                CarrinhoTotal = _carrinho.GetCarrinhoCompraTotal()
            };
            return View(carrinhoVM);
        }
        public IActionResult AdicionarItemNoCarrinhoCompra(int itemid)
        {
            var itemSelecionado = _ItemRepository.Items.FirstOrDefault(l => l.itemid == itemid);
            if (itemSelecionado != null)
            {
                _carrinho.AdicionarItemCarrinho(itemSelecionado);
            }
            return RedirectToAction("Index");
        }
        public IActionResult RemoverCarrinho(int itemid)
        {
            var itemSelecionado = _ItemRepository.Items.FirstOrDefault(l => l.itemid == itemid);
            if (itemSelecionado != null)
            {
                _carrinho.RemoverItemDoCarrinhoCompra(itemSelecionado);
            }
            return RedirectToAction("Index");
        }
    }
}