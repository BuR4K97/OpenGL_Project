using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL_Project.Geometry
{
    class InvalidTriangleConstructionException : Exception
    {

        private const string _message = "Invalid triangle which its edge count exceeds Triangle.MaxEdgeNumber! See Geometry.Triangle Class.";

        public InvalidTriangleConstructionException() : base(_message) { }

    }
}
