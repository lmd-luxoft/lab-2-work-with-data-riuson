using ChessBoard.Lib.Shared;

namespace ChessBoard.Lib.Implementation {
    internal class Board : IBoard {
        public IBoardDrawer Drawer { get; set; }

        public int HCells { get; private set; }
        public int VCells { get; private set; }

        public void SetSize(int hCells, int vCells) {
            this.HCells = hCells;
            this.VCells = vCells;
        }

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
