using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenGL_Project.Graphics;
using System.Windows.Forms;


namespace OpenGL_Project.ProjectAssignment2
{
    class AssignmentTwoWindow : OpenGLWindow
    {
        private Timer _update;
        public AssignmentTwoWindow(int width, int height, string title) : base(new AssignmentTwoScene(), width, height, title)
        {
            _update = new Timer();
        }

        protected override void Initialize()
        {
            base.Initialize();
            _update.Tick += (Scene as AssignmentTwoScene).OnUpdate;
            _update.Interval = 10;
            //_update.Start();
        }

        protected override void OnKeyPress(KeyPressEventArgs args)
        {
            (Scene as AssignmentTwoScene).OnKeyPress(args.KeyChar.ToString());
            base.OnKeyPress(args);
        }

    }
}
