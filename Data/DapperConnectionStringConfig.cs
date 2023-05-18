using Microsoft.Extensions.Configuration;

namespace Data
{
    public class DapperConnectionStringConfig
    {
        public string ConnectionString { get; set; }

        public DapperConnectionStringConfig(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }
    }
}
