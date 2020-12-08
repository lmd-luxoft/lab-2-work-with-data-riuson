namespace Monopoly
{
    internal class FoodMonopoly : IMonopolyType
    {
        public bool CanBuy => true;
        public bool CanHaveOwner => true;
        public MonopolyType Type => MonopolyType.Food;
        public int BuySumm => 250;
        public int RentaSummMinus => 250;
        public int RentaSummPlus => 250;
    }
}