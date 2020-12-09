using ChessBoard.Lib.Shared;

namespace ChessBoard.Lib.Implementation {
    internal class Board : IBoard {
        public Board(int hCells, int vCells, int cellWidth, int cellHeight) {
            this.HCells = hCells;
            this.VCells = vCells;
            this.CellWidth = cellWidth;
            this.CellHeight = cellHeight;
        }

        public IBoardDrawer Drawer { get; set; }

        public int HCells { get; }
        public int VCells { get; }
        public int CellWidth { get; }
        public int CellHeight { get; }

        public void Create() {
            var drawer = this.Drawer ?? throw new ChessBoardException("Не указана реализация вывода!");
            drawer.Create(this.HCells, this.VCells, this.CellWidth, this.CellHeight);
        }

        public void Draw() {
            var drawer = this.Drawer ?? throw new ChessBoardException("Не указана реализация вывода!");
            drawer.Draw();
        }
    }
}
