namespace TownApplication.IntegrationTests
{
    public class TownControllerIntegrationTests
    {
        private readonly TownController _controller;

        public TownControllerIntegrationTests()
        {
            _controller = new TownController();
            _controller.ResetDatabase();
        }

        [Fact]
        public void AddTown_ValidInput_ShouldAddTown()
        {
            string townName = "Sofia";
            int population = 2000;

            _controller.AddTown(townName, population);
            var town = _controller.GetTownByName(townName);

            Assert.NotNull(town);
            Assert.Equal(townName, town.Name);
            Assert.Equal(population, town.Population);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("AB")]
        public void AddTown_InvalidName_ShouldThrowArgumentException(string invalidName)
        {
            int population = 2000;

            var result = Assert.Throws<ArgumentException>(() => _controller.AddTown(invalidName, population));

            Assert.Equal("Invalid town name.", result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void AddTown_InvalidPopulation_ShouldThrowArgumentException(int invalidPopulation)
        {
            string townName = "Sofia";

            var act = () => _controller.AddTown(townName, invalidPopulation);
            var exception = Assert.Throws<ArgumentException>(act);
            Assert.NotNull(exception);
            Assert.Equal("Population must be a positive number.", exception.Message);
        }

        [Fact]
        public void AddTown_DuplicateTownName_DoesNotAddDuplicateTown()
        {
            string townName = "Sofia";
            int population = 2000;

            _controller.AddTown(townName, population);
            _controller.AddTown(townName, population + 1000);

            var result = _controller.ListTowns();

            Assert.Single(result);
            Assert.Equal(townName, result[0].Name);
            Assert.Equal(population, result[0].Population);
        }

        [Fact]
        public void UpdateTown_ShouldUpdatePopulation()
        {
            string townName = "Sofia";
            int initialPopulation = 2000;
            int updatedPopulation = 3000;

            _controller.AddTown(townName, initialPopulation);

            var townToUpdate = _controller.GetTownByName(townName);
            _controller.UpdateTown(townToUpdate.Id, updatedPopulation);

            var updatedTown = _controller.GetTownByName(townName);

            Assert.NotNull(updatedTown);
            Assert.Equal(updatedPopulation, updatedTown.Population);
        }

        [Fact]
        public void DeleteTown_ShouldDeleteTown()
        {
            string townName = "Sofia";
            int population = 2000;
            _controller.AddTown(townName, population);

            var townToDelete = _controller.GetTownByName(townName);
            _controller.DeleteTown(townToDelete.Id);

            var result = _controller.GetTownByName(townName);
            var towns = _controller.ListTowns();

            Assert.Empty(towns);
            Assert.Null(result);    
        }

        [Fact]
        public void ListTowns_ShouldReturnTowns()
        {
            List<string> townNames = new List<string>(){ "Sofia", "Varna", "Burgas", "Plovdiv" };
            int population = 100;

            foreach (var town in townNames)
            {
                _controller.AddTown(town, town.Length * 100);
                population += 100;
            }

            var towns = _controller.ListTowns();

            Assert.Equal(townNames.Count, towns.Count);
            foreach (var town in townNames)
            {
                var existingTown = towns.FirstOrDefault(t => t.Name == town);
                Assert.NotNull(existingTown);
                Assert.Equal(town.Length * 100, existingTown.Population);
            }
        }
    }
}
