using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp35
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();
        }
    }

    public class Game
    {
        private char[] board;
        private char currentPlayer;

        public Game()
        {
            board = new char[9];
            for (int i = 0; i < board.Length; i++)
            {
                board[i] = ' ';
            }
        }
        public void Start()
        {
            Random random = new Random();
            currentPlayer = random.Next(2) == 0 ? 'X' : 'O';
            Console.WriteLine($"Player one: {currentPlayer}");

            do
            {
                Console.Clear();
                DisplayBoard();
                PlayerMove();
                if (CheckWin())
                {
                    Console.Clear();
                    DisplayBoard();
                    Console.WriteLine($"Player {currentPlayer} won!");
                    return;
                }
                else if (IsBoardFull())
                {
                    Console.Clear();
                    DisplayBoard();
                    Console.WriteLine("Draw");
                    return;
                }
                currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
            } while (true);
        }

        private void DisplayBoard()
        {
            Console.WriteLine($"{board[0]} | {board[1]} | {board[2]}");
            Console.WriteLine("--|---|--");
            Console.WriteLine($"{board[3]} | {board[4]} | {board[5]}");
            Console.WriteLine("--|---|--");
            Console.WriteLine($"{board[6]} | {board[7]} | {board[8]}");
        }

        private void PlayerMove()
        {
            int move;
            while (true)
            {
                Console.Write($"Player {currentPlayer}, your move (0-8) :");
                if (int.TryParse(Console.ReadLine(), out move) && move >= 0 && move <= 8 && board[move] == ' ')
                {
                    board[move] = currentPlayer;
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong move, try again.");
                }
            }
        }

        private bool CheckWin()
        {
            int[,] winningCombinations =
            {
                { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 }, { 0, 4, 8 }, { 2, 4, 6 }
            };

            foreach (var combination in winningCombinations)
            {
                if (board[combination[0]] == currentPlayer && board[combination[1]] == currentPlayer && board[combination[2]] == currentPlayer)
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsBoardFull()
        {
            foreach (char  cell in board)
            {
                if (cell == ' ')
                {
                    return false;
                }
            }
            return true;
        }
    }
}
