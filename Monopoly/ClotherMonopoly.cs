namespace Monopoly
{
    internal class ClotherMonopoly : IMonopolyType
    {
        public bool CanBuy => true;
        public bool CanHaveOwner => true;
        public MonopolyType Type => MonopolyType.Clother;
        public int BuySumm => 100;
        public int RentaSummMinus => 100;
        public int RentaSummPlus => 1000;
    }
}