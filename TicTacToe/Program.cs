using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new Container();

            container.Register<IGame, MyGame>();
            container.Register<String, String>();

            var client = container.Create<IGame>(new object[] { "X" });

            client.Play(1);
            client.Play(2);

            client.Play(9);
            client.Play(5);

            client.Play(7);
            client.Play(4);

            client.Play(8);

            Console.WriteLine(client.Winner);
            Console.ReadLine();
        }
    }
}
