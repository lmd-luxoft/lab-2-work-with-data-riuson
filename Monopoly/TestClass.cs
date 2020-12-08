// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation

using NUnit.Framework;
using System.Linq;

namespace Monopoly
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void GetPlayersListReturnCorrectList()
        {
            var players = new []{ "Peter","Ekaterina","Alexander" };
            var expectedPlayers = new []
            {
                new PlayerInfo("Peter",6000),
                new PlayerInfo("Ekaterina",6000),
                new PlayerInfo("Alexander",6000)
            };
            var monopoly = new Monopoly(players);

            var actualPlayers = monopoly.Players;

            Assert.AreEqual(expectedPlayers, actualPlayers);
        }

        [Test]
        public void GetFieldsListReturnCorrectList()
        {
            var expectedCompanies = new [] {
                new FieldData("Ford", Monopoly.Type.AUTO),
                new FieldData("MCDonald", Monopoly.Type.FOOD),
                new FieldData("Lamoda", Monopoly.Type.CLOTHER),
                new FieldData("Air Baltic", Monopoly.Type.TRAVEL),
                new FieldData("Nordavia", Monopoly.Type.TRAVEL),
                new FieldData("Prison", Monopoly.Type.PRISON),
                new FieldData("MCDonald", Monopoly.Type.FOOD),
                new FieldData("TESLA", Monopoly.Type.AUTO)
            };
            
            var players = new [] { "Peter", "Ekaterina", "Alexander" };
            var monopoly = new Monopoly(players);
            var actualCompanies = monopoly.Fields;
            Assert.AreEqual(expectedCompanies, actualCompanies);
        }

        [Test]
        public void PlayerBuyNoOwnedCompanies()
        {
            string[] players = { "Peter", "Ekaterina", "Alexander" };
            var monopoly = new Monopoly(players);
            var x = monopoly.GetFieldByName("Ford");
            monopoly.Buy(1, x);
            var actualPlayer = monopoly.GetPlayerInfo(1);
            var expectedPlayer = new PlayerInfo("Peter", 5500);
            Assert.AreEqual(expectedPlayer, actualPlayer);
            var actualField = monopoly.GetFieldByName("Ford");
            Assert.AreEqual(1, actualField.Money);
        }

        [Test]
        public void RentaShouldBeCorrectTransferMoney()
        {
            string[] players = { "Peter", "Ekaterina", "Alexander" };
            var monopoly = new Monopoly(players);
            var x = monopoly.GetFieldByName("Ford");
            monopoly.Buy(1, x);
            x = monopoly.GetFieldByName("Ford");
            monopoly.Renta(2, x);
            var player1 = monopoly.GetPlayerInfo(1);
            Assert.AreEqual(5750, player1.Cash);
            var player2 = monopoly.GetPlayerInfo(2);
            Assert.AreEqual(5750, player2.Cash);
        }
    }
}
