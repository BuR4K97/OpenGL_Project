using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL_Project.Graphics
{
    class InvalidCameraTransformationException : Exception
    {

        private const string _message = "Invalid transformation (scale) for a Camera instance! See Graphics.Camera Class.";

        public InvalidCameraTransformationException() : base(_message) { }

    }
}
