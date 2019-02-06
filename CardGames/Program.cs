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
            Deck blanky = new Deck();
            Console.Write("Enter Player Name: ");
            string name = Console.ReadLine();
            Player player = new Player(name);
            GameState blackjack = new GameState(blanky, player);
            bool continueplay = true;
            while(continueplay)
            {
                blackjack.Turn();
                Console.Write("Continue playing? ");
                continueplay = Boolean.Parse(Console.ReadLine());
            }
        }
    }
}
