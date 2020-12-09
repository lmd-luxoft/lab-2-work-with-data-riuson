using ChessBoard.Lib.Shared;

namespace ChessBoard {
    public class App {
        private readonly IBoard _board;
        private readonly IBoardDrawer _drawer;

        public App(
            IBoard board,
            IBoardDrawer drawer) {
            this._board = board;
            this._drawer = drawer;
        }

        public void Run() {
            this._board.Drawer = this._drawer;
            this._board.SetSize(8, 8);

            this._board.Create();

            this._board.Draw();
        }
    }
}
