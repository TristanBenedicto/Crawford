using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public class MyGame : IGame
    {
        private string[] board;

        private string winner = string.Empty;

        private int turnCount;

        private string player;

        public MyGame(string startingPlayer)

        {
            player = startingPlayer;
            turnCount = 0;
            board = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        }
        
        // essential indexer
        public string this[int position]
        {
            get
            {
                return board[position - 1];
            }
        }

        // essential Winner
        public string Winner
        {
            get
            {
                return winner;
            }
        }

        // essential Play
        public bool Play(int position)
        {
            var result = true;

            if (position > 9)
            {
                result = false;
            }

            if (this[position] != "X" && this[position] != "O")
            {
                board[position - 1] = player;
                turnCount++;
                result = true;
            }
            else
            {
                result = false;
            }

            ShowBoardState();

            return result;
        }

        private void ShowBoardState()
        {
            Console.WriteLine("-------------------");
            Console.WriteLine("|  " + this[7] + "  |  " + this[8] + "  |  " + this[9] + "  |");
            Console.WriteLine("-------------------");
            Console.WriteLine("|  " + this[4] + "  |  " + this[5] + "  |  " + this[6] + "  |");
            Console.WriteLine("-------------------");
            Console.WriteLine("|  " + this[1] + "  |  " + this[2] + "  |  " + this[3] + "  |");
            Console.WriteLine("-------------------");

            if (!IsGameFinished())
            {
                FlipTurn();
            }
        }

        private bool IsGameFinished()
        {
            bool result = false;

            if ((this[7] == this[8] && this[8] == this[9]) ||
                (this[4] == this[5] && this[5] == this[6]) ||
                (this[1] == this[2] && this[2] == this[3]) ||
                (this[1] == this[4] && this[4] == this[7]) ||
                (this[2] == this[5] && this[5] == this[8]) ||
                (this[3] == this[6] && this[6] == this[9]) ||
                (this[1] == this[5] && this[5] == this[9]) ||
                (this[3] == this[5] && this[5] == this[7]))
            {
                winner = "Player " + player + " Won!";
                result = true;
            }
            else if (turnCount >= 9)
            {
                winner = "Cat’s Game!";
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }

        private void FlipTurn()
        {
            if (player == "X")
            {
                player = "O";
            }
            else
            {
                player = "X";
            }
        }

        private string RandomizePlayer()
        {
            var rnd = 1; //new Random().Next(0, 1);

            if (rnd == 0)
            {
                return "O";
            }
            else
            {
                return "X";
            }

        }

    }
}
