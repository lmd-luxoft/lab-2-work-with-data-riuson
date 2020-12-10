using System.Collections.Generic;

namespace ChessBoard.Lib.Shared {
    public class BoardInitializationData {
        public virtual int HCells { get; } = 8;
        public virtual int VCells { get; } = 8;

        public virtual IEnumerable<FigureAtPosition> Figures {
            get {
                var result = new List<FigureAtPosition>();

                for (var x = 0; x < this.HCells; x++) {
                    result.Add(new FigureAtPosition(new Figure(FigureType.Pawn, Side.Black), x, 1));
                }

                var row0 = new[] {
                    FigureType.Rook,
                    FigureType.Knight,
                    FigureType.Bishop,
                    FigureType.Queen,
                    FigureType.King,
                    FigureType.Bishop,
                    FigureType.Knight,
                    FigureType.Rook
                };

                for (var x = 0; x < row0.Length; x++) {
                    result.Add(new FigureAtPosition(new Figure(row0[x], Side.Black), x, 0));
                    result.Add(new FigureAtPosition(new Figure(row0[x], Side.White), x, 7));
                }

                return result;
            }
        }
    }
}
