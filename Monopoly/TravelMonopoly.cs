namespace Monopoly
{
    internal class TravelMonopoly : IMonopolyType
    {
        public bool CanBuy => true;
        public bool HaveOwner => true;
        public Monopoly.Type Type => Monopoly.Type.TRAVEL;
        public int BuySumm => 700;
        public int RentaSummMinus => 300;
        public int RentaSummPlus => 300;
    }
}