namespace Monopoly
{
    internal class FoodMonopoly : IMonopolyType
    {
        public bool CanBuy => true;
        public bool HaveOwner => true;
        public Monopoly.Type Type => Monopoly.Type.FOOD;
        public int BuySumm => 250;
        public int RentaSummMinus => 250;
        public int RentaSummPlus => 250;
    }
}