using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames
{
    class Deck
    {
        private int[] Cards = CreateCards();
        private bool[] drawnStatus = new bool[52];
        private bool[] currentlyInPlay = new bool[52];
        private bool allcardsdrawn = false;
        private int cardcount = 52;

        private static int[] CreateCards()
        {
            int[] uninitializedDeck = new int[52];
            for(int i = 0; i < uninitializedDeck.Length; i++)
            {
                uninitializedDeck[i] = i + 1;
            }
            return uninitializedDeck;
        }
        
        public Deck() { }

        public int DrawSpecificCard(string name, int value)
        {
            int currentcard = GetCardActualIndex(name, value);
            Console.WriteLine(currentcard);
            if (currentcard >= 0 && currentcard <= 52)
            {
                if (drawnStatus[currentcard - 1] == false)
                {
                    drawnStatus[currentcard - 1] = true;
                    Console.WriteLine(Cards[currentcard - 1]);
                    return Cards[currentcard - 1];
                }
                else
                {
                    Console.WriteLine("Unable to draw that card!");
                }
            }
            return -1;
        }

        public int DrawActualCard()
        {
            Random x = new Random();
            bool successfuldraw = false;
            while(!successfuldraw)
            {
                int triedcard = x.Next(52);
                if(!drawnStatus[triedcard] && !currentlyInPlay[triedcard])
                {
                    drawnStatus[triedcard] = true;
                    currentlyInPlay[triedcard] = true;
                    returntodeck();
                    //Console.WriteLine(Cards[triedcard]);
                    successfuldraw = true;
                    return Cards[triedcard];
                }
                //Console.WriteLine("Unsuccessful. Retrying Random...");
            }
            return -1;
        }

        public (int, string, string) DrawCard()
        {
            int currentcard = DrawActualCard();
            string cardname = "";
            string suit = "";
            if(currentcard >= 1 && currentcard <= 13)
            {
                
                cardname = GetSpecialName(currentcard);
                suit = "Hearts";
                if(currentcard > 10)
                {
                    currentcard = 10;
                }
                return (currentcard, cardname, suit);
            }
            if (currentcard >= 14 && currentcard <= 26)
            {
                currentcard -= 13;
                cardname = GetSpecialName(currentcard);
                suit = "Spades";
                if(currentcard > 10)
                {
                    currentcard = 10;
                }
                return (currentcard, cardname, suit);
            }
            if(currentcard >= 27 && currentcard <= 39)
            {
                currentcard -= 26;
                cardname = GetSpecialName(currentcard);
                suit = "Clover";
                if(currentcard > 10)
                {
                    currentcard = 10;
                }
                return (currentcard, cardname, suit);
            }
            if(currentcard >= 40 && currentcard <= 52)
            {
                currentcard -= 39;
                cardname = GetSpecialName(currentcard);
                suit = "Diamonds";
                if(currentcard > 10)
                {
                    currentcard = 10;
                }
                return (currentcard, cardname, suit);
            }
            return (-1, "Failed", "Failed");
        }
        
        public int GetCardActualIndex(string name, int value)
        {
            name = name.ToUpper();
            switch(name)
            {
                case "HEARTS":
                case "HEART":
                    break;
                case "SPADE":
                case "SPADES":
                    value = value + 13;
                    break;
                case "CLUB":
                case "CLUBS":
                    value = value + 26;
                    break;
                case "DIAMONDS":
                case "DIAMOND":
                    value = value + 39;
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    return -1;
            }
            return value;
        }

        
        private void returntodeck()
        {
            cardcount--;
            if(cardcount == 0)
            {
                for (int i = 0; i < drawnStatus.Length; i++)
                    drawnStatus[i] = false;
            }
        }

        public void CardsNoLongerInPlay()
        {
            for(int i = 0; i < currentlyInPlay.Length; i++)
            {
                if (currentlyInPlay[i])
                    currentlyInPlay[i] = false;
            }
        }

        private string GetSpecialName(int currentcard)
        {
            if(currentcard == 1)
            {
                return "Ace";
            }
            if(currentcard == 11)
            {
                return "Jack";
            }
            if(currentcard == 12)
            {
                return "Queen";
            }
            if(currentcard == 13)
            {
                return "King";
            }
            return currentcard.ToString();
        }
    }
}
