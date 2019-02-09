using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Blackjack";
            for (int i = 0; i < 35; i++)
                Console.Write("-");
            Console.Write("BLACKJACK");
            for (int i = 0; i < 36; i++)
                Console.Write("-");
            Console.SetCursorPosition(0, 15);
            Console.Write("Enter Player Name: ");
            string name = Console.ReadLine();
            Console.SetCursorPosition(0, 15);
            Console.Write("                                                 ");
            Player player = new Player(name);
            GameState blackjack = new GameState(player);
            while (blackjack.Turn()) ;
            Console.ReadLine();
        }
    }
}
