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
    }
}
