namespace ChessBoard.Lib.Shared {
    public interface IBoardDrawer {
        void Create(int hCells, int vCells, int cellWidth, int cellHeight);
        void Draw();
    }
}
