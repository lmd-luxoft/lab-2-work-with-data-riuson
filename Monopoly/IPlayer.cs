namespace Monopoly
{
    public interface IPlayer
    {
        string Name { get; }
        int Cash { get; set; }
    }
}