using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomDungeon
{
    class Dungeon : Drawing
    {
        public void Draw(BluePrint bluePrint)
        {
            for (int x = 0; x < bluePrint.width; x++)
            {
                for (int y = 0; y < bluePrint.height; y++)
                {
                    string symbol = "";
                    switch (bluePrint.storyboard[x, y])
                    {
                        case BluePrint.Dot.Void:
                            symbol = " ";
                            break;
                        case BluePrint.Dot.Vertical:
                            symbol = "|";
                            break;
                        case BluePrint.Dot.Horizontal:
                            symbol = "-";
                            break;
                        case BluePrint.Dot.EntryExit:
                            symbol = "*";
                            break;
                        case BluePrint.Dot.PathVertical:
                            symbol = "-";
                            break;
                        case BluePrint.Dot.PathHorizontal:
                            symbol = "|";
                            break;
                        case BluePrint.Dot.PathEntry:
                            symbol = " ";
                            break;
                        default:
                            symbol = "x";
                            break;
                    }
                    Console.Write(symbol);
                }
                Console.WriteLine("");
            }
        }
    }
}
