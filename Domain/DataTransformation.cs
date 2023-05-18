using Interfaces.Domain;
using Models.DTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Domain
{
    public class DataTransformation : IDataTransformation
    {
        public List<OrderDTO> ExtractDataFromJson(string json)
        {
            dynamic data = JsonConvert.DeserializeObject(json);
            var rows = data.sheets[0].rows;
            List<OrderDTO> orders = new List<OrderDTO>();
            foreach (var cell in rows)
            {
                if ((JValue)cell.cells[0].value == null) continue;

                var id = ((JValue)cell.cells[0].value).Value.ToString();

                if(id != "Order ID")
                {
                    var customerID = ((JValue)cell.cells[1].value).Value.ToString();
                    var freight = ((JValue)cell.cells[2].value).Value.ToString();
                    var shipCountry = ((JValue)cell.cells[3].value).Value.ToString();

                    var order = new OrderDTO(id, customerID, freight, shipCountry);

                    orders.Add(order);
                }
               
            }
            return orders;
        }
    }
}