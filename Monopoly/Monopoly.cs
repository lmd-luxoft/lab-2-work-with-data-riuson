using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Monopoly
    {
        private List<PlayerInfo> _players = new List<PlayerInfo>();
        private List<FieldData> _fields = new List<FieldData>();

        public Monopoly(IEnumerable<string> names)
        {
            if ((names?.Any() ?? false) == false)
            {
                throw new MonopolyException("Список имён пуст.");
            }

            if (names.Distinct().Count() < names.Count())
            {
                throw new MonopolyException("Список имён содержит повторы.");
            }

            foreach (var name in names)
            {
                _players.Add(new PlayerInfo(name, 6000));
            }

            _fields.Add(new FieldData("Ford", Monopoly.Type.AUTO, 0, false));
            _fields.Add(new FieldData("MCDonald", Monopoly.Type.FOOD, 0, false));
            _fields.Add(new FieldData("Lamoda", Monopoly.Type.CLOTHER, 0, false));
            _fields.Add(new FieldData("Air Baltic", Monopoly.Type.TRAVEL, 0, false));
            _fields.Add(new FieldData("Nordavia", Monopoly.Type.TRAVEL, 0, false));
            _fields.Add(new FieldData("Prison", Monopoly.Type.PRISON, 0, false));
            _fields.Add(new FieldData("MCDonald", Monopoly.Type.FOOD, 0, false));
            _fields.Add(new FieldData("TESLA", Monopoly.Type.AUTO, 0, false));
        }

        public IEnumerable<PlayerInfo> Players => _players;

        public enum Type
        {
            AUTO,
            FOOD,
            CLOTHER,
            TRAVEL,
            PRISON,
            BANK
        }

        public IEnumerable<FieldData> Fields => _fields;

        public FieldData GetFieldByName(string name) =>
            _fields.FirstOrDefault(x => x.Name == name);

        public bool Buy(int playerNumber, FieldData k)
        {
            var x = GetPlayerInfo(playerNumber);

            int cash = 0;
            switch(k.Type)
            {
                case Type.AUTO:
                    if (k.Money != 0)
                        return false;
                    cash = x.Cash - 500;
                    _players[playerNumber - 1] = new PlayerInfo(x.Name, cash);
                    break;
                case Type.FOOD:
                    if (k.Money != 0)
                        return false;
                    cash = x.Cash - 250;
                    _players[playerNumber - 1] = new PlayerInfo(x.Name, cash);
                    break;
                case Type.TRAVEL:
                    if (k.Money != 0)
                        return false;
                    cash = x.Cash - 700;
                    _players[playerNumber - 1] = new PlayerInfo(x.Name, cash);
                    break;
                case Type.CLOTHER:
                    if (k.Money != 0)
                        return false;
                    cash = x.Cash - 100;
                    _players[playerNumber - 1] = new PlayerInfo(x.Name, cash);
                    break;
                default:
                    return false;
            }
            int i = _players.Select((item, index) => new { name = item.Name, index = index })
                .Where(n => n.name == x.Name)
                .Select(p => p.index).FirstOrDefault();
            _fields[i] = new FieldData(k.Name, k.Type, playerNumber, k.Flag);
             return true;
        }

        internal PlayerInfo GetPlayerInfo(int playerNumber)
        {
            if (playerNumber < 1 || playerNumber > _players.Count)
            {
                throw new MonopolyException("Неверный номер игрока.");
            }

            return _players[playerNumber - 1];
        }

        internal bool Renta(int playerNumber, FieldData data)
        {
            var z = GetPlayerInfo(playerNumber);
            PlayerInfo o = null;

            switch(data.Type)
            {
                case Type.AUTO:
                    if (data.Money == 0)
                        return false;
                    o =  GetPlayerInfo(data.Money);
                    z = new PlayerInfo(z.Name, z.Cash - 250);
                    o = new PlayerInfo(o.Name, o.Cash + 250);
                    break;
                case Type.FOOD:
                    if (data.Money == 0)
                        return false;
                    o = GetPlayerInfo(data.Money);
                    z = new PlayerInfo(z.Name, z.Cash - 250);
                    o = new PlayerInfo(o.Name, o.Cash + 250);

                    break;
                case Type.TRAVEL:
                    if (data.Money == 0)
                        return false;
                    o = GetPlayerInfo(data.Money);
                    z = new PlayerInfo(z.Name, z.Cash - 300);
                    o = new PlayerInfo(o.Name, o.Cash + 300);
                    break;
                case Type.CLOTHER:
                    if (data.Money == 0)
                        return false;
                    o = GetPlayerInfo(data.Money);
                    z = new PlayerInfo(z.Name, z.Cash - 100);
                    o = new PlayerInfo(o.Name, o.Cash + 1000);

                    break;
                case Type.PRISON:
                    z = new PlayerInfo(z.Name, z.Cash - 1000);
                    break;
                case Type.BANK:
                    z = new PlayerInfo(z.Name, z.Cash - 700);
                    break;
                default:
                    return false;
            }
            _players[playerNumber - 1] = z;
            if(o != null)
                _players[data.Money - 1] = o;
            return true;
        }
    }
}
