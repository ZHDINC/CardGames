using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames
{
    class GameState
    {
        private Deck deck = new Deck();
        private Player player;
        private Dealer dealer = new Dealer();
        private string hiddensecondcard;
        private bool playerbust = false;
        private bool dealerbust = false;

        public GameState(Player player)
        {
            this.player = player;
        }

        public Player Player
        {
            get { return player; }
        }

        public Deck Deck
        {
            get { return deck; }
            set { }
        }

        public Dealer Dealer
        {
            get { return dealer; }
        }

        public string HiddenString
        {
            get { return hiddensecondcard; }
            set { hiddensecondcard = value; }
        }

        public int PlayerTurn(bool playerplay)
        {
            
            Player.GetInitialCards(deck);
                
            int choice;
            while (playerplay)
            {
                Console.WriteLine("Your current sum: {0}", player.Sum);
                Console.WriteLine("1. Hit 2. Stay");
                choice = Int32.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        player.GetCard(deck);
                        if (Player.Sum > 21)
                        {
                            playerplay = false;
                            playerbust = true;
                        }
                        break;
                    case 2:
                        playerplay = false;
                        break;
                }
            }
            return Player.Sum;
        }
        public int DealerInitialTurn()
        {
            HiddenString = Dealer.GetInitialCards(deck);
            if (Dealer.Sum == 21)
            {
                Console.WriteLine("Dealer got Blackjack!");
            }
            return Dealer.Sum;
        }

        public int DealerTurn()
        {
            int currentsum = Dealer.Sum;
            bool dealerplay = true;
            while (dealerplay)
            {
                if(currentsum > 21)
                {
                    dealerplay = false;
                    dealerbust = true;
                }
                if(currentsum >= 17)
                {
                    dealerplay = false;
                    return currentsum;
                }
                else
                {
                    Dealer.GetCard(deck);
                    currentsum = Dealer.Sum;
                }
            }
            return Dealer.Sum;
        }
        public bool Turn()
        {
            int blackjack = DealerInitialTurn();
            bool playerturn = true;
            if(blackjack == 21)
            {
                playerturn = false;
            }
            int playersum = PlayerTurn(playerturn);
            Console.WriteLine(HiddenString);
            int dealersum = DealerTurn();
            Console.WriteLine("Player's Card Sum is: {0}", playersum);
            Console.WriteLine("Dealer's Card Sum is: {0}", dealersum);
            if((dealersum > playersum && !dealerbust) || playerbust)
            {
                Console.Write("You Lost! ");
                if(playerbust)
                    Console.WriteLine("You busted!");
                Console.WriteLine();
            }
            else if (dealersum < playersum || dealerbust)
            {
                Console.WriteLine("You Win!");
            }
            else
            {
                Console.WriteLine("Tie!");
            }
            Dealer.Sum = 0;
            Player.Sum = 0;
            Player.HighAce = false;
            Dealer.HighAce = false;
            dealerbust = false;
            playerbust = false;
            Deck.CardsNoLongerInPlay();
            Console.Write("Continue playing? 1. Yes 2. No 3. NOOOOOO!!!");
            bool correctinput = false;
            int choice = 1;
            while (!correctinput)
            {
                try
                {
                    choice = Int32.Parse(Console.ReadLine());
                    correctinput = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("I asked for a number!");
                }
            }
            switch(choice)
            {
                case 1:
                    return true;
                case 2:
                    return false;
                case 3:
                    Console.WriteLine("Don't let it get to you...");
                    return false;
                default:
                    Console.WriteLine("Not sure how to interpret that other than a ragequit...");
                    return false;

            }
        }
    }
}
