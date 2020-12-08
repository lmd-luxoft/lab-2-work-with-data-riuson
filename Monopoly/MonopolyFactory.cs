using System.Collections.Generic;

namespace Monopoly
{
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

            return new Monopoly(names, monopolies, new BuyStrategy(), new RentStrategy());
        }

        public static Monopoly Create(
            IEnumerable<string> names,
            IEnumerable<IMonopolyType> monopolies)
        {
            return new Monopoly(names, monopolies, new BuyStrategy(), new RentStrategy());
        }
    }
}