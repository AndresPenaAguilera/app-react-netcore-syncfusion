namespace Models.DTO
{
    public  class OrderDTO
    {
        public OrderDTO(string id, string customerID, string freight, string shipCountry) {
            Id = id;
            CustomerID = customerID;
            Freight = freight;  
            ShipCountry = shipCountry;
        }

        public string Id { get; }
        public string CustomerID { get; }
        public string Freight { get; }
        public string ShipCountry { get; }
    }
}
