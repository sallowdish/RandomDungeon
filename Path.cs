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
            // swap point start with end if start is lower than end
            if (start.Y > end.Y)
            {
                var p = start;
                start = end;
                end = p;
            }
        }

        //draw the path to storyboard
        //case A:
        // A--------M
        //          |
        //          B
        // OR
        //
        //case B:
        // A
        // |        
        // M--------B
        //return void;
        //return void;
        public void Draw(BluePrint bluePrint)
        {
            var generator = new Random(bluePrint.usedSeed);
            int isVerticalFirst = generator.Next() % 2;
            List<Point> pathTrail=new List<Point>(0);
            //caseA
            // A--------M(--------A)
            //          |
            //          B
            if (isVerticalFirst == 0)
            {
                //locate the point M(bigger X, smaller Y)
                Point M = new Point(end.X, start.Y);
                //draw line BM
                for (int y = M.Y; y < end.Y; y++)
                {
                    pathTrail.Add(new Point(M.X, y));
                }
                //A is on the right of M
                if (M.X < start.X)
                {
                    for (int x = M.X; x < start.X; x++)
                    {
                        pathTrail.Add(new Point(x, M.Y));
                    }
                }
                //A is on the left of M
                else
                {
                    for (int x = start.X; x < M.X; x++)
                    {
                        pathTrail.Add(new Point(x,M.Y));
                    }
                }

            }
            //caseA
            // A                 A
            // |                 |
            // M--------B--------M
            else
            {
                //locate the point M(smaller X, bigger Y)
                Point M = new Point(start.X, end.Y);
                //draw line AM
                for (int y = start.Y; y < M.Y; y++)
                {
                    pathTrail.Add(new Point(M.X,y));
                    //bluePrint.storyboard[M.X, y] = BluePrint.Dot.Path;
                }
                //draw line BM
                //B is on the right of M
                if (M.X < end.X)
                {
                    for (int x = M.X; x < end.X; x++)
                    {
                        pathTrail.Add(new Point(x,M.Y));
                        //bluePrint.storyboard[x, M.Y] = BluePrint.Dot.Path;
                    }
                }
                //B is on the left of M
                else
                {
                    for (int x = end.X; x < M.X; x++)
                    {
                        pathTrail.Add(new Point(x, M.Y));
                        //bluePrint.storyboard[x, M.Y] = BluePrint.Dot.Path;
                    }
                }
            }
            //check if p is not in/on any of exsiting room
            foreach (Point p in pathTrail)
            {

                //Debug
                bluePrint.storyboard[p.X, p.Y] = BluePrint.Dot.Path;

                //bool isInsideRoom = false,isOnRoom=false;
                //foreach (Room r in bluePrint.currentRooms)
                //{
                //    if(r.isPointInRoom(p)){
                //        isInsideRoom=true;
                //        break;
                //    }
                //    if (r.isPointOnRoom(p))
                //    {
                //        isOnRoom = true;
                //        break;
                //    }
                //}
                ////
                //if (!(isInsideRoom || isOnRoom)) {
                //    bluePrint.storyboard[p.X, p.Y] = BluePrint.Dot.Path;
                //}
                //else if (isOnRoom)
                //{
                //    bluePrint.storyboard[p.X, p.Y] = BluePrint.Dot.EntryExit;
                //}
                //else {
                
                //}
            }
        }
    }
}
