namespace Monopoly
{
    internal class PrisonMonopoly : IMonopolyType
    {
        public bool CanBuy => false;
        public bool CanHaveOwner => false;
        public MonopolyType Type => MonopolyType.Prison;
        public int BuySumm => throw new MonopolyException("Бесценно!");
        public int RentaSummMinus => 1000;
        public int RentaSummPlus => 0;
    }
}