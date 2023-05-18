using Interfaces.Application;
using Interfaces.Data;
using Interfaces.Domain;
using Models.DTO;
using Models.Entities;

namespace Application
{
    public class Querys 
    {
        private readonly IRepository _repository;
        public Querys(IRepository repository )
        {
            _repository = repository;
        }
        public IEnumerable<Order> GetAll() => _repository.GetAll();

        public Order Get(string id) =>  _repository.Get(id);
    }
}