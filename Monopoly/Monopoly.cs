using System.Collections.Generic;
using System.Linq;

namespace Monopoly
{
    public class Monopoly
    {
        public enum Type
        {
            AUTO,
            FOOD,
            CLOTHER,
            TRAVEL,
            PRISON,
            BANK
        }

        private readonly List<FieldData> _fields = new List<FieldData>();
        private readonly Dictionary<Type, IMonopolyType> _monopolies;
        private readonly List<PlayerInfo> _players = new List<PlayerInfo>();

        public Monopoly(IEnumerable<string> names)
        {
            if ((names?.Any() ?? false) == false) throw new MonopolyException("Список имён пуст.");

            if (names.Distinct().Count() < names.Count()) throw new MonopolyException("Список имён содержит повторы.");

            foreach (var name in names) _players.Add(new PlayerInfo(name, 6000));

            _monopolies = new IMonopolyType[]
            {
                new AutoMonopoly(),
                new FoodMonopoly(),
                new ClotherMonopoly(),
                new TravelMonopoly(),
                new PrisonMonopoly(),
                new BankMonopoly()
            }.ToDictionary(x => x.Type);

            _fields.Add(new FieldData("Ford", Type.AUTO));
            _fields.Add(new FieldData("MCDonald", Type.FOOD));
            _fields.Add(new FieldData("Lamoda", Type.CLOTHER));
            _fields.Add(new FieldData("Air Baltic", Type.TRAVEL));
            _fields.Add(new FieldData("Nordavia", Type.TRAVEL));
            _fields.Add(new FieldData("Prison", Type.PRISON));
            _fields.Add(new FieldData("MCDonald", Type.FOOD));
            _fields.Add(new FieldData("TESLA", Type.AUTO));
        }

        public IEnumerable<PlayerInfo> Players => _players;

        public IEnumerable<FieldData> Fields => _fields;

        public FieldData GetFieldByName(string name)
        {
            return _fields.FirstOrDefault(x => x.Name == name);
        }

        public bool Buy(int playerNumber, FieldData k)
        {
            var x = GetPlayerInfo(playerNumber);
            var cash = 0;

            var monopoly = _monopolies[k.Type];

            if (monopoly.CanBuy)
            {
                if (k.Owner != 0) return false;

                cash = x.Cash - monopoly.BuySumm;
                _players[playerNumber - 1] = new PlayerInfo(x.Name, cash);
            }

            /*
            switch(k.Type)
            {
                case Type.AUTO:
                    if (k.Owner != 0)
                        return false;
                    cash = x.Cash - 500;
                    _players[playerNumber - 1] = new PlayerInfo(x.Name, cash);
                    break;
                case Type.FOOD:
                    if (k.Owner != 0)
                        return false;
                    cash = x.Cash - 250;
                    _players[playerNumber - 1] = new PlayerInfo(x.Name, cash);
                    break;
                case Type.TRAVEL:
                    if (k.Owner != 0)
                        return false;
                    cash = x.Cash - 700;
                    _players[playerNumber - 1] = new PlayerInfo(x.Name, cash);
                    break;
                case Type.CLOTHER:
                    if (k.Owner != 0)
                        return false;
                    cash = x.Cash - 100;
                    _players[playerNumber - 1] = new PlayerInfo(x.Name, cash);
                    break;
                default:
                    return false;
            }*/
            var i = _players.Select((item, index) => new {name = item.Name, index})
                .Where(n => n.name == x.Name)
                .Select(p => p.index).FirstOrDefault();
            _fields[i] = new FieldData(k.Name, k.Type, playerNumber, k.IsFree);
            return true;
        }

        internal PlayerInfo GetPlayerInfo(int playerNumber)
        {
            if (playerNumber < 1 || playerNumber > _players.Count)
                throw new MonopolyException("Неверный номер игрока.");

            return _players[playerNumber - 1];
        }

        internal bool Renta(int playerNumber, FieldData data)
        {
            var z = GetPlayerInfo(playerNumber);
            PlayerInfo o = null;

            var monopoly = _monopolies[data.Type];

            if (monopoly.HaveOwner && data.Owner == 0) return false;

            if (monopoly.HaveOwner)
            {
                o = GetPlayerInfo(data.Owner);
                z = new PlayerInfo(z.Name, z.Cash - monopoly.RentaSummMinus);
                o = new PlayerInfo(o.Name, o.Cash + monopoly.RentaSummPlus);
            }
            else
            {
                z = new PlayerInfo(z.Name, z.Cash - monopoly.RentaSummMinus);
            }

            /*
            switch(data.Type)
            {
                case Type.AUTO:
                    if (data.Owner == 0)
                        return false;
                    o =  GetPlayerInfo(data.Owner);
                    z = new PlayerInfo(z.Name, z.Cash - 250);
                    o = new PlayerInfo(o.Name, o.Cash + 250);
                    break;
                case Type.FOOD:
                    if (data.Owner == 0)
                        return false;
                    o = GetPlayerInfo(data.Owner);
                    z = new PlayerInfo(z.Name, z.Cash - 250);
                    o = new PlayerInfo(o.Name, o.Cash + 250);

                    break;
                case Type.TRAVEL:
                    if (data.Owner == 0)
                        return false;
                    o = GetPlayerInfo(data.Owner);
                    z = new PlayerInfo(z.Name, z.Cash - 300);
                    o = new PlayerInfo(o.Name, o.Cash + 300);
                    break;
                case Type.CLOTHER:
                    if (data.Owner == 0)
                        return false;
                    o = GetPlayerInfo(data.Owner);
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
            */

            _players[playerNumber - 1] = z;
            if (o != null)
                _players[data.Owner - 1] = o;
            return true;
        }
    }
}