using Models.DTO;
using Models.Entities;

namespace Interfaces.Application
{
    public interface IOrderService
    {
        bool Update(OrderDTO order);
        bool Delete(string id);
    }
}
