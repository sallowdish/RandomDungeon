using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RandomDungeon
{
    class Room : Drawing
    {
        public Point origin;
        public int width;
        public int height;
        private Point diagonalEnding;

        public Room() {
            origin = new Point(0, 0);
            width = 0;
            height = 0;
        }

        public Room(int width, int height) :this(){
            this.width = width;
            this.height = height;
        }

        public Room(Point origin, int width, int height)
            : this(width, height)
        {
            this.origin = origin;
        }

        public void Draw(BluePrint bluePrint)
        {
            throw new NotImplementedException();
        }
    }
}
