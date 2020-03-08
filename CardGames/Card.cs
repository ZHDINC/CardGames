using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CardGames
{
    [DataContract]
    public struct Card
    {
        [DataMember]
        private readonly int cardRawValue;
        [DataMember]
        private readonly string suitValue;
        [DataMember]
        private readonly string cardValue;
        [DataMember]
        private readonly ConsoleColor foregroundValue;
        [DataMember]
        private readonly ConsoleColor backgroundValue;
        [DataMember]
        private bool inPlay;
        [DataMember]
        private bool drawn;
        public int CardRawValue => cardRawValue;
        public string SuitValue => suitValue;

        public string CardValue => cardValue;
        public ConsoleColor ForegroundColor => foregroundValue;
        public ConsoleColor BackgroundColor => backgroundValue;
        public bool InPlay
        {
            get => inPlay;
            set => inPlay = value;
        }

        public bool Drawn
        {
            get => drawn;
            set => drawn = value;
        }

        public Card(int cardPassedInValue, string suitPassedInValue)
        {
            inPlay = false;
            drawn = false;
            backgroundValue = ConsoleColor.White;
            if (cardPassedInValue > 0 && cardPassedInValue < 14)
            {
                cardRawValue = cardPassedInValue;
            }
            else
            {
                throw new ArgumentException("Invalid card value");
            }
            if(suitPassedInValue == "Hearts" ||  suitPassedInValue == "Diamonds")
            {
                suitValue = suitPassedInValue;
                foregroundValue = ConsoleColor.Red;
            }
            else if(suitPassedInValue == "Spades" || suitPassedInValue == "Clubs")
            {
                suitValue = suitPassedInValue;
                foregroundValue = ConsoleColor.Black;
            }
            else
            {
                throw new ArgumentException("Invalid suit value");
            }
            switch(cardPassedInValue)
            {
                case 1:
                    cardValue = "Ace";
                    break;
                case 2: case 3: case 4: case 5: case 6: case 7: case 8: case 9: case 10:
                    cardValue = cardPassedInValue.ToString();
                    break;
                case 11:
                    cardValue = "Jack";
                    break;
                case 12:
                    cardValue = "Queen";
                    break;
                case 13:
                    cardValue = "King";
                    break;
                default:
                    cardValue = "Not a Card";
                    break;
            }
        }
    }
}
