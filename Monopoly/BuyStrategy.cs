﻿namespace Monopoly
{
    internal class BuyStrategy : IBuyStrategy
    {
        public bool Buy(Player buyer, IAsset asset, MonopolyData monopoly)
        {
            if (!monopoly.CanBuy) return false;

            if (asset.Owner != null) return false;

            buyer.Cash -= monopoly.BuySumm;
            asset.Owner = buyer;
            return true;
        }
    }
}