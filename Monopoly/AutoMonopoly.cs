namespace Monopoly
{
    internal class AutoMonopoly : IMonopolyType
    {
        public bool CanBuy => true;
        public bool HaveOwner => true;
        public Monopoly.Type Type => Monopoly.Type.AUTO;
        public int BuySumm => 500;
        public int RentaSummMinus => 250;
        public int RentaSummPlus => 250;
    }
}