using System;
using System.Runtime.Serialization;

namespace OpenGL_Project.Geometry
{
    class InvalidQuadrangleConstructionException : Exception
    {

        private const string _message = "Invalid Quadrangle construction! See Geometry.Quadrangle Class.";

        public InvalidQuadrangleConstructionException() : base(_message) { }

    }
}