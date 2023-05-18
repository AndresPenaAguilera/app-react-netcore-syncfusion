using Interfaces.Application;
using Interfaces.Data;
using Interfaces.Domain;
using Models.DTO;
using Models.Entities;

namespace Application
{
    public class DataCreator : IDataCreator
    {
        private readonly IDataTransformation _dataTransformation;
        private readonly IRepository _repository;
        public DataCreator(IDataTransformation dataTransformation, IRepository repository )
        {
            _dataTransformation = dataTransformation;
            _repository = repository;
        }
        public List<string> Save(string? jSONData)
        {
            var data = _dataTransformation.ExtractDataFromJson(jSONData);
            var result = SaveData(data);

            return result;
        }

        private List<string> SaveData(List<OrderDTO> data)
        {
            List<Order> orders = new List<Order>();
            data.ForEach(order =>
            {
                var newOrder = Order.Create(order.Id, order.CustomerID, order.Freight, order.ShipCountry );
                orders.Add(newOrder);
            });
            return _repository.InsertRange(orders);
        }
    }
}