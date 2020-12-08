namespace Monopoly
{
    internal class ClotherMonopoly : IMonopolyType
    {
        public bool CanBuy => true;
        public bool HaveOwner => true;
        public Monopoly.Type Type => Monopoly.Type.CLOTHER;
        public int BuySumm => 100;
        public int RentaSummMinus => 100;
        public int RentaSummPlus => 1000;
    }
}