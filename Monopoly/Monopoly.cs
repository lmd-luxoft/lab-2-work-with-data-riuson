using System.Collections.Generic;
using System.Linq;

namespace Monopoly
{
    public class Monopoly
    {
        private readonly Dictionary<MonopolyType, IMonopolyType> _monopolies;

        internal Monopoly(
            IEnumerable<string> names,
            IEnumerable<IMonopolyType> monopolies)
        {
            if ((names?.Any() ?? false) == false) throw new MonopolyException("Список имён пуст.");

            if (names.Distinct().Count() < names.Count()) throw new MonopolyException("Список имён содержит повторы.");

            foreach (var name in names) Players.Add(name, 6000);

            _monopolies = monopolies.ToDictionary(x => x.Type);

            Assets.Add("Ford", MonopolyType.Auto);
            Assets.Add("MCDonald", MonopolyType.Food);
            Assets.Add("Lamoda", MonopolyType.Clother);
            Assets.Add("Air Baltic", MonopolyType.Travel);
            Assets.Add("Nordavia", MonopolyType.Travel);
            Assets.Add("Prison", MonopolyType.Prison);
            //Assets.Add("MCDonald", MonopolyType.Food); // ???
            Assets.Add("TESLA", MonopolyType.Auto);
        }

        public IPlayers Players { get; } = new Players();

        public IAssets Assets { get; } = new Assets();

        public bool Buy(IPlayer buyer, IAsset asset)
        {
            if (buyer == null) throw new MonopolyException("Не указан покупатель.");

            if (asset == null) throw new MonopolyException("Не указано имущество.");

            var monopoly = _monopolies[asset.Type];

            if (!monopoly.CanBuy) return false;

            if (asset.Owner != null) return false;

            buyer.Cash -= monopoly.BuySumm;
            asset.Owner = buyer;
            return true;
        }

        public bool Renta(IPlayer renter, IAsset asset)
        {
            if (renter == null) throw new MonopolyException("Не указан арендатор.");

            if (asset == null) throw new MonopolyException("Не указано имущество.");

            var monopoly = _monopolies[asset.Type];

            if (monopoly.CanHaveOwner && asset.Owner == null) return false;

            if (monopoly.CanHaveOwner)
            {
                renter.Cash -= monopoly.RentaSummMinus;
                asset.Owner.Cash += monopoly.RentaSummPlus;
            }
            else
            {
                renter.Cash -= monopoly.RentaSummMinus;
            }

            return true;
        }
    }

    public static class MonopolyFactory
    {
        public static Monopoly Create(IEnumerable<string> names)
        {
            var monopolies = new IMonopolyType[]
            {
                new AutoMonopoly(),
                new FoodMonopoly(),
                new ClotherMonopoly(),
                new TravelMonopoly(),
                new PrisonMonopoly(),
                new BankMonopoly()
            };

            return new Monopoly(names, monopolies);
        }

        public static Monopoly Create(
            IEnumerable<string> names,
            IEnumerable<IMonopolyType> monopolies)
        {
            return new Monopoly(names, monopolies);
        }
    }
}