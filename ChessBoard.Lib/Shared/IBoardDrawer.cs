using System.Collections.Generic;

namespace ChessBoard.Lib.Shared {
    public interface IBoardDrawer {
        void Create(int hCells, int vCells);
        void Draw(IEnumerable<FigureAtPosition> figuresOnBoard);
    }
}
