using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject
{
    class Game
    {
        GameWindow window;
        public Game(GameWindow window)
        {
            this.window = window;

            window.Load += window_Load;
            window.UpdateFrame += window_UpdateFrame;
            window.RenderFrame += window_RenderFrame;
        }

        void window_Load(object sender, EventArgs e)
        {
            
        }

        void window_UpdateFrame(object sender, FrameEventArgs e)
        {
            
        }

        void window_RenderFrame(object sender, FrameEventArgs e)
        {
            GL.ClearColor(Color.CornflowerBlue);
            GL.Clear(ClearBufferMask.ColorBufferBit);

            window.SwapBuffers();
        }
    }
}
