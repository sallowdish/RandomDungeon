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
        };
        public Dot[,] design=null;
        private List<Room> rooms=null;
        private List<Path> paths=null;
        private int dungeonMaxWeight=0;
        private int dungeonMaxHeight=0;
        private int numRooms=0;
        private int seed=-1;

        //default constructor
        //return a BluePrint instance with default values
        public BluePrint():base()
        {

        }

        //constructor with given initial values
        //return a BluePrint instance with given width and height values
        public BluePrint(int width, int height)
            : base(new Point(0,0),width,height)
        {
            this.dungeonMaxWeight = width;
            this.dungeonMaxHeight = height;
            this.design = new Dot[width, height];
        }

        //constructor with given initial values
        //return a BluePrint instance with given width, height values and number of rooms
        public BluePrint(int width, int height, int numRooms,int seed): this(width,height)
        {
            this.numRooms = numRooms;
            this.seed = seed;
            this.design = new Dot[width, height];
            //Draw(this);
            this.designDungeon();
        }

        private void designDungeon(){
            //if no seed is given, using current time as seed
            if (seed == -1) { seed = Environment.TickCount; }
            var generator = new Random(seed);

            //generate the rooms until rooms list contains enought rooms
            while(rooms==null || rooms.Count<numRooms){
                //randomlize x,y for origin 
                if (rooms == null) { rooms=new List<Room>(0);}
                int x = (int)(generator.Next() % dungeonMaxWeight*0.75);
                int y = (int)(generator.Next() % dungeonMaxHeight * 0.75);
                int roomWidth = (int)(generator.Next() % dungeonMaxWeight * 0.5+dungeonMaxWeight*0.1);
                int roomHeight = (int)(generator.Next() % dungeonMaxHeight * 0.5+dungeonMaxHeight*0.1);
                var testRoom = new Room(new Point(x,y), roomWidth, roomHeight);
                if (isRoomInDesign(testRoom)) { 
                    rooms.Add(testRoom);
                    testRoom.Draw(this);
                }
            }
        }

        //check if given room is within the design
        //return true if the room is entirely inside the desgin, false otherwise
        private bool isRoomInDesign(Room r)
        {
            return isPointInRoom(r.origin) && isPointInRoom(r.diagonalEnding);
        }
    }
}
