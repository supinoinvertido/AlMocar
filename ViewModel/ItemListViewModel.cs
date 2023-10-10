using AlMocar.Models;

namespace AlMocar.ViewModel
{
    public class ItemListViewModel
    {
        public IEnumerable<Item> Items{get;set;}
        public string CategoriaAtual {get;set;}
    }
}