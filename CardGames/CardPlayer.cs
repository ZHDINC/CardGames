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
        private int columnPosition;
        private string name;
        private int cardRowPosition = 0;

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

        public int ColumnPosition
        {
            get { return columnPosition; }
            set { columnPosition = value; }
        }

        public int CardRowPosition
        {
            get { return cardRowPosition; }
            set { cardRowPosition = value; }
        }

        public string Name
        {
            get { return name; }
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
            Console.SetCursorPosition(ColumnPosition, 2);
            Console.Write("{0} of {1}", firstcardname, firstcardsuit, this.name);
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
            string secondcardstring = $"{secondcardname} of {secondcardsuit}";
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
            Console.SetCursorPosition(ColumnPosition, 4 + CardRowPosition);
            Console.Write("{0} of {1}", name, suit, this.name);
            CardRowPosition++;
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
