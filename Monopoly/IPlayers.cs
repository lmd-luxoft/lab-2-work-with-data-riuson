using System.Collections.Generic;

namespace Monopoly
{
    public interface IPlayers : IEnumerable<IPlayer>
    {
        void Add(string name, int cash);
        IPlayer ByName(string name);
    }
}