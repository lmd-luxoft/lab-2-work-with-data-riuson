namespace Monopoly
{
    public interface IMonopolyType
    {
        bool CanBuy { get; }
        bool CanHaveOwner { get; }
        MonopolyType Type { get; }
        int BuySumm { get; }
        int RentaSummMinus { get; }
        int RentaSummPlus { get; }
    }
}