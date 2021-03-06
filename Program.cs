﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using CommandLine.Text;

namespace RandomDungeon
{
    class Program
    {
        //help class for input validating
        class Options
        {
            [Option('w', "width",
              HelpText = "Maxium width for the dungeon.")]
            public int width { get; set; }

            [Option('h', "height",
              HelpText = "Maxium width for the dungeon.")]
            public int height { get; set; }


            [Option('s', "seed", Required = false, DefaultValue=-1,
              HelpText = "Seed to reproduce specific dungeon.")]
            public int seed { get; set; }

            [Option('c', "count", DefaultValue = 5, 
              HelpText = "Number of rooms in the dungeon.")]
            public int count { get; set; }

            [ParserState]
            public IParserState lastParserState { get; set; }

            [HelpOption]
            public string GetUsage()
            {
                var help = HelpText.AutoBuild(this, current => HelpText.DefaultParsingErrorsHandler(this, current));
                help.Copyright = new CopyrightInfo("<Rui Zheng>", 2014);

                help.Heading=new HeadingInfo("Usage: RandomDungeon.exe width height [-s seed] [-c num_rooms]"," ");

                return help;
            }
        }
        
        static int maxWidth, maxHeight, numRooms;
        static int seed=0;
        static void Main(string[] args)
        {
            //todo validate input
            //todo instant dungeon 
            //todo print dungeon
            //todo print seed

            //Validate the input and assgin to local variables
            var options = new Options();
            if (CommandLine.Parser.Default.ParseArguments(args, options))
            {
                try
                {
                    maxWidth = options.height;
                    maxHeight = options.width;
                    numRooms = options.count;
                    seed = options.seed;

                    //instantiate a dungeon
                    var blueprint = new BluePrint(maxWidth, maxHeight, numRooms, seed);
                    var dungeon = new Dungeon();

                    //print the dungeon
                    dungeon.Draw(blueprint);

                    Console.WriteLine("Seed used: "+blueprint.usedSeed);
                }
                //handle local variables assignment failure
                catch(IOException e) {
                    Console.WriteLine(e.Message);
                    Environment.Exit(-1);
                }
            }
            
        }

        static private bool validateInput(string[] args) {
            //validate # parameters
            if (args.Length != 2 && args.Length != 4) { throw new IOException("Invalid Input: Incorrect # parameters"); }
            //validate maxWidth and maxHeight
            int maxWidth, maxHeight;
            if (!(int.TryParse(args[0], out maxWidth) && int.TryParse(args[1], out maxHeight))) { throw new IOException("Invalid Input: Incorrect maxWidth or maxHeight value"); }
            if (args.Length == 4 && args[2] != "-s") { throw new IOException("Invalid Input: Incorrect seed flag"); }
            int seed;
            if (args.Length == 4 && !(int.TryParse(args[3], out seed))) { throw new IOException("Invalid Input: Incorrect seed value"); }
            return true;
        }
    }
}
