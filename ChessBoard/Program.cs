using Autofac;
using ChessBoard.ConsoleOutput.Implementation;
using ChessBoard.Lib.Shared;
using System.Reflection;

namespace ChessBoard {
    internal class Program {
        private static void Main(string[] args) {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterAssemblyTypes(
                    Assembly.GetExecutingAssembly(),
                    typeof(BoardDrawer).Assembly,
                    typeof(Board).Assembly
                ).AsSelf()
                .AsImplementedInterfaces();

            using (var container = containerBuilder.Build()) {
                var app = container.Resolve<App>();
                app.Run();
            }
        }
    }
}
