using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames
{
    static class ScreenOperations
    {
        public static void ClearGameScreen()
        {
            Console.SetCursorPosition(0, 2);
            for (int i = 0; i <= 20; i++)
            {
                Console.WriteLine("                                               ");
            }
        }
    }
}
