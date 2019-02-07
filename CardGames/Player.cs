using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames
{
    class Player : CardPlayer
    {
        private int currentfunds = 100;
        private string name;

        public Player(string name) : base(name)
        {
            this.name = name;
        }
    }
}
