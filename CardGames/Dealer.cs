using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames
{
    class Dealer
    {
        private int currentsum = 0;
        private bool highAce = false;

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
        public string GetInitialCards(Deck current)
        {
            (int firstcard, string firstcardname, string firstcardsuit) = current.DrawCard();
            if (firstcardname == "Ace")
            {
                currentsum += 11;
                highAce = true;
            }
            else
            {
                currentsum += firstcard;
            }
            Console.WriteLine("Dealer's First Card: {0} of {1}.", firstcardname, firstcardsuit);
            (int secondcard, string secondcardname, string secondcardsuit) = current.DrawCard();
            if (secondcardsuit == "Ace" && !highAce)
            {
                currentsum += 11;
                highAce = true;
            }
            else
            {
                currentsum += secondcard;
            }
            string secondcardstring = $"Dealer's Second Card: {secondcardname} of {secondcardsuit}";
            return secondcardstring;
        }

        public void GetCard(Deck current)
        {
            Console.WriteLine("Dealer Sum = {0}.", Sum);
            bool normaldraw = true;
            (int drawn, string name, string suit) = current.DrawCard();
            if(name == "Ace" && highAce == false && currentsum < 11)
            {
                currentsum += 11;
                highAce = true;
                normaldraw = false;
            }
            Console.WriteLine("Dealer drew: {0} of {1}", name, suit);
            if(normaldraw)
                currentsum += drawn;
            if (currentsum > 21 && highAce == true)
            {
                currentsum -= 10;
                highAce = false;
            }
        }
    }
}
