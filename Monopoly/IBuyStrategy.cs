namespace Monopoly
{
    public interface IBuyStrategy
    {
        bool Buy(Player buyer, IAsset asset, MonopolyData monopoly);
    }
}