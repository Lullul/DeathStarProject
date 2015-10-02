using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MountainTree
{
    public struct Texture2D
    {
        public Texture2D(int id, int width, int height)
        {
            this.id = id;
            this.width = width;
            this.height = height;
        }

        private int id;
        private int width, height;

        public int ID { get { return id; } }
        public int Width { get { return width; } }
        public int Height { get { return height; } }
    }
}
