namespace Monopoly
{
    internal class BankMonopoly : IMonopolyType
    {
        public bool CanBuy => false;
        public bool HaveOwner => false;
        public Monopoly.Type Type => Monopoly.Type.BANK;
        public int BuySumm => throw new MonopolyException("Бесценно!");
        public int RentaSummMinus => 700;
        public int RentaSummPlus => 0;
    }
}