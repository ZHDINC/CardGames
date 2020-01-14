﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CardGames
{
    [DataContract]
    class Player : CardPlayer
    {
        [DataMember]
        private int currentfunds = 100;
        private int bet = 0;
        [DataMember]
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
            ScreenOperations.ClearGameLine(0, 15, 43);
            string betText = ($"You have ${Funds}. Bet: ");
            Console.Write(betText, Funds);
            int cursorPosition = betText.Length;
            bool possibleBet = false;
            bool formatexception = false;
            while (!possibleBet)
            {
                try
                {
                    Bet = Int32.Parse(Console.ReadLine());
                    formatexception = false;
                }
                catch(FormatException)
                {
                    formatexception = true;
                    ScreenOperations.ClearGameLine(0, 16, 45);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("You can only bet with digits!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    ScreenOperations.ClearGameLine(cursorPosition, 15, 23);
                }
                if(Bet > Funds && !formatexception)
                {
                    Console.SetCursorPosition(0, 16);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You can't spend money you don't have!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    ScreenOperations.ClearGameLine(cursorPosition, 15, 11);
                }
                if(Bet < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You can't bet a negative amount!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    ScreenOperations.ClearGameLine(cursorPosition, 15, 25);
                }
                else if(!formatexception)
                {
                    Console.SetCursorPosition(0, 16);
                    Console.WriteLine("                                     ");
                    possibleBet = true;
                }
            }
            Funds -= Bet;
        }

        public void Win()
        {
            ScreenOperations.ClearGameLine(0, 15, 39);
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
            ScreenOperations.ClearGameLine(0, 15, 39);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You lost the hand! You lost ${0}", Bet);
            Console.Write("                                 ");
            Console.SetCursorPosition(0, 16);
            Console.WriteLine("Funds: ${0}", Funds);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void Tie()
        {
            ScreenOperations.ClearGameLine(0, 15, 39);
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
