using System;
using System.Runtime.Serialization;

namespace OpenGL_Project.Graphics
{
    public class InvalidMaterialEventHandlerException : Exception
    {
        private const string _message = "Invalid MaterialEventHandler for a Material instance! See Graphics.Material Class.";

        public InvalidMaterialEventHandlerException() : base(_message) { }
    }
}