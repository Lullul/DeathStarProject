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

            window.KeyDown += window_KeyDown;
            window.KeyUp += window_KeyUp;
            window.KeyPress += window_KeyPress;
        }

        void window_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Console.WriteLine("KeyPress: {0} - {1}", e.KeyChar, sender);
        }

        void window_KeyUp(object sender, KeyboardKeyEventArgs e)
        {
            //Console.WriteLine("KeyUp: {0} - {1}", e.Key, sender);

        }

        void window_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            //Console.WriteLine("KeyDown: {0} - {1}", e.Key, sender);
        }

        void window_Load(object sender, EventArgs e)
        {
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            
            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Lequal);

            GL.Enable(EnableCap.Texture2D);

            GL.Enable(EnableCap.AlphaTest);
            GL.AlphaFunc(AlphaFunction.Gequal, 0.5f);

            texture = ContentPipe.LoadTexture("Resources/img/rabbit.png");
        }

        KeyboardState lastKeyState;
        void window_UpdateFrame(object sender, FrameEventArgs e)
        {
            KeyboardState keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Key.Enter) && lastKeyState.IsKeyUp(Key.Enter))
            {
                Console.WriteLine("Enter!");
            }

            if (keyState.IsKeyUp(Key.Enter) && lastKeyState.IsKeyDown(Key.Enter))
            {
                Console.WriteLine("Enter! 2");
            }

            lastKeyState = keyState;
        }

        void window_RenderFrame(object sender, FrameEventArgs e)
        {
            GL.ClearColor(Color.CornflowerBlue);
            GL.ClearDepth(1);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            Matrix4 projMatrix = Matrix4.CreateOrthographicOffCenter(0, window.Width, window.Height, 0, 0, 1);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projMatrix);

            // The general rule of thumb when it comes to matrix transformation is always multipy scale * rotation * translation.
            // This will keep the resulting matrix from deforming your object in unexpected ways.

            Matrix4 modelViewMatrix =
                Matrix4.CreateScale(0.5f, 0.5f, 1f) *
                Matrix4.CreateRotationZ(0f) *
                Matrix4.CreateTranslation(0f, 0f, 0f);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelViewMatrix);
            DrawTexture();

            modelViewMatrix =
                Matrix4.CreateScale(0.6f, 0.4f, 1f) *
                Matrix4.CreateRotationZ(0f) *
                Matrix4.CreateTranslation(300f, 0f, 0f);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelViewMatrix);
            DrawTexture();

            modelViewMatrix =
                Matrix4.CreateScale(0.5f, 0.5f, 1f) *
                Matrix4.CreateRotationZ(0.4f) *
                Matrix4.CreateTranslation(200f, 250f, 0f);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelViewMatrix);
            DrawTexture();

            modelViewMatrix =
                Matrix4.CreateScale(1f, 1f, 1f) *
                Matrix4.CreateRotationZ(0.4f) *
                Matrix4.CreateTranslation(0f, 0f, -0.1f);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelViewMatrix);
            DrawTexture();

            window.SwapBuffers();
        }

        void DrawTexture()
        {
            GL.BindTexture(TextureTarget.Texture2D, texture.ID);

            GL.Begin(PrimitiveType.Triangles);

            GL.Color4(1f, 1f, 1f, 1f);
            GL.TexCoord2(0, 0); GL.Vertex2(0, 0);
            GL.TexCoord2(1, 1); GL.Vertex2(texture.Width, texture.Height);
            GL.TexCoord2(0, 1); GL.Vertex2(0, texture.Height);

            GL.TexCoord2(0, 0); GL.Vertex2(0, 0);
            GL.TexCoord2(1, 0); GL.Vertex2(texture.Width, 0);
            GL.TexCoord2(1, 1); GL.Vertex2(texture.Width, texture.Height);

            GL.End();
        }
    }
}
