using ChessBoard.Lib.Shared;

namespace ChessBoard.Lib.Implementation {
    internal class Board : IBoard {
        public Board(int hCells, int vCells) {
            this.HCells = hCells;
            this.VCells = vCells;
        }

        public IBoardDrawer Drawer { get; set; }

        public int HCells { get; }
        public int VCells { get; }

        public void Create() {
            var drawer = this.Drawer ?? throw new ChessBoardException("Не указана реализация вывода!");
            drawer.Create(this.HCells, this.VCells);
        }

        public void Draw() {
            var drawer = this.Drawer ?? throw new ChessBoardException("Не указана реализация вывода!");
            drawer.Draw();
        }
    }
}
