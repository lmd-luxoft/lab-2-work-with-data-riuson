namespace Monopoly
{
    public interface IRentStrategy
    {
        bool Rent(Player renter, IAsset asset, MonopolyData monopoly);
    }
}