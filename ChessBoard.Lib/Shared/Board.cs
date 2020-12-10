using System.Collections.Generic;

namespace ChessBoard.Lib.Shared {
    public class Board {
        public IBoardDrawer Drawer { get; set; }

        public int HCells { get; private set; }
        public int VCells { get; private set; }

        public void Initialize(BoardInitializationData initializationData) {
            this.HCells = initializationData.HCells;
            this.VCells = initializationData.VCells;
        }

        public void Create() {
            var drawer = this.Drawer ?? throw new ChessBoardException("Не указана реализация вывода!");
            drawer.Create(this.HCells, this.VCells);
        }

        public void Draw() {
            var drawer = this.Drawer ?? throw new ChessBoardException("Не указана реализация вывода!");
            drawer.Draw();
        }

        public Figure GetFigureAt(int x, int y) => throw new NotImplementedException();

        public IEnumerable<FigureAtPosition> GetFiguresOnBoard() => throw new NotImplementedException();
    }
}
