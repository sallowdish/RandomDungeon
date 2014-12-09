using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomDungeon
{
    class Program
    {
        static int maxWidth, maxHeight, seed;
        static void Main(string[] args)
        {
            //todo validate input
            //todo instant dungeon 
            //todo print dungeon
            //todo print seed

            //Validate the input and assgin to local variables
            try {
                validateInput(args);
                int.TryParse(args[0], out maxWidth);
                int.TryParse(args[1], out maxHeight);
                if (args.Length == 4) { int.TryParse(args[3], out seed); }
            }
            catch(IOException e){
                Console.WriteLine(e.Message);
                Console.WriteLine("Usage:\tRandomDungeon maxWidth maxHeight [-s seed]");
                Environment.Exit(-1);
            }
            try
            {


            }
            catch { }
        }

        static private bool validateInput(string[] args) {
            //validate # parameters
            if (args.Length != 2 && args.Length != 4) { throw new IOException("Invalid Input: Incorrect # parameters"); }
            //validate maxWidth and maxHeight
            int maxWidth, maxHeight;
            if (!(int.TryParse(args[0], out maxWidth) && int.TryParse(args[1], out maxHeight))) { throw new IOException("Invalid Input: Incorrect maxWidth or maxHeight value"); }
            if (args.Length == 4 && args[2] != "-s") { throw new IOException("Invalid Input: Incorrect seed flag"); }
            double seed;
            if (args.Length == 4 && !(double.TryParse(args[3], out seed))) { throw new IOException("Invalid Input: Incorrect seed value"); }
            return true;
        }
    }
}
