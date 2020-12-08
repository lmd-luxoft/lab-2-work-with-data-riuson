namespace Monopoly
{
    public class FieldData
    {
        public FieldData(string name, Monopoly.Type type, int owner = 0, bool isFree = false)
        {
            Name = name;
            Type = type;
            Owner = owner;
            IsFree = isFree;
        }

        public string Name { get; }
        public Monopoly.Type Type { get; }
        public int Owner { get; }
        public bool IsFree { get; }

        public override bool Equals(object obj)
        {
            if (obj is FieldData c)
            {
                return c.Name == this.Name
                       && c.Type == this.Type
                       && c.Owner == this.Owner
                       && c.IsFree == this.IsFree;
            }

            return false;
        }
    }
}