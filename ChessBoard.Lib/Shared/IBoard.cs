namespace ChessBoard.Lib.Shared {
    public interface IBoard {
        int HCells { get; }
        int VCells { get; }

        void SetSize(int hCells, int vCells);

        void Create();
        void Draw();
    }
}
