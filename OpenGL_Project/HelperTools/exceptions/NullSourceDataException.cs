using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL_Project.HelperTools
{
    class NullSourceDataException : Exception
    {
        private const string _message = "Source Data is Null since FileHandler._sourceData is not assigned! See HelperTools.FileHandler Class.";

        public NullSourceDataException() : base(_message) { }
    }
}
