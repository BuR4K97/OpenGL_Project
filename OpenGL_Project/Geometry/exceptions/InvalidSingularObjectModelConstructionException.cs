using System;
using System.Runtime.Serialization;

namespace OpenGL_Project.Geometry
{

    class InvalidSingularObjectModelConstructionException : Exception
    {

        private const string _message = "Invalid SingularObjectModel construction! SingularObjectModel can contains only one type of GeometricObject (Triangular, Quadratic and Polygonal). See Geometry.SingularObjectModel Class.";

        public InvalidSingularObjectModelConstructionException() : base(_message)  { }

    }
}