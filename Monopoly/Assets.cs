using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Monopoly
{
    internal class Assets : IAssets
    {
        private readonly List<IAsset> _assets = new List<IAsset>();

        public void Add(string name, MonopolyType type)
        {
            if (_assets.Any(x => x.Name == name)) throw new MonopolyException("Имущество уже добавлено!");

            _assets.Add(new Asset(name, type));
        }

        public IAsset ByName(string name)
        {
            return _assets.FirstOrDefault(x => x.Name == name)
                   ?? throw new MonopolyException("Неизвестное имущество!");
        }

        public IEnumerator<IAsset> GetEnumerator()
        {
            return _assets.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}