using AlMocar.Context;
using AlMocar.Models;
using AlMocar.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AlMocar.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _context;
        public ItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Item> Items => _context.Items.Include(c =>
        c.Categoria);
        public IEnumerable<Item> ItemsEmDestaque =>
        _context.Items.Where(m => m.Destaque).Include(c => c.Categoria);

        public Item GetItemById(int itemid)
        {
            return _context.Items.FirstOrDefault(m => m.itemid == itemid);
        }
    }
}