using System;
using System.Runtime.Serialization;

namespace OpenGL_Project.Graphics
{
    class InvalidLightEventHandlerException : Exception
    {

        private const string _message = "Invalid LightEventHandler for a Light instance! See Graphics.Light Class.";

        public InvalidLightEventHandlerException() : base(_message) { }

    }
}