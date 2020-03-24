using System;
using System.Runtime.Serialization;

namespace OpenGL_Project.Graphics
{
    class InvalidObjectMeshException : Exception
    {

        private const string _message = "Invalid object mesh data! Only Triangular and Quadratic is valid. See Graphics.ObjectMeshLoader Class.";

        public InvalidObjectMeshException() : base(_message) { }

    }
}