using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevTask.Services.Airports;
using DevTask.Services.Airports.Model;
using DevTask.Services.Airports.Settings;
using DevTask.Services.Http.Airports;
using DevTask.Services.Http.Model.Airports;
using DevTask.Services.Storage;
using DevTask.Services.Storage.Map;
using DevTask.Services.Storage.Model;
using Moq;
using Xunit;

namespace DevTask.Tests.Services
{
    public class AirportsServiceTests
    {
        protected IAirportsServiceSettings Settings => new AirportsServiceSettings
        {
            GetUrl = "url"
        };
        
        protected Mock<IAirportsHttpService> AirportsHttpService;
        protected Mock<IAirportsRepository> AirportsRepository;
        protected Mock<IMapperFactory> MapperFactory;

        private IAirportsService AirportsService;

        public void SetupHttpService()
        {
            AirportsHttpService = new Mock<IAirportsHttpService>();
            AirportsHttpService.Setup(x => x.Get()).ReturnsAsync(new AirportsJsonGetResponse());
        }

        public void SetupRepository()
        {
            AirportsRepository = new Mock<IAirportsRepository>();
            AirportsRepository.Setup(x => x.Get(It.IsAny<IEnumerable<string>>()))
                .Returns<IEnumerable<string>>(x => Enumerable.Empty<IAirportsRepositoryItem>());
        }

        public void SetupMapper()
        {
            MapperFactory = new Mock<IMapperFactory>();
            
            var serviceResponseMapperMoq =
                new Mock<IEntityMapper<IEnumerable<IAirportsRepositoryItem>, AirportServiceResponse>>();
            serviceResponseMapperMoq.Setup(x => x.Map(It.IsAny<IEnumerable<IAirportsRepositoryItem>>()))
                .Returns<IEnumerable<IAirportsRepositoryItem>>((x) => new AirportServiceResponse());
            
            var httpResponseMapperMoq =
                new Mock<IEntityMapper<AirportsJsonGetResponse, AirportServiceResponse>>();
            httpResponseMapperMoq.Setup(x => x.Map(It.IsAny<AirportsJsonGetResponse>()))
                .Returns<AirportsJsonGetResponse>((x) => new AirportServiceResponse());

            MapperFactory.Setup(x => x.ResolveMapper<IEnumerable<IAirportsRepositoryItem>, AirportServiceResponse>())
                .Returns(() => serviceResponseMapperMoq.Object);
            MapperFactory.Setup(x => x.ResolveMapper<AirportsJsonGetResponse, AirportServiceResponse>())
                .Returns(() => httpResponseMapperMoq.Object);
        }

        public AirportsServiceTests()
        {
            SetupRepository();
            SetupHttpService();
            SetupMapper();
            AirportsService = new AirportsService(AirportsHttpService.Object, AirportsRepository.Object,
                MapperFactory.Object);
        }

        [Fact]
        public async Task AirportsService_WhenBypassCache_ShouldCallHttpService()
        {
            // Act
            var result = await AirportsService.GetAirports(true);

            // Assert
            AirportsHttpService.Verify(x => x.Get(), Times.Once);
            Assert.False(result.FromCache);
        }
    }
}