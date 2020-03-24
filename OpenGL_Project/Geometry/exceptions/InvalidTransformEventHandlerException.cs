using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL_Project.Geometry
{
    class InvalidTransformEventHandlerException : Exception
    {

        private const string _message = "Invalid TransformEventHandler binded to a Tranformable instance! See Geometry.Transformable Class.";

        public InvalidTransformEventHandlerException() : base(_message) { }

    }
}
