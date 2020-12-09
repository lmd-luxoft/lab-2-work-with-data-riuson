namespace ChessBoard.Lib.Shared {
    public interface IBoard {
        int HCells { get; }
        int VCells { get; }

        void SetSize(int hCells, int vCells);

        IBoardDrawer Drawer { get; set; }

        void Create();
        void Draw();
    }
}
