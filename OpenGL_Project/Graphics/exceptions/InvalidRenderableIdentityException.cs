using System;
using System.Runtime.Serialization;

namespace OpenGL_Project.Graphics
{
    
    class InvalidRenderableIdentityException : Exception
    {

        private const string _message = "Invalid RenderableIdentity! RenderableIdentity can have only either Triangular or Quadratic type of GeometricObject. See Graphics.RenderableIdentity Class.";

        public InvalidRenderableIdentityException() : base(_message) { }

    }
}