namespace Monopoly
{
    internal class TravelMonopoly : IMonopolyType
    {
        public bool CanBuy => true;
        public bool CanHaveOwner => true;
        public MonopolyType Type => MonopolyType.Travel;
        public int BuySumm => 700;
        public int RentaSummMinus => 300;
        public int RentaSummPlus => 300;
    }
}