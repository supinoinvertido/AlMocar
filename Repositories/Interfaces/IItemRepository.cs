using AlMocar.Models;

namespace AlMocar.Repositories.Interfaces
{
    public interface IItemRepository
    {
        IEnumerable<Item> Items { get; }
        IEnumerable<Item> ItemsEmDestaque { get; }
        Item GetItemById(int itemid);
    }
}