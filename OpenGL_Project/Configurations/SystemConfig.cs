using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OpenGL_Project.Configurations
{
    public class SystemConfig : IConfig
    {

        public void Initialize()
        {
            ConfigurateDirectory();
        }

        private static void ConfigurateDirectory()
        {
            string[] subdirectories = Directory.GetCurrentDirectory().Split(Path.DirectorySeparatorChar);
            Directory.SetCurrentDirectory(Directory.GetDirectoryRoot(Directory.GetCurrentDirectory()));
            Directory.SetCurrentDirectory(Path.Combine(subdirectories.Take(subdirectories.Length - 2).Skip(1).ToArray()));
        }
    }
}
