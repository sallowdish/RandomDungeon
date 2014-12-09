using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RandomDungeon
{
    class BluePrint : Room
    {
        public enum Dot
        {
            Void,
            Vertical,
            Horizontal,
            EntryExit,
            Path,
        };
        public Dot[,] storyboard = null;
        private List<Room> rooms = null;
        private List<Path> paths = null;
        private int dungeonMaxWeight = 0;
        private int dungeonMaxHeight = 0;
        private int numRooms = 0;
        private int seed = -1;

        //accessors
        public int usedSeed { get { return seed; } }
        public List<Room> currentRooms { get { return rooms; } }


        //default constructor
        //return a BluePrint instance with default values
        public BluePrint()
            : base()
        {

        }

        //constructor with given initial values
        //return a BluePrint instance with given width and height values
        public BluePrint(int width, int height)
            : base(new Point(0, 0), width, height)
        {
            this.dungeonMaxWeight = width;
            this.dungeonMaxHeight = height;
            this.storyboard = new Dot[width, height];
        }

        //constructor with given initial values
        //return a BluePrint instance with given width, height values and number of rooms
        public BluePrint(int width, int height, int numRooms, int seed)
            : this(width, height)
        {
            this.numRooms = numRooms;
            this.seed = seed;
            this.storyboard = new Dot[width, height];
            //Draw(this);
            this.designDungeon();
        }

        //fill up the storyboard according to given arguments
        //return void;
        private void designDungeon()
        {
            //if no seed is given, using current time as seed
            if (seed == -1) { seed = Environment.TickCount; }
            var generator = new Random(seed);
            generateRooms(generator);
            generatePaths();
            //eraseInSquarePoint();
        }

        //generate a number of rooms and try to fill up the room list
        //return void;
        private void generateRooms(Random generator) {
            //generate the rooms until rooms list contains enought rooms
            while (rooms == null || rooms.Count < numRooms)
            {
                //randomlize x,y for origin 
                if (rooms == null) { rooms = new List<Room>(0); }
                int x = (int)(generator.Next() % dungeonMaxWeight * 0.80);
                int y = (int)(generator.Next() % dungeonMaxHeight * 0.80);
                int roomWidth = (int)(generator.Next() % dungeonMaxWeight * 0.2 + dungeonMaxWeight * 0.15);
                int roomHeight = (int)(generator.Next() % dungeonMaxHeight * 0.2 + dungeonMaxHeight * 0.15);
                var testRoom = new Room(new Point(x, y), roomWidth, roomHeight);
                //validate if the testRoom is inside the storyboard
                if (isRoomInDesign(testRoom))
                {
                    bool isTooClose = false;
                    //test if the testRoom is too close to some exsiting room
                    foreach (Room room in rooms)
                    {
                        isTooClose = Math.Sqrt((room.anchorPoint.X - testRoom.anchorPoint.X) ^ 2 + (room.anchorPoint.Y - testRoom.anchorPoint.Y) ^ 2) < Math.Sqrt(width ^ 2 + height ^ 2) * 0.2;
                        if (isTooClose) { break; }
                    }
                    if (!isTooClose)
                    {
                        rooms.Add(testRoom);
                        testRoom.Draw(this);
                    }
                }
            }
        }

        //generate a number of rooms according to current room list
        //return void;
        private void generatePaths() {
            //connect each room to others
            int drawingCounter=0;
            if (paths == null) { paths = new List<Path>(0); }
            for (int i = 0; i < rooms.Count-1; i++)
            {
                for (int j = i+1; j < rooms.Count; j++)
                {
                    Path path = new Path(rooms[i].anchorPoint, rooms[j].anchorPoint);
                    paths.Add(path);
                    path.Draw(this);
                    Console.WriteLine("Drawing path:"+ ++drawingCounter+" start: "+path.start.ToString()+" end: "+path.end.ToString());
                }
            }
        }


        //check if given room is within the design
        //return true if the room is entirely inside the desgin, false otherwise
        private bool isRoomInDesign(Room r)
        {
            return isPointInRoom(r.origin) && isPointInRoom(r.diagonalEnding);
        }

        private void eraseInSquarePoint()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Point p = new Point(x, y);
                    foreach (Room room in rooms) {
                        if (room.isPointInRoom(p))
                        {
                            storyboard[x, y] = Dot.Void;
                            break;
                        }
                    }
                }
            }
        }
    }
}
