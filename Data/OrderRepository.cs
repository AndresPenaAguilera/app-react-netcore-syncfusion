using Dapper;
using Interfaces.Data;
using Models.Entities;
using System.Data;

namespace Data
{
    public class OrderRepository : IRepository
    {
        private readonly IDbConnection _connection;

        public OrderRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public Order Get(string id)
        {
            string query = $"SELECT * FROM  [dbo].[Orders] WHERE Id = @Id";
            return  _connection.QueryFirstOrDefault<Order>(query, new { Id = id });
        }

        public IEnumerable<Order> GetAll()
        {
            string query = $"SELECT * FROM [dbo].[Orders]";
            return  _connection.Query<Order>(query);
        }

        public List<string> InsertRange(List<Order> entities)
        {
            List<string> ordersList = new List<string>();

            string query = $"INSERT INTO [dbo].[Orders](CustomerID, Freight, Id, ShipCountry) VALUES (@CustomerID, @Freight, @Id, @ShipCountry)";

            using (_connection)
            {
                _connection.Open();

                foreach (var entity in entities)
                {
                    string queryFind = $"SELECT * FROM  [dbo].[Orders] WHERE Id = @Id";
                    var existingOrder = _connection.QueryFirstOrDefault<Order>(queryFind, new { Id = entity.Id });
                
                    if (existingOrder == null) {
                        var valor = _connection.ExecuteScalar<string>(query, entity);
                        ordersList.Add(valor);
                    }
                   
                }

                _connection.Close();
            }

            return ordersList;
        }

        public bool Update(Order entity)
        {
            string query = $"UPDATE [dbo].[Orders] SET CustomerID=@CustomerID, Freight=@Freight, ShipCountry=@ShipCountry WHERE Id = @Id";
            int rowsAffected = _connection.Execute(query, entity);
            return rowsAffected > 0;
        }

        public bool Delete(string id)
        {
            string query = $"DELETE FROM [dbo].[Orders] WHERE Id = @Id";
            int rowsAffected = _connection.Execute(query, new { Id = id });
            return rowsAffected > 0;
        }
    }

}
