﻿using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject
{
    class Program
    {
        static void Main(string[] args)
        {
            GameWindow window = new GameWindow(800, 600, new OpenTK.Graphics.GraphicsMode(32, 8, 0, 8));

            Game game = new Game(window);

            window.Run(1.0 / 60.0);
        }
    }
}
