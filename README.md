# CardGames
Implemented Blackjack in C#. This is an initial attempt using concepts I know. 

--------------------------------------------------------

Initial Push 2/6/2019 12:18AM EST

Console application Blackjack. At this time, only hit and stay are implemented for the Player moves. There are a number of bugs that I found with the initial version that I coded, but it runs more or less as expected for a first version. There are potentially a few more bugs that I'll discover as I run it some more. 

I'm aware that I probably should've used an abstract class that Player and Dealer should've inherited from. Once I make sure that there aren't any bugs left, I will tidy up the code that I have (possibly implementing an abstract class for Player and Dealer to inherit from). 

After that, I need to implement either split or double as potential moves for the player.

Beyond that, the card drawing function of Deck could be improved as Random's unsuccessful attempts to choose a card (especially when most of the cards are drawn from the deck) slow down the program ever so slightly. 
--------------------------------------------------------

Second Major Revision 2/6/2019 8:55PM EST

Implemented abstract class, CardPlayer, that Dealer and Player classes inherit from resulting in similar code being in one place rather than two places. Cleaned up a few things and made some minor changes. There was a bug where the second card drawn from the initial draw being an Ace wasn't resolving to 11 (I was checking against the wrong variable). 

Unless there are any other bugs lying around, this version is mostly the complete game for a Console application. The only thing I'd like to change is the fact that the output is a little hard to follow at times. Might just change the color of the text output for the Player and Dealer as a first effort to make it easier to read.
