namespace Monopoly
{
    internal class AutoMonopoly : IMonopolyType
    {
        public bool CanBuy => true;
        public bool CanHaveOwner => true;
        public MonopolyType Type => MonopolyType.Auto;
        public int BuySumm => 500;
        public int RentaSummMinus => 250;
        public int RentaSummPlus => 250;
    }
}