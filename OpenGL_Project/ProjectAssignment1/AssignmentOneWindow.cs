using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenGL_Project.Geometry;
using OpenGL_Project.Graphics;
using System.Windows.Forms;


namespace OpenGL_Project.ProjectAssignment1
{
    class AssignmentOneWindow : OpenGLWindow
    {
        private Timer _update;
        public AssignmentOneWindow(int width, int height, string title) : base(new AssignmentOneScene(), width, height, title)
        {
            _update = new Timer();   
        }

        protected override void Initialize()
        {
            base.Initialize();
            _update.Tick += (Scene as AssignmentOneScene).OnUpdate;
            _update.Interval = 10;
            //_update.Start();
        }

        protected override void OnMouseDown(MouseEventArgs args)
        {
            (Scene as AssignmentOneScene).OnMouseDown(new Coordinate(args.X, args.Y, 0));
            base.OnMouseDown(args);
        }

        protected override void OnKeyPress(KeyPressEventArgs args)
        {
            (Scene as AssignmentOneScene).OnKeyPress(args.KeyChar.ToString());
            base.OnKeyPress(args);
        }

        protected override void OnMouseWheel(MouseEventArgs args)
        {
            (Scene as AssignmentOneScene).OnMouseWheel(args.Delta);
            base.OnMouseWheel(args);
        }

    }
}
