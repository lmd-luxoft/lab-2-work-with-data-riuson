namespace Monopoly
{
    internal class PrisonMonopoly : IMonopolyType
    {
        public bool CanBuy => false;
        public bool HaveOwner => false;
        public Monopoly.Type Type => Monopoly.Type.PRISON;
        public int BuySumm => throw new MonopolyException("Бесценно!");
        public int RentaSummMinus => 1000;
        public int RentaSummPlus => 0;
    }
}