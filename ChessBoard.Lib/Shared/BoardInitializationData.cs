using System.Collections.Generic;

namespace ChessBoard.Lib.Shared {
    public class BoardInitializationData {
        public virtual int HCells { get; } = 8;
        public virtual int VCells { get; } = 8;

        public virtual IEnumerable<FigureAtPosition> Figures {
            get {
                throw new NotImplementedException();
            }
        }
    }
}
