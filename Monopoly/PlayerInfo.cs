namespace Monopoly
{
    public class PlayerInfo
    {
        public PlayerInfo(string name, int cash = 0)
        {
            this.Name = name;
            this.Cash = cash;
        }

        public int Cash { get; }
        public string Name { get; }

        public override bool Equals(object obj)
        {
            if (obj is PlayerInfo p)
            {
                return p.Name == this.Name && p.Cash == this.Cash;
            }

            return false;
        }
    }
}
