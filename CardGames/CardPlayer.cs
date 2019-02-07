using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames
{
    abstract class CardPlayer
    {
        private int currentsum = 0;
        private bool highAce = false;
        private string name;

        public CardPlayer(string name)
        {
            this.name = name;
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

        public virtual string GetInitialCards(Deck current)
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
            Console.WriteLine("{2}'s First Card: {0} of {1}.", firstcardname, firstcardsuit, this.name);
            (int secondcard, string secondcardname, string secondcardsuit) = current.DrawCard();
            if (secondcardname == "Ace" && !highAce)
            {
                currentsum += 11;
                highAce = true;
            }
            else
            {
                currentsum += secondcard;
            }
            string secondcardstring = $"{this.name}'s Second Card: {secondcardname} of {secondcardsuit}";
            return secondcardstring;
        }

        public virtual void GetCard(Deck current)
        {
            bool normaldraw = true;
            (int drawn, string name, string suit) = current.DrawCard();
            if (name == "Ace" && highAce == false && currentsum < 11)
            {
                currentsum += 11;
                highAce = true;
                normaldraw = false;
            }
            Console.WriteLine("{2} drew: {0} of {1}", name, suit, this.name);
            if (normaldraw)
                currentsum += drawn;
            if (currentsum > 21 && highAce == true)
            {
                currentsum -= 10;
                highAce = false;
            }
        }
    }
}
