using ChessBoard.Lib.Shared;
using Moq;
using NUnit.Framework;
using System.Linq;

namespace ChessBoard.Lib.Tests.Implementation {
    public class BoardTests {
        [Test]
        public void BoardShouldCreate() {
            // Arrange.
            var actualHCells = 0;
            var actualVCells = 0;
            var initializationData = new BoardInitializationData();

            var mockBoardDrawer = new Mock<IBoardDrawer>();
            mockBoardDrawer.Setup(x => x.Create(It.IsAny<int>(), It.IsAny<int>()))
                .Callback<int, int>((a, b) => {
                    actualHCells = initializationData.HCells;
                    actualVCells = initializationData.VCells;
                })
                .Verifiable();

            var board = new Board();
            board.Initialize(initializationData);
            board.Drawer = mockBoardDrawer.Object;

            // Act.
            board.Create();

            // Assert.
            mockBoardDrawer.Verify(
                x => x.Create(It.IsAny<int>(), It.IsAny<int>()),
                Times.Once);
            Assert.That(actualHCells, Is.EqualTo(initializationData.HCells));
            Assert.That(actualVCells, Is.EqualTo(initializationData.VCells));
        }

        [Test]
        public void BoardShouldDraw() {
            // Arrange.
            var mockBoardDrawer = new Mock<IBoardDrawer>();
            mockBoardDrawer.Setup(x => x.Draw())
                .Verifiable();

            var board = new Board();
            board.Drawer = mockBoardDrawer.Object;

            // Act.
            board.Draw();

            // Assert.
            mockBoardDrawer.Verify(x => x.Draw(), Times.Once);
        }

        [Test]
        public void BoardShouldFailCreateWithoutDrawer() {
            // Arrange.
            var board = new Board();

            // Act & Assert.
            Assert.Throws<ChessBoardException>(() => board.Create());
        }

        [Test]
        public void BoardShouldFailDrawWithoutDrawer() {
            // Arrange.
            var board = new Board();

            // Act & Assert.
            Assert.Throws<ChessBoardException>(() => board.Draw());
        }

        [Test]
        public void BoardShouldInitializeEmpty() {
            // Arrange.
            var mockInitializationData = new Mock<BoardInitializationData>();
            mockInitializationData.SetupGet(x => x.HCells).Returns(8);
            mockInitializationData.SetupGet(x => x.VCells).Returns(8);
            mockInitializationData.SetupGet(x => x.Figures).Returns(new FigureAtPosition[] { });

            var board = new Board();

            // Act.
            board.Initialize(mockInitializationData.Object);

            // Assert.
            Assert.That(board.GetFiguresOnBoard().Count(), Is.Zero);
        }

        [Test]
        public void BoardShouldInitialize() {
            // Arrange.
            var mockInitializationData = new Mock<BoardInitializationData>();
            var figures = new[] {
                new FigureAtPosition(new Figure(FigureType.Pawn, Side.Black), 0, 1),
                new FigureAtPosition(new Figure(FigureType.Pawn, Side.White), 0, 6)
            };
            mockInitializationData.SetupGet(x => x.HCells).Returns(8);
            mockInitializationData.SetupGet(x => x.VCells).Returns(8);
            mockInitializationData.SetupGet(x => x.Figures).Returns(figures);

            var board = new Board();

            // Act.
            board.Initialize(mockInitializationData.Object);

            // Assert.
            Assert.That(board.GetFiguresOnBoard().Count(), Is.EqualTo(2));
            Assert.That(board.GetFigureAt(0, 1).FigureType, Is.EqualTo(FigureType.Pawn));
            Assert.That(board.GetFigureAt(0, 6).FigureType, Is.EqualTo(FigureType.Pawn));
            Assert.That(board.GetFigureAt(0, 1).Side, Is.EqualTo(Side.Black));
            Assert.That(board.GetFigureAt(0, 6).Side, Is.EqualTo(Side.White));
        }
    }
}
