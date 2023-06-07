using ASP.NET_Ajax_Json_CRUD.Models;

namespace ASP.NET_Ajax_Json_CRUD.Services
{
    public interface IItemRepository
    {
        Task AddItem(ItemVM inventoryItemId);
    }
}
