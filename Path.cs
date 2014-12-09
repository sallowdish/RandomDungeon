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

        public Path() {
            start = new Point(0, 0);
            end = new Point(0, 0);
        }

        public Path(Point start, Point end) {
            this.start = start;
            this.end = end;
        }
    
public void Draw(BluePrint bluePrint)
{
 	throw new NotImplementedException();
}
}
}
