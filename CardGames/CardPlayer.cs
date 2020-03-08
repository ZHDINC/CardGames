using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CardGames
{
    [DataContract]
    [KnownType(typeof(Player))]
    [KnownType(typeof(Dealer))]
    abstract class CardPlayer
    { 
        [DataMember]
        private int currentsum = 0;
        [DataMember]
        private bool highAce = false;
        [DataMember]
        private int columnPosition;
        [DataMember]
        private string name;
        [DataMember]
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
            Card firstCard = current.DrawCard();
            if (firstCard.CardValue == "Ace")
            {
                currentsum += 11;
                highAce = true;
            }
            else if(firstCard.CardValue == "Jack" || firstCard.CardValue == "Queen" || firstCard.CardValue == "King")
            {
                currentsum += 10;
            }
            else
            {
                currentsum += firstCard.CardRawValue;
            }
            Console.SetCursorPosition(ColumnPosition, 2);
            Console.BackgroundColor = firstCard.BackgroundColor;
            Console.ForegroundColor = firstCard.ForegroundColor;
            Console.Write("{0} of {1}", firstCard.CardValue, firstCard.SuitValue);
            Card secondCard = current.DrawCard();
            Console.BackgroundColor = secondCard.BackgroundColor;
            Console.ForegroundColor = secondCard.ForegroundColor;
            if (secondCard.CardValue == "Ace" && !highAce)
            {
                currentsum += 11;
                highAce = true;
            }
            else if (secondCard.CardValue == "Jack" || secondCard.CardValue == "Queen" || secondCard.CardValue == "King")
            {
                currentsum += 10;
            }
            else
            {
                currentsum += secondCard.CardRawValue;
            }
            string secondcardstring = $"{secondCard.CardValue} of {secondCard.SuitValue}";
            return secondcardstring;
        }

        public virtual void GetCard(Deck current)
        {
            bool normaldraw = true;
            Card currentCard = current.DrawCard();
            if (currentCard.CardValue == "Ace" && highAce == false && currentsum < 11)
            {
                currentsum += 11;
                highAce = true;
                normaldraw = false;
            }
            Console.ForegroundColor = currentCard.ForegroundColor;
            Console.BackgroundColor = currentCard.BackgroundColor;
            Console.SetCursorPosition(ColumnPosition, 4 + CardRowPosition);
            Console.Write("{0} of {1}", currentCard.CardValue, currentCard.SuitValue, this.name);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
            CardRowPosition++;
            if (normaldraw && !(currentCard.CardRawValue > 10))
                currentsum += currentCard.CardRawValue;
            else if (normaldraw)
            {
                currentsum += 10;
            }
            if (currentsum > 21 && highAce == true)
            {
                currentsum -= 10;
                highAce = false;
            }
        }
    }
}
