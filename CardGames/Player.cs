using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames
{
    class Player : CardPlayer
    {
        private int currentfunds = 100;
        private int bet = 0;
        private string name;

        public Player(string name) : base(name)
        {
            this.name = name;
        }

        public int Funds
        {
            get { return currentfunds; }
            set { currentfunds = value; }
        }

        public int Bet
        {
            get { return bet; }
            set { bet = value; }
        }

        public void PlayerBet()
        {
            Console.SetCursorPosition(0, 15);
            Console.Write("                                           ");
            Console.SetCursorPosition(0, 15);
            string betText = ($"You have ${Funds}. Bet: ");
            Console.Write(betText, Funds);
            int cursorPosition = betText.Length;
            bool possibleBet = false;
            try
            {
                while (!possibleBet)
                {
                    Bet = Int32.Parse(Console.ReadLine());
                    if(Bet > Funds)
                    {
                        Console.SetCursorPosition(0, 16);
                        Console.WriteLine("You can't spend money you don't have!");
                        Console.SetCursorPosition(cursorPosition, 15);
                        Console.Write("           ");
                        Console.SetCursorPosition(cursorPosition, 15);
                    }
                    else
                    {
                        Console.SetCursorPosition(0, 16);
                        Console.WriteLine("                                     ");
                        possibleBet = true;
                    }
                }
            }
            catch(FormatException)
            {
                Console.WriteLine("Invalid input. ");
            }
            Funds -= Bet;
        }

        public void Win()
        {
            Console.SetCursorPosition(0, 15);
            Console.Write("                                       ");
            Console.SetCursorPosition(0, 15);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You won the hand! You received ${0}!", Bet * 2);
            Funds += Bet * 2;
            Console.Write("                                 ");
            Console.SetCursorPosition(0, 16);
            Console.WriteLine("Funds: ${0}", Funds);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void Lost()
        {
            Console.SetCursorPosition(0, 15);
            Console.Write("                                       ");
            Console.SetCursorPosition(0, 15);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You lost the hand! You lost ${0}", Bet);
            Console.Write("                                 ");
            Console.SetCursorPosition(0, 16);
            Console.WriteLine("Funds: ${0}", Funds);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void Tie()
        {
            Console.SetCursorPosition(0, 15);
            Console.Write("                                       ");
            Console.SetCursorPosition(0, 15);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("You tied the dealer! Got bet back!");
            Console.Write("                                    ");
            Console.SetCursorPosition(0, 16);
            Funds += Bet;
            Console.WriteLine("Funds: ${0}", Funds);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public int LostTheGame()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(0, 20);
            Console.WriteLine("You are out of money! You lost the session. ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Come back once you get more money from the ATM!");
            Console.WriteLine("...but since this is all make-believe...just run the game again! Lucky you!");
            return 2;
        }
    }
}
