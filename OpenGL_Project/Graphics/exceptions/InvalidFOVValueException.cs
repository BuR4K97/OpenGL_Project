using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL_Project.Graphics
{
    class InvalidFOVValueException : Exception
    {

        private const string _message = "Invalid FOV value for Camera! See Graphics.Camera Class.";

        public InvalidFOVValueException() : base(_message) { }

    }
}
