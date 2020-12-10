// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation

using NUnit.Framework;

namespace Monopoly
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void CannotAddClones()
        {
            // Arrange.
            string[] players = {"Peter", "Ekaterina", "Alexander", "Peter"};

            // Act & Assert.
            Assert.Throws<MonopolyException>(() => MonopolyFactory.Create(players));
        }

        [Test]
        public void GetFieldsListReturnCorrectList()
        {
            var expectedAssets = new[]
            {
                new Asset("Ford", MonopolyType.Auto),
                new Asset("MCDonald", MonopolyType.Food),
                new Asset("Lamoda", MonopolyType.Clother),
                new Asset("Air Baltic", MonopolyType.Travel),
                new Asset("Nordavia", MonopolyType.Travel),
                new Asset("Prison", MonopolyType.Prison),

                /// Обращение всё равно производилось по имени, значит дублирующие поля висели мёртым грузом.
                //new Asset("MCDonald", MonopolyType.Food),

                new Asset("TESLA", MonopolyType.Auto)
            };

            var players = new[] {"Peter", "Ekaterina", "Alexander"};
            var monopoly = MonopolyFactory.Create(players);
            var actualAssets = monopoly.Assets;
            Assert.AreEqual(expectedAssets, actualAssets);
        }

        [Test]
        public void GetPlayersListReturnCorrectList()
        {
            var players = new[] {"Peter", "Ekaterina", "Alexander"};
            var expectedPlayers = new[]
            {
                new Player("Peter", 6000),
                new Player("Ekaterina", 6000),
                new Player("Alexander", 6000)
            };
            var monopoly = MonopolyFactory.Create(players);

            var actualPlayers = monopoly.Players;

            Assert.AreEqual(expectedPlayers, actualPlayers);
        }

        [Test]
        public void PlayerBuyNoOwnedCompanies()
        {
            // Arrange.
            string[] players = {"Peter", "Ekaterina", "Alexander"};
            var monopoly = MonopolyFactory.Create(players);
            var asset = monopoly.Assets.ByName("Ford");

            // Act.
            var buyer = monopoly.Players.ByName("Peter");
            monopoly.Buy(buyer, asset);

            // Assert.
            var actualPlayer = monopoly.Players.ByName("Peter");

            var expectedPlayer = new Player("Peter", 5500);
            Assert.AreEqual(expectedPlayer, actualPlayer);

            var actualField = monopoly.Assets.ByName("Ford");
            Assert.AreEqual("Peter", actualField.Owner.Name);
        }

        [Test]
        public void RentaShouldBeCorrectTransferMoney()
        {
            // Arrange.
            string[] players = {"Peter", "Ekaterina", "Alexander"};
            var monopoly = MonopolyFactory.Create(players);

            // Act.
            var asset = monopoly.Assets.ByName("Ford");
            var buyer = monopoly.Players.ByName("Peter");
            monopoly.Buy(buyer, asset);

            var renter = monopoly.Players.ByName("Ekaterina");
            asset = monopoly.Assets.ByName("Ford");
            monopoly.Renta(renter, asset);

            // Assert.
            var player1 = monopoly.Players.ByName("Peter");
            Assert.AreEqual(5750, player1.Cash);

            var player2 = monopoly.Players.ByName("Ekaterina");
            Assert.AreEqual(5750, player2.Cash);
        }
    }
}