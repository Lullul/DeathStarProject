using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MountainTree;
using MainProject.PipeLines;

namespace MainProject
{
    class Game
    {
        GameWindow window;

        Texture2D texture;

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
            
            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Lequal);

            GL.Enable(EnableCap.Texture2D);

            texture = ContentPipe.LoadTexture("Resources/img/varning.jpg");
        }

        void window_UpdateFrame(object sender, FrameEventArgs e)
        {
            
        }

        void window_RenderFrame(object sender, FrameEventArgs e)
        {
            GL.ClearColor(Color.CornflowerBlue);
            GL.ClearDepth(1);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.BindTexture(TextureTarget.Texture2D, texture.ID);

            GL.Begin(PrimitiveType.Triangles);

            GL.Color4(1f, 1f, 1f, 1f);
            GL.TexCoord2(0, 0); GL.Vertex2(0, 1);
            GL.TexCoord2(1, 1); GL.Vertex2(1, 0);
            GL.TexCoord2(0, 1); GL.Vertex2(0, 0);

            GL.TexCoord2(0, 0); GL.Vertex2(0, 1);
            GL.TexCoord2(1, 0); GL.Vertex2(1, 1);
            GL.TexCoord2(1, 1); GL.Vertex2(1, 0);

            //GL.Color3(Color.Red);
            //GL.Vertex3(0, 0, 0.5f);

            //GL.Color3(Color.Green);
            //GL.Vertex3(1, 0, 0.5f);

            //GL.Color3(Color.Blue);
            //GL.Vertex3(0, 1, 0.5f);

            //// --- 

            //GL.Color4(1f, 0f, 0f, 0.5f);
            //GL.Vertex3(-0.25f, 1, 0.8f);

            //GL.Color4(0f, 1f, 0f, 0.5f);
            //GL.Vertex3(1, -0.25f, 0.8f);

            //GL.Color4(0f, 0f, 1f, 0.5f);
            //GL.Vertex3(-0.25f, -0.25f, 0.8f);

            GL.End();

            window.SwapBuffers();
        }
    }
}
