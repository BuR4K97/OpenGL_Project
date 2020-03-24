using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL_Project.Graphics
{
    class InvalidCameraAttributeEventHandlerException : Exception
    {

        private const string _message = "Invalid CameraAttributeEventHandler for a Camera instance! See Graphics.Camera Class.";

        public InvalidCameraAttributeEventHandlerException() : base(_message) { }

    }
}
