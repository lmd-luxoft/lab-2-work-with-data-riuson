namespace Monopoly
{
    internal class BankMonopoly : IMonopolyType
    {
        public bool CanBuy => false;
        public bool CanHaveOwner => false;
        public MonopolyType Type => MonopolyType.Bank;
        public int BuySumm => throw new MonopolyException("Бесценно!");
        public int RentaSummMinus => 700;
        public int RentaSummPlus => 0;
    }
}