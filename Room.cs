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
        public Point diagonalEnding;
        public Point anchorPoint;

        //default constructor
        //input: None
        //return: a Room instance at (0,0) with width and height equaling 0
        public Room()
        {
            origin = new Point(0, 0);
            width = 0;
            height = 0;
            diagonalEnding = new Point(0, 0);
        }

        //constructor with origin, width and height given
        //input: Point origin, int width, int height
        //return: a Room at given Origin with given width and height
        public Room(Point origin, int width, int height)
            : this()
        {
            this.origin = origin;
            this.width = width;
            this.height = height;
            this.diagonalEnding = Point.Add(origin, new Size(width - 1, height - 1));
            this.anchorPoint = new Point(origin.X + (width / 2) - 1, origin.Y + (height / 2) - 1);
        }

        //check if the given point is inside current room
        //return: true if Point is inside the room, false otherwise
        public bool isPointInRoom(Point p)
        {
            //p.Offset(origin);
            p = Point.Subtract(p, new Size(origin.X, origin.Y));
            return 0 < p.X && p.X < width - 1 && p.Y > 0 && p.Y < height - 1;
        }

        //check if the given point is on the edge of current room
        //return: true if Point is  on the edge of the room, false otherwise
        public bool isPointOnRoom(Point p)
        {
            //p.Offset(origin);
            p = Point.Subtract(p, new Size(origin.X, origin.Y));
            return (p.X == 0 && p.Y > 0 && p.Y < height) || (p.Y == 0 && p.X > 0 && p.X < width);
        }


        //draw current room into given blueprint
        // A--------B
        // |        |
        // C--------D
        //return void;
        public void Draw(BluePrint bluePrint)
        {
            //locate the 4 anchor points
            Point A = origin;
            Point B = Point.Add(origin, new Size(width - 1, 0));
            Point C = Point.Add(origin, new Size(0, height - 1));
            Point D = diagonalEnding;
            //draw line AB
            for (int x = A.X; x < B.X + 1; x++)
            {
                bluePrint.storyboard[x, A.Y] = BluePrint.Dot.Horizontal;
            }
            //draw line CD
            for (int x = C.X; x < D.X + 1; x++)
            {
                bluePrint.storyboard[x, C.Y] = BluePrint.Dot.Horizontal;
            }
            //draw line AC
            for (int y = A.Y; y < C.Y + 1; y++)
            {
                bluePrint.storyboard[A.X, y] = BluePrint.Dot.Vertical;
            }
            //draw line BD
            for (int y = B.Y; y < D.Y + 1; y++)
            {
                bluePrint.storyboard[B.X, y] = BluePrint.Dot.Vertical;
            }
        }
    }
}
