using System.Collections.Generic;
using System.Linq;

namespace Monopoly
{
    public class Monopoly
    {
        private readonly IBuyStrategy _buying;
        private readonly Dictionary<MonopolyType, MonopolyData> _monopolies;
        private readonly IRentStrategy _renting;

        internal Monopoly(
            IEnumerable<string> names,
            IEnumerable<MonopolyData> monopolies,
            IBuyStrategy buying,
            IRentStrategy renting)
        {
            if ((names?.Any() ?? false) == false) throw new MonopolyException("Список имён пуст.");

            if (names.Distinct().Count() < names.Count()) throw new MonopolyException("Список имён содержит повторы.");
            _buying = buying;
            _renting = renting;

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

        public bool Buy(Player buyer, IAsset asset)
        {
            if (buyer == null) throw new MonopolyException("Не указан покупатель.");

            if (asset == null) throw new MonopolyException("Не указано имущество.");

            var monopoly = _monopolies[asset.Type];

            return _buying.Buy(buyer, asset, monopoly);
        }

        public bool Renta(Player renter, IAsset asset)
        {
            if (renter == null) throw new MonopolyException("Не указан арендатор.");

            if (asset == null) throw new MonopolyException("Не указано имущество.");

            var monopoly = _monopolies[asset.Type];
            return _renting.Rent(renter, asset, monopoly);
        }
    }
}