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

        //default constructor
        //input: None
        //return: a Room instance at (0,0) with width and height equaling 0
        private Room() {
            origin = new Point(0, 0);
            width = 0;
            height = 0;
        }

        //constructor with width and height given
        //input: int width, int height
        //return: a Room at (0,0) with given width and height
        public Room(int width, int height) :this(){
            this.width = width;
            this.height = height;
        }

        //constructor with origin, width and height given
        //input: Point origin, int width, int height
        //return: a Room at given Origin with given width and height
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
