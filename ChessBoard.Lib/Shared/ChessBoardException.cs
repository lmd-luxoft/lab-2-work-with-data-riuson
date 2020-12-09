using System;

namespace ChessBoard.Lib.Shared {
    public class ChessBoardException : Exception {
        public ChessBoardException(string message) : base(message) { }
    }
}
