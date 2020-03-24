using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;
using OpenGL_Project.Configurations;
using OpenTK.Graphics;
using OpenTK;


namespace OpenGL_Project.Graphics
{
    public abstract class GLControlWindow : Form
    {
        private const string WindowName = "GLControlWindow";
        private const string GLControlName = "GLControl";
        private const int GLControlTabIndex = 1;
        private static readonly Point GLControlLoc = new Point(0, 0);
        private const bool GLControlVSync = true;

        public int Width, Height;
        public string Title;
        private GLControl _glControl;

        public GLControlWindow(int width, int height, string title)
        {
            this.Width = width;
            this.Height = height;
            this.Title = title;
            this._glControl = new GLControl(GraphicsMode.Default, GLConfig.MajorGLVersion, GLConfig.MinorGLVersion, GraphicsContextFlags.Default);
            InitializeComponents();
        }

        public void InitializeComponents()
        {
            this.SuspendLayout();

            this.Name = WindowName;
            this.Text = Title;
            this.Size = new Size(Width, Height);
            this.ClientSize = this.Size;
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.Controls.Add(this._glControl);

            this._glControl.Name = GLControlName;
            this._glControl.Location = GLControlLoc;
            this._glControl.Size = new Size(Width - WidthOff, Height - HeightOff);
            this._glControl.BackColor = Color.Black;
            this._glControl.TabIndex = GLControlTabIndex;
            this._glControl.VSync = GLControlVSync;

            this.ResumeLayout(false);
        }

        protected override void OnLoad(EventArgs args)
        {
            GLConfig glConfig = AppConfig.GetService<GLConfig>();
            glConfig.Initialize();
            glConfig.UpdateViewPort(0, 0, Width - WidthOff, Height - HeightOff);
            this.Resize += OnResize;
            this.WindowState = FormWindowState.Maximized;
            Initialize();
            base.OnLoad(args);
        }

        protected abstract void Initialize();

        protected override void OnPaint(PaintEventArgs args)
        {
            _glControl.SwapBuffers();
            base.OnPaint(new PaintEventArgs(this.CreateGraphics(), this.ClientRectangle));
        }

        protected int WidthOff, HeightOff; 
        protected void OnResize(Object sender, EventArgs args)
        {
            Width = Size.Width;
            Height = Size.Height;
            _glControl.Size = new Size(Width - WidthOff, Height - HeightOff);
            AppConfig.GetService<GLConfig>().UpdateViewPort(0, 0, Width - WidthOff, Height - HeightOff);
        }

        public void OnAppIdle(object sender, EventArgs e)
        {
            while (appStillIdle)
            {
                OnPaint(new PaintEventArgs(this.CreateGraphics(), this.ClientRectangle));
            }
        }

        private bool appStillIdle
        {
            get
            {
                Message msg;
                return !PeekMessage(out msg, IntPtr.Zero, 0, 0, 0);
            }
        }

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool PeekMessage(out Message msg, IntPtr hWnd, uint messageFilterMin, uint messageFilterMax, uint flags);

    }
}
