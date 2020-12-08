namespace Monopoly
{
    public interface IAsset
    {
        string Name { get; }
        MonopolyType Type { get; }
        IPlayer Owner { get; set; }
        bool Flag { get; set; }
    }
}