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
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
        }

        void window_UpdateFrame(object sender, FrameEventArgs e)
        {
            
        }

        void window_RenderFrame(object sender, FrameEventArgs e)
        {
            GL.ClearColor(Color.CornflowerBlue);
            GL.Clear(ClearBufferMask.ColorBufferBit);

            GL.Begin(PrimitiveType.Triangles);

            GL.Color3(Color.Red);
            GL.Vertex2(0, 0);

            GL.Color3(Color.Green);
            GL.Vertex2(1, 0);

            GL.Color3(Color.Blue);
            GL.Vertex2(0, 1);

            // ---

            GL.Color4(1f, 0f, 0f, 0.5f);
            GL.Vertex2(-0.25f, 1);

            GL.Color4(0f, 1f, 0f, 0.5f);
            GL.Vertex2(1, -0.25f);

            GL.Color4(0f, 0f, 1f, 0.5f);
            GL.Vertex2(-0.25f, -0.25f);

            GL.End();

            window.SwapBuffers();
        }
    }
}
