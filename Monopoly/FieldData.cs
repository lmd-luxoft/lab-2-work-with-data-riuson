namespace Monopoly
{
    public class FieldData
    {
        public FieldData(string name, Monopoly.Type type, int money = 0, bool flag = false)
        {
            Name = name;
            Type = type;
            Money = money;
            Flag = flag;
        }

        public string Name { get; }
        public Monopoly.Type Type { get; }
        public int Money { get; }
        public bool Flag { get; }

        public override bool Equals(object obj)
        {
            if (obj is FieldData c)
            {
                return c.Name == this.Name
                       && c.Type == this.Type
                       && c.Money == this.Money
                       && c.Flag == this.Flag;
            }

            return false;
        }
    }
}