using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL_Project.Geometry
{
    class InvalidHierarchicalAccessException : Exception
    {

        private const string _message = "Invalid hierarchical access for a ObjectModel! Specified ComponentKey is not valid. See Geometry.ObjectModel Class.";

        public InvalidHierarchicalAccessException() : base(_message) { }

    }
}
