using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenGL_Project.Configurations;
using System.Windows.Forms;

namespace OpenGL_Project.ProjectAssignment1
{
    static class AssignmentOneProgram
    {

        public static void Main(string[] args)
        {
            AppConfig.Initialize();
            AssignmentOneWindow window = new AssignmentOneWindow(1920, 1080, "Project Assignment 1");
            Application.Run(window);
        }

    }
}
