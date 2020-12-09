using System;
using ChessBoard.Lib.Shared;

namespace ChessBoard.Lib.Implementation {
    internal class Board : IBoard {
        public Board(int hCells, int vCells, int cellWidth, int cellHeight) {
        }

        public IBoardDrawer Drawer { get; set; }

        public int HCells { get; }
        public int VCells { get; }
        public int CellWidth { get; }
        public int CellHeight { get; }

        public void Create() {
            throw new NotImplementedException();
        }

        public void Draw() {
            throw new NotImplementedException();
        }
    }
}
