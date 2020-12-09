namespace ChessBoard.Lib.Shared {
    public interface IBoard {
        int HCells { get; }
        int VCells { get; }
        int CellWidth { get; }
        int CellHeight { get; }

        void Create();
        void Draw();
    }
}
