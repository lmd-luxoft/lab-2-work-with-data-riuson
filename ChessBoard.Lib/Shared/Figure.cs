namespace ChessBoard.Lib.Shared {
    public class Figure {
        public delegate Figure Factory(FigureType figureType, Side side);

        public Figure(FigureType figureType, Side side) {
            this.FigureType = figureType;
            this.Side = side;
        }

        public FigureType FigureType { get; }
        public Side Side { get; }

        public static Figure Empty => new Figure(FigureType.None, Side.None);

        public bool IsEmpty {
            get {
                if (this is null) {
                    throw new ChessBoardException("Объект Figure не должен быть null!");
                }

                return this.FigureType == FigureType.None || this.Side == Side.None;
            }
        }
    }
}
