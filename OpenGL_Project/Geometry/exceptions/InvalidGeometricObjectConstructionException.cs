using System;
using System.Runtime.Serialization;

namespace OpenGL_Project.Geometry
{

    class InvalidGeometricObjectConstructionException : Exception
    {

        private const string _message = "Invalid GeometricObject construction! A GeometricObject can contains only one type of Polygon (Triangle, Quadrangle and Polygon etc.). See Geometry.GeometricObject Class.";

        public InvalidGeometricObjectConstructionException() : base(_message) { }

    }
}