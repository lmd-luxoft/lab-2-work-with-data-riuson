using ChessBoard.Lib.Implementation;
using ChessBoard.Lib.Shared;
using Moq;
using NUnit.Framework;

namespace ChessBoard.Lib.Tests.Implementation {
    public class BoardTests {
        [Test]
        public void BoardShouldCreate() {
            // Arrange.
            var expectedHCells = 8;
            var expectedVCells = 8;
            var expectedCellWidth = 16;
            var expectedCellHeight = expectedCellWidth;

            var actualHCells = 0;
            var actualVCells = 0;
            var actualCellWidth = 0;
            var actualCellHeight = 0;

            var mockBoardDrawer = new Mock<IBoardDrawer>();
            mockBoardDrawer.Setup(x => x.Create(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
                .Callback<int, int, int, int>((a, b, c, d) => {
                    actualHCells = a;
                    actualVCells = b;
                    actualCellHeight = c;
                    actualCellWidth = d;
                })
                .Verifiable();

            var board = new Board(expectedHCells, expectedVCells, expectedCellWidth, expectedCellHeight);
            board.Drawer = mockBoardDrawer.Object;

            // Act.
            board.Create();

            // Assert.
            mockBoardDrawer.Verify(
                x => x.Create(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()),
                Times.Once);
            Assert.That(actualHCells, Is.EqualTo(expectedHCells));
            Assert.That(actualVCells, Is.EqualTo(expectedVCells));
            Assert.That(actualCellWidth, Is.EqualTo(expectedCellWidth));
            Assert.That(actualCellHeight, Is.EqualTo(expectedCellHeight));
        }

        [Test]
        public void BoardShouldDraw() {
            // Arrange.
            var expectedHCells = 8;
            var expectedVCells = 8;
            var expectedCellWidth = 16;
            var expectedCellHeight = expectedCellWidth;

            var mockBoardDrawer = new Mock<IBoardDrawer>();
            mockBoardDrawer.Setup(x => x.Draw())
                .Verifiable();

            var board = new Board(expectedHCells, expectedVCells, expectedCellWidth, expectedCellHeight);
            board.Drawer = mockBoardDrawer.Object;

            // Act.
            board.Draw();

            // Assert.
            mockBoardDrawer.Verify(x => x.Draw(), Times.Once);
        }

        [Test]
        public void BoardShouldFailCreateWithoutDrawer() {
            // Arrange.
            var expectedHCells = 8;
            var expectedVCells = 8;
            var expectedCellWidth = 16;
            var expectedCellHeight = expectedCellWidth;

            var board = new Board(expectedHCells, expectedVCells, expectedCellWidth, expectedCellHeight);

            // Act & Assert.
            Assert.Throws<ChessBoardException>(() => board.Create());
        }

        [Test]
        public void BoardShouldFailDrawWithoutDrawer() {
            // Arrange.
            var expectedHCells = 8;
            var expectedVCells = 8;
            var expectedCellWidth = 16;
            var expectedCellHeight = expectedCellWidth;

            var board = new Board(expectedHCells, expectedVCells, expectedCellWidth, expectedCellHeight);

            // Act & Assert.
            Assert.Throws<ChessBoardException>(() => board.Draw());
        }
    }
}
