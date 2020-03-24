using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenGL_Project.Configurations;
using System.Windows.Forms;

namespace OpenGL_Project.ProjectAssignment2
{
    static class AssignmentTwoProgram
    {

        public static void Main(string[] args)
        {
            AppConfig.Initialize();
            AssignmentTwoWindow window = new AssignmentTwoWindow(1920, 1080, "Project Assignment 2");
            Application.Run(window);
        }

    }
}