using Interfaces.Domain;
using Microsoft.Extensions.DependencyInjection;
using Resolver;

namespace Tests.Domain
{
    [TestClass]
    public class DataTransformationTest
    {
        private IDataTransformation _dataTransformation;

        [TestInitialize]
        public void Initialize()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddServicesApp();
            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            _dataTransformation = serviceProvider.GetService<IDataTransformation>();
        }

        [TestMethod]
        public void Should_ExtractPersonDataFromJson_ReturnValueProperty()
        {
            var expected = 1;

            string json = File.ReadAllText("data.json");

            var result = _dataTransformation.ExtractDataFromJson(json);

            Assert.AreEqual(expected, result.Count);
        }
    }
}
