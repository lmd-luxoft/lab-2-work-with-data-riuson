using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Monopoly
{
    internal class Players : IPlayers
    {
        private readonly List<Player> _players = new List<Player>();

        public IEnumerator<Player> GetEnumerator()
        {
            return _players.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(string name, int cash)
        {
            if (_players.Any(x => x.Name == name)) throw new MonopolyException("Игрок уже добавлен!");

            _players.Add(new Player(name, cash));
        }

        public Player ByName(string name)
        {
            return _players.FirstOrDefault(x => x.Name == name)
                   ?? throw new MonopolyException("Неизвестный игрок.");
        }
    }
}