namespace Monopoly
{
    public class Player
    {
        public Player(string name, int cash = 0)
        {
            Name = name;
            Cash = cash;
        }

        public int Cash { get; set; }
        public string Name { get; }

        public override bool Equals(object obj)
        {
            if (obj is Player p) return p.Name == Name && p.Cash == Cash;

            return false;
        }
    }
}