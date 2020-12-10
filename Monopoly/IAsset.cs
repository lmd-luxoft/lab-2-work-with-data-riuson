namespace Monopoly
{
    public interface IAsset
    {
        string Name { get; }
        MonopolyType Type { get; }
        Player Owner { get; set; }
        bool Flag { get; set; }
    }
}