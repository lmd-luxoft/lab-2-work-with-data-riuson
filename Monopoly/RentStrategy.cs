namespace Monopoly
{
    internal class RentStrategy : IRentStrategy
    {
        public bool Rent(IPlayer renter, IAsset asset, IMonopolyType monopoly)
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