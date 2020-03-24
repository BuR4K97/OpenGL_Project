using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenGL_Project.Configurations;
using System.Windows.Forms;

namespace OpenGL_Project.ProjectAssignment3
{
    class AssignmentThreeProgram
    {

        static void Main(string[] args)
        {
            AppConfig.Initialize();
            AssignmentThreeWindow window = new AssignmentThreeWindow(1556, 884, "Project Assignment 3");
            Application.Idle += window.OnAppIdle;
            Application.Run(window);
        }

    }
}
