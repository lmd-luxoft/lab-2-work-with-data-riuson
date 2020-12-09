using System.Collections.Generic;

namespace Monopoly
{
    public static class MonopolyFactory
    {
        public static Monopoly Create(IEnumerable<string> names)
        {
            var monopolies = new[]
            {
                new MonopolyData(true, true, MonopolyType.Auto, 500, 250, 250),
                new MonopolyData(true, true, MonopolyType.Food, 250, 250, 250),
                new MonopolyData(true, true, MonopolyType.Clother, 100, 100, 1000),
                new MonopolyData(true, true, MonopolyType.Travel, 700, 300, 300),
                new MonopolyData(true, true, MonopolyType.Prison, 0, 1000, 0),
                new MonopolyData(false, false, MonopolyType.Bank, 0, 700, 0)
            };

            return new Monopoly(names, monopolies, new BuyStrategy(), new RentStrategy());
        }

        public static Monopoly Create(
            IEnumerable<string> names,
            IEnumerable<MonopolyData> monopolies)
        {
            return new Monopoly(names, monopolies, new BuyStrategy(), new RentStrategy());
        }
    }
}