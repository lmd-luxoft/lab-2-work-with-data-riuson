namespace Monopoly
{
    internal class RentStrategy : IRentStrategy
    {
        public bool Rent(Player renter, IAsset asset, MonopolyData monopoly)
        {
            if (monopoly.CanHaveOwner && asset.Owner == null) return false;

            if (monopoly.CanHaveOwner)
            {
                renter.Cash -= monopoly.RentaSummMinus;
                asset.Owner.Cash += monopoly.RentaSummPlus;
            }
            else
            {
                renter.Cash -= monopoly.RentaSummMinus;
            }

            return true;
        }
    }
}