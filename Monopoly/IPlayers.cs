using System.Collections.Generic;

namespace Monopoly
{
    public interface IPlayers : IEnumerable<Player>
    {
        void Add(string name, int cash);
        Player ByName(string name);
    }
}