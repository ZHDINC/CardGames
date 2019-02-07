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
            Console.Write("Enter Player Name: ");
            string name = Console.ReadLine();
            Player player = new Player(name);
            GameState blackjack = new GameState(player);
            while (blackjack.Turn()) ;
            Console.ReadLine();
        }
    }
}
