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
        private int seed=-1;

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
            this.design = new int[width, height];
        }

        //constructor with given initial values
        //return a BluePrint instance with given width, height values and number of rooms
        public BluePrint(int width, int height, int numRooms,int seed): this(width,height)
        {
            this.numRooms = numRooms;
            this.seed = seed;
            this.design = new int[width, height];
            this.designDungeon();
        }

        private void designDungeon(){
            if (seed == -1) { seed = Environment.TickCount; }
            var generator = new Random(seed);
        }
        public void Draw(BluePrint bluePrint)
        {
            throw new NotImplementedException();
        }
    }
}
