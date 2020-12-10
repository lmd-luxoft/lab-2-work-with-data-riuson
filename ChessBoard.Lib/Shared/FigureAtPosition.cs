namespace ChessBoard.Lib.Shared {
    public class FigureAtPosition {
        public FigureAtPosition(Figure figure, int x, int y) {
            this.Figure = figure;
            this.X = x;
            this.Y = y;
        }

        public Figure Figure { get; }
        public int X { get; }
        public int Y { get; }
    }
}
