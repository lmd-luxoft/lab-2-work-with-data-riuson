namespace Monopoly
{
    internal interface IMonopolyType
    {
        bool CanBuy { get; }
        bool HaveOwner { get; }
        Monopoly.Type Type { get; }
        int BuySumm { get; }
        int RentaSummMinus { get; }
        int RentaSummPlus { get; }
    }
}