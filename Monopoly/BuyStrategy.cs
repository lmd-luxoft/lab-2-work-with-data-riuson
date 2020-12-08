namespace Monopoly
{
    internal class BuyStrategy : IBuyStrategy
    {
        public bool Buy(IPlayer buyer, IAsset asset, IMonopolyType monopoly)
        {
            if (!monopoly.CanBuy) return false;

            if (asset.Owner != null) return false;

            buyer.Cash -= monopoly.BuySumm;
            asset.Owner = buyer;
            return true;
        }
    }
}