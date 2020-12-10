using ChessBoard.Lib.Shared;

namespace ChessBoard {
    public class App {
        private readonly Board _board;
        private readonly IBoardDrawer _drawer;
        private readonly BoardInitializationData _initializationData;

        public App(
            Board board,
            BoardInitializationData initializationData,
            IBoardDrawer drawer) {
            this._board = board;
            this._initializationData = initializationData;
            this._drawer = drawer;
        }

        public void Run() {
            this._board.Initialize(this._initializationData);
            this._board.Drawer = this._drawer;
            this._board.Create();
            this._board.Draw();
        }
    }
}
