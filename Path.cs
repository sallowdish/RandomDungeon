using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace RandomDungeon
{
    class Path : Drawing
    {
        public Point start;
        public Point end;

        //default constructor
        //return: a Path starting from (0,0) and ending at (0,0)
        private Path()
        {
            start = new Point(0, 0);
            end = new Point(0, 0);
        }

        //constructor with given start and end
        //return: a Path starting from and ending at given position
        public Path(Point start, Point end)
        {
            this.start = start;
            this.end = end;
        }

        public void Draw(BluePrint bluePrint)
        {
            throw new NotImplementedException();
        }
    }
}
