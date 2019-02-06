using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames
{
    class Player
    {
        private int currentsum = 0;
        private int currentfunds = 100;
        private string name;
        private bool highAce = false;

        public Player(string name)
        {
            this.name = name;
        }

        public Player()
        {

        }

        public int Sum
        {
            get { return currentsum; }
            set { currentsum = value; }
        }

        public bool HighAce
        {
            get { return highAce; }
            set { highAce = value; }
        }

        public void GetInitialCards(Deck current)
        {
            (int firstcard, string firstcardname, string firstcardsuit) = current.DrawCard();
            if(firstcardname == "Ace")
            {
                currentsum += 11;
                highAce = true;
            }
            else
            {
                currentsum += firstcard;
            }
            
            (int secondcard, string secondcardname, string secondcardsuit) = current.DrawCard();
            if(secondcardsuit == "Ace" && !highAce)
            {
                currentsum += 11;
                highAce = true;
            }
            else
            {
                currentsum += secondcard;
            }
            Console.WriteLine("Player Cards: {0} of {1} and {2} of {3}", firstcardname, firstcardsuit, secondcardname, secondcardsuit);
        }

        public void GetCard(Deck current)
        {
            bool normaldraw = true;
            (int drawn, string name, string suit) = current.DrawCard();
            if (name == "Ace" && highAce == false && currentsum < 11)
            {
                currentsum += 11;
                highAce = true;
                normaldraw = false;
            }
            Console.WriteLine("You drew: {0} of {1}", name, suit);
            if(normaldraw)
                currentsum += drawn;
            if(currentsum > 21 && highAce == true)
            {
                currentsum -= 10;
                highAce = false;
            }
        }
    }
}
