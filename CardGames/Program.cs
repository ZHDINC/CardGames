using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.IO;
using System.Xml;

namespace CardGames
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Load a saved game? (Y or N)");
            char loadgame = char.ToUpper(char.Parse(Console.ReadLine()));
            GameState savedGame = new GameState();
            bool successfulGameLoad = false;
            if(loadgame == 'Y')
            {
                DataContractSerializer dcsGameState = new DataContractSerializer(typeof(GameState));
                FileStream fs = new FileStream("gamestate.xml", FileMode.Open);
                XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
                savedGame = (GameState)dcsGameState.ReadObject(reader);
                fs.Close();
                successfulGameLoad = true;
            }
            Console.Title = "Blackjack";
            for (int i = 0; i < 35; i++)
                Console.Write("-");
            Console.Write("BLACKJACK");
            for (int i = 0; i < 36; i++)
                Console.Write("-");
            if (!successfulGameLoad)
            {
                Console.SetCursorPosition(0, 15);
                Console.Write("Enter Player Name: ");
                string name = Console.ReadLine();
                ScreenOperations.ClearGameLine(0, 15, 49);
                Player player = new Player(name);
                GameState blackjack = new GameState(player);
                while (blackjack.Turn()) ;
                FileStream fs = new FileStream("gamestate.xml", FileMode.Create);
                DataContractSerializer dcsGameState = new DataContractSerializer(typeof(GameState));
                XmlDictionaryWriter xdw = XmlDictionaryWriter.CreateTextWriter(fs, Encoding.UTF8);
                dcsGameState.WriteObject(xdw, blackjack);
                xdw.Flush();
            }
            else
            {
                while (savedGame.Turn()) ;
                FileStream fs = new FileStream("gamestate.xml", FileMode.Create);
                DataContractSerializer dcsGameState = new DataContractSerializer(typeof(GameState));
                XmlDictionaryWriter xdw = XmlDictionaryWriter.CreateTextWriter(fs, Encoding.UTF8);
                dcsGameState.WriteObject(xdw, savedGame);
                xdw.Flush();
            }
            Console.ReadLine();
        }
    }
}
