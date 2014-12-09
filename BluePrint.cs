using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomDungeon
{
    class BluePrint : Drawing
    {
        private int[,] design=null;
        private Room[] rooms=null;
        private Path[] paths=null;
        private int width=0;
        private int height=0;
        private int numRooms=0;

        private const int MAX_NUM_ROOM=5;

        //default constructor
        //return a BluePrint instance with default values
        private BluePrint()
        {

        }

        //constructor with given initial values
        //return a BluePrint instance with given width and height values
        public BluePrint(int width, int height)
            : this()
        {
            this.width = width;
            this.height = height;
            this.numRooms = MAX_NUM_ROOM;
            this.design = new int[width, height];
        }

        //constructor with given initial values
        //return a BluePrint instance with given width and height values
        public BluePrint(int width, int height, int numRooms): this(width,height)
        {
            this.width = width;
            this.height = height;
            this.numRooms = MAX_NUM_ROOM;
            this.design = new int[width, height];
        }
        public void Draw(BluePrint bluePrint)
        {
            throw new NotImplementedException();
        }
    }
}
