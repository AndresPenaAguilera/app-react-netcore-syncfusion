using Models.Entities;

namespace Interfaces.Data
{
    public interface IRepository
    {
        IEnumerable<Order> GetAll();
        Order Get(string id);
        List<string> InsertRange(List<Order> entities);
        bool Update(Order entity);
        bool Delete(string id);
    }
}
