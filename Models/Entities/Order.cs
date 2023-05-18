using System.ComponentModel.DataAnnotations;

namespace Models.Entities
{
    public  class Order
    {
        public const string FIELD_ID_REQUIRED = "FIELD_ID_REQUIRED";

        public Order() { }
        public static Order Create(string id, string customerID, string freight, string shipCountry) 
        {
            FieldsValidations(id, customerID, freight, shipCountry);
            
            return new Order(id, customerID, freight, shipCountry);
        }

        private static void FieldsValidations(string id, string customerID, string freight, string shipCountry)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(FIELD_ID_REQUIRED);
        }

        public Order(string id, string customerID, string freight, string shipCountry) {
            Id = id;
            CustomerID = customerID;
            Freight = freight;  
            ShipCountry = shipCountry;
        }

        public string CustomerID { get; private set; }
        public string Freight { get; private set; }
        [Key]
        public string Id { get; set; }
        public string ShipCountry { get; private set; }
    }
}
