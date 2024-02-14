using Experiments.Data.Context;
using Experiments.Models.Dtos.Stats;
using Experiments.Repos.ExperimentsRepo;
using Microsoft.EntityFrameworkCore;

namespace Experiments.Tests

{
    public class ExperimentsRepoTests
    {

        private readonly IExperimentsRepo _repo;

        public ExperimentsRepoTests()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ExperimentsDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=ColorsExperimentDb;User Id=admin;Password=admin;TrustServerCertificate=true;");
            var dbContextOptions = optionsBuilder.Options;
            var dbContext = new ExperimentsDbContext(dbContextOptions);
            _repo = new SqlExperimentsRepo(dbContext);
        }

        [Fact]
        public async Task GetColorForDevice_ReturnsColorKeyValuePair()
        {
            // Arrange
            var deviceToken = "device1";

            // Act
            var result = await _repo.GetColorForDevice(deviceToken);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<KeyValuePair<string, string>>(result);
            Assert.Equal("button_color", result.Key);
        }

        [Fact]
        public async Task GetPriceForDevice_ReturnsPriceKeyValuePair()
        {
            // Arrange
            var deviceToken = "device1";

            // Act
            var result = await _repo.GetPriceForDevice(deviceToken);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<KeyValuePair<string, decimal>>(result);
            Assert.Equal("price", result.Key);
        }

        [Fact]
        public async Task GetExperimentResults_ReturnsListOfExperimentStatsDto()
        {
            // Arrange
            var experimentKey = "button_color";

            // Act
            var result = await _repo.GetExperimentResults(experimentKey);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<GetExperimentStatsDto>>(result);
        }
    }


}