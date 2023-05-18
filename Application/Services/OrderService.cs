using Interfaces.Application;
using Interfaces.Data;
using Models.DTO;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository _repository;
        public OrderService(IRepository repository )
        {
            _repository = repository;
        }

        public bool Update(OrderDTO orderDTO)
        {
            var existingOrden = _repository.Get(orderDTO.Id);
            if (existingOrden == null) { return false; }

            var order = Order.Create(orderDTO.Id, orderDTO.CustomerID, orderDTO.Freight, orderDTO.ShipCountry);

            return _repository.Update(order);
        }


        public bool Delete(string id)
        {
            return _repository.Delete(id);

        }
    }
}
