namespace ChessBoard.Lib.Shared {
    public interface IBoard {
        int HCells { get; }
        int VCells { get; }

        IBoardDrawer Drawer { get; set; }

        void SetSize(int hCells, int vCells);

        void Create();
        void Draw();
    }
}
