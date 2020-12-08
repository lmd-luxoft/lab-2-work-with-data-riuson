namespace Monopoly
{
    public interface IBuyStrategy
    {
        bool Buy(IPlayer buyer, IAsset asset, IMonopolyType monopoly);
    }
}