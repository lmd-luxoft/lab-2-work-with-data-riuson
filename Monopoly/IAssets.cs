using System.Collections.Generic;

namespace Monopoly
{
    public interface IAssets : IEnumerable<IAsset>
    {
        void Add(string name, MonopolyType type);
        IAsset ByName(string name);
    }
}