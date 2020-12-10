using System.Collections.Generic;

namespace ChessBoard.Lib.Shared {
    public class Board {
        private Figure[,] _figures;

        public IBoardDrawer Drawer { get; set; }

        public int HCells { get; private set; }
        public int VCells { get; private set; }

        public void Initialize(BoardInitializationData initializationData) {
            this.HCells = initializationData.HCells;
            this.VCells = initializationData.VCells;

            this._figures = new Figure[initializationData.HCells, initializationData.VCells];

            for (var x = 0; x < initializationData.HCells; x++) {
                for (var y = 0; y < initializationData.VCells; y++) {
                    this._figures[x, y] = Figure.Empty;
                }
            }

            foreach (var item in initializationData.Figures) {
                this._figures[item.X, item.Y] = item.Figure;
            }
        }

        public void Create() {
            var drawer = this.Drawer ?? throw new ChessBoardException("Не указана реализация вывода!");
            drawer.Create(this.HCells, this.VCells);
        }

        public void Draw() {
            var drawer = this.Drawer ?? throw new ChessBoardException("Не указана реализация вывода!");
            drawer.Draw();
        }

        public Figure GetFigureAt(int x, int y) => this._figures[x, y];

        public IEnumerable<FigureAtPosition> GetFiguresOnBoard() {
            var result = new List<FigureAtPosition>();

            for (var x = 0; x < this.HCells; x++) {
                for (var y = 0; y < this.VCells; y++) {
                    if (!this._figures[x, y].IsEmpty) {
                        result.Add(new FigureAtPosition(this._figures[x, y], x, y));
                    }
                }
            }

            return result;
        }
    }
}
