using ChessBoard.Lib.Shared;
using System;
using System.Collections.Generic;

namespace ChessBoard.ConsoleOutput.Implementation {
    public class BoardDrawer : IBoardDrawer {
        private const int CellSize = 5;

        // https://en.wikipedia.org/wiki/Chess_symbols_in_Unicode
        private readonly Dictionary<FigureType, char> _figuresWhite = new Dictionary<FigureType, char> {
            { FigureType.King, '♔' },
            { FigureType.Queen, '♕' },
            { FigureType.Rook, '♖' },
            { FigureType.Bishop, '♗' },
            { FigureType.Knight, '♘' },
            { FigureType.Pawn, '♙' }
        };

        private readonly Dictionary<FigureType, char> _figuresBlack = new Dictionary<FigureType, char> {
            { FigureType.King, '♚' },
            { FigureType.Queen, '♚' },
            { FigureType.Rook, '♜' },
            { FigureType.Bishop, '♝' },
            { FigureType.Knight, '♞' },
            { FigureType.Pawn, '♟' }
        };

        private int _hCells;
        private int _vCells;

        public void Create(int hCells, int vCells) {
            this._hCells = hCells;
            this._vCells = vCells;
        }

        public void Draw(IEnumerable<FigureAtPosition> figuresOnBoard) {
            Console.Clear();
            this.DrawBoard();
            this.DrawFigures(figuresOnBoard, CellSize);
        }

        protected virtual void DrawBoard() {
            /*
             * ░░░░░▓▓▓▓▓░░░░░▓▓▓▓▓░░░░░▓▓▓▓▓░░░░░▓▓▓▓▓
             * ░░░░░▓▓▓▓▓░░░░░▓▓▓▓▓░░░░░▓▓▓▓▓░░░░░▓▓▓▓▓
             * ▓▓▓▓▓░░░░░▓▓▓▓▓░░░░░▓▓▓▓▓░░░░░▓▓▓▓▓░░░░░
             * ▓▓▓▓▓░░░░░▓▓▓▓▓░░░░░▓▓▓▓▓░░░░░▓▓▓▓▓░░░░░
             * ░░░░░▓▓▓▓▓░░░░░▓▓▓▓▓░░░░░▓▓▓▓▓░░░░░▓▓▓▓▓
             * ░░░░░▓▓▓▓▓░░░░░▓▓▓▓▓░░░░░▓▓▓▓▓░░░░░▓▓▓▓▓
             * ▓▓▓▓▓░░░░░▓▓▓▓▓░░░░░▓▓▓▓▓░░░░░▓▓▓▓▓░░░░░
             * ▓▓▓▓▓░░░░░▓▓▓▓▓░░░░░▓▓▓▓▓░░░░░▓▓▓▓▓░░░░░
             * ░░░░░▓▓▓▓▓░░░░░▓▓▓▓▓░░░░░▓▓▓▓▓░░░░░▓▓▓▓▓
             * ░░░░░▓▓▓▓▓░░░░░▓▓▓▓▓░░░░░▓▓▓▓▓░░░░░▓▓▓▓▓
             * ▓▓▓▓▓░░░░░▓▓▓▓▓░░░░░▓▓▓▓▓░░░░░▓▓▓▓▓░░░░░
             * ▓▓▓▓▓░░░░░▓▓▓▓▓░░░░░▓▓▓▓▓░░░░░▓▓▓▓▓░░░░░
             * ░░░░░▓▓▓▓▓░░░░░▓▓▓▓▓░░░░░▓▓▓▓▓░░░░░▓▓▓▓▓
             * ░░░░░▓▓▓▓▓░░░░░▓▓▓▓▓░░░░░▓▓▓▓▓░░░░░▓▓▓▓▓
             * ▓▓▓▓▓░░░░░▓▓▓▓▓░░░░░▓▓▓▓▓░░░░░▓▓▓▓▓░░░░░
             * ▓▓▓▓▓░░░░░▓▓▓▓▓░░░░░▓▓▓▓▓░░░░░▓▓▓▓▓░░░░░
             */
            var even = false;

            for (var y = 0; y < this._vCells; y++) {
                for (var x = 0; x < this._hCells; x++) {
                    this.DrawCell(x, y, CellSize, even);
                    even = !even;
                }

                even = !even;
            }
        }

        protected virtual void DrawCell(int xPos, int yPos, int size, bool even) {
            for (var y = 0; y < size; y++) {
                for (var x = 0; x < size; x++) {
                    Console.SetCursorPosition(xPos * size + x, yPos * size + y);
                    Console.Write(even ? '▓' : '░');
                }
            }
        }

        protected virtual void DrawFigures(IEnumerable<FigureAtPosition> figuresOnBoard, int size) {
            foreach (var figureAtPosition in figuresOnBoard) {
                this.DrawFigure(figureAtPosition, size);
            }
        }

        protected virtual void DrawFigure(FigureAtPosition figure, int size) {
            Console.SetCursorPosition(figure.X * size, figure.Y * size);
            char ch;

            if (figure.Figure.Side == Side.Black) {
                ch = this._figuresBlack[figure.Figure.FigureType];
            } else {
                ch = this._figuresWhite[figure.Figure.FigureType];
            }

            Console.Write(ch);
        }
    }
}
