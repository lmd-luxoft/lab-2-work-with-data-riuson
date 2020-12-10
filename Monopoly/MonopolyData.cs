namespace Monopoly
{
    public class MonopolyData
    {
        public MonopolyData(
            bool canBuy,
            bool canHaveOwner,
            MonopolyType type,
            int buySumm,
            int rentaSummMinus,
            int rentaSummPlus)
        {
            CanBuy = canBuy;
            CanHaveOwner = canHaveOwner;
            Type = type;
            BuySumm = buySumm;
            RentaSummMinus = rentaSummMinus;
            RentaSummPlus = rentaSummPlus;
        }

        public bool CanBuy { get; }
        public bool CanHaveOwner { get; }
        public MonopolyType Type { get; }
        public int BuySumm { get; }
        public int RentaSummMinus { get; }
        public int RentaSummPlus { get; }
    }
}