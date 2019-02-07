using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames
{
    class Dealer : CardPlayer
    {
        private int currentsum = 0;
        private bool highAce = false;
        private string name;

        public Dealer(string name) : base(name)
        {
            this.name = "Dealer";
        }
    }
}
