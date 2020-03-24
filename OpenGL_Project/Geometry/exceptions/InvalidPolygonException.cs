using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL_Project.Geometry
{
    class InvalidPolygonException : Exception
    {

        private const string _message = "Invalid polygon which its edge count is below than Polygon.MinEdgeNumber! See Geometry.Polygon Class.";

        public InvalidPolygonException() : base(_message) { }

    }
}
