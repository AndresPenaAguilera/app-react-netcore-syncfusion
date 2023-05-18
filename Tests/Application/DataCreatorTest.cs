using Data;
using Interfaces.Application;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Resolver;
using System.Data;

namespace Tests.Application
{
    [TestClass]
    public class DataCreatorTest
    {
        
        private IDataCreator _dataCreator;

        [TestInitialize]
        public void Initialize()
        {
            TestProgram();
        }

        private void TestProgram()
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            IConfiguration configuration = new ConfigurationBuilder()
             .AddJsonFile("appsettings.Development.json")
             .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            serviceCollection.AddSingleton<IDbConnection>(provider => new SqlConnection(connectionString));
            serviceCollection.AddDbContext<EFDbContext>(options => options.UseSqlServer(connectionString));
            serviceCollection.AddServicesApp();
            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            _dataCreator = serviceProvider.GetService<IDataCreator>();
        }

        [TestMethod]
        public  void Should_ExtractPersonDataFromJson_ReturnValueProperty()
        {
            var expected = 1;
            string json = @"{
            ""allowOpen"": true,
            ""sheets"": [
                {
                    ""name"": ""Hoja1"",
                    ""rows"": [
                        {
                            ""cells"": [
                                {
                                    ""value"": ""Order ID""
                                },
                                {
                                    ""value"": ""Customer ID""
                                },
                                {
                                    ""value"": ""Freight""
                                },
                                {
                                    ""value"": ""Ship Country""
                                }
                            ],
                            ""height"": 19
                        },
                        {
                            ""cells"": [
                                {
                                    ""value"": " + "\"" + Guid.NewGuid() + "\"" + @"
                                },
                                {
                                    ""value"": ""VINET""
                                },
                                {
                                    ""value"": ""32.38"",
                                    ""format"": ""$#,##0.00""
                                },
                                {
                                    ""value"": ""France""
                                }
                            ],
                            ""height"": 19
                        }
                    ],
                    ""selectedRange"": ""F5:F5""
                }
            ]
        }";

            var result = _dataCreator.Save(json);

            Assert.AreEqual(expected, result.Count());

        }
    }
}