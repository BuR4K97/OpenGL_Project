using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenGL_Project.ProjectAssignment3
{
    public partial class CameraControl : UserControl
    {
        public CameraControl()
        {
            InitializeComponent();
        }

        public ZoomEventHandler zoom;
        private void ZoomTrackScroll(object sender, EventArgs e)
        {
            if (zoom != null)
            {
                zoom.Invoke(this, new ZoomEventArgs()
                {
                    zoomScale = _zoomTrack.Value
                });
            }
        }

        public RotateButtonEventHandler rotate;
        private void RotateButtonClick(object sender, EventArgs e)
        {
            if (rotate != null)
            {
                rotate.Invoke(this, new RotateButtonEventArgs());
            }
        }

        public delegate void ZoomEventHandler(CameraControl sender, ZoomEventArgs args);
        public delegate void RotateButtonEventHandler(CameraControl sender, RotateButtonEventArgs args);

    }

    public class RotateButtonEventArgs : EventArgs { }
    public class ZoomEventArgs : EventArgs
    {
        public int zoomScale;
    }
}
