namespace ChessBoard.Lib.Shared {
    public interface IBoard {
        int HCells { get; }
        int VCells { get; }

        void Create();
        void Draw();
    }
}
