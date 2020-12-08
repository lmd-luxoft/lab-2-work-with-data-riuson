namespace Monopoly
{
    internal class Asset : IAsset
    {
        public Asset(string name, MonopolyType type, IPlayer owner = null, bool flag = false)
        {
            Name = name;
            Type = type;
            Owner = owner;
            Flag = flag;
        }

        public string Name { get; }
        public MonopolyType Type { get; }
        public IPlayer Owner { get; set; }
        public bool Flag { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Asset c)
                return c.Name == Name &&
                       c.Type == Type &&
                       c.Owner == Owner &&
                       c.Flag == Flag;

            return false;
        }
    }
}