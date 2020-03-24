using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenGL_Project.Graphics;
using System.Windows.Forms;


namespace OpenGL_Project.ProjectAssignment3
{
    class AssignmentThreeWindow : OpenGLWindow
    {
        private const int _widthOff = 260;

        private Timer _update;
        private ModelControl _modelControl;
        private CameraControl _cameraControl;

        public AssignmentThreeWindow(int width, int height, string title) : base(new AssignmentThreeScene(), width, height, title)
        {
            this._modelControl = new ModelControl();
            this._cameraControl = new CameraControl();
            this._update = new Timer();
            base.WidthOff = _widthOff;

            this._modelControl.Location = new System.Drawing.Point(this.Size.Width - base.WidthOff, 0);
            this._modelControl.generate += (base.Scene as AssignmentThreeScene).GenerateModelEventHandler;
            this._cameraControl.Location = new System.Drawing.Point(this.Size.Width - base.WidthOff, this._modelControl.Size.Height);
            this._cameraControl.zoom += (base.Scene as AssignmentThreeScene).ZoomEventHandler;
            this._cameraControl.rotate += RotateEventHandler;
            this.Controls.Add(this._modelControl);
            this.Controls.Add(this._cameraControl);
        }

        protected override void Initialize()
        {
            base.Initialize();
            _update.Tick += (Scene as AssignmentThreeScene).OnUpdate;
            _update.Interval = 10;
            _update.Start();
        }

        private void RotateEventHandler(CameraControl sender, RotateButtonEventArgs args)
        {
            if (_update.Enabled) _update.Stop();
            else _update.Start();
        }

    }
}
