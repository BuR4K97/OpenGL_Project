using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenGL_Project.Configurations;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Input;
using OpenTK;

namespace OpenGL_Project.Graphics
{
    public abstract class OpenGLWindow : GLControlWindow
    {

        public const int FramesPerSecond = 60;

        protected readonly OpenGLScene Scene;

        public OpenGLWindow(OpenGLScene scene, int width, int height, string title) : base(width, height, title)
        {
            this.Scene = scene;
        }
        
        protected override void Initialize()
        {
            Scene.Initialize(((float) Width) / Height);
        }

        protected override void OnPaint(PaintEventArgs args)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            Scene.Render();

            base.OnPaint(args);
        }

    }
}
