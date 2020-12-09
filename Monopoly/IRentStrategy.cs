namespace Monopoly
{
    public interface IRentStrategy
    {
        bool Rent(IPlayer renter, IAsset asset, MonopolyData monopoly);
    }
}