using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenGL_Project.Geometry;

namespace OpenGL_Project.ProjectAssignment1
{
    class Entity
    {

        public const float EntityRadius = 7.0f;

        public Coordinate Position;

        public Entity(Coordinate position)
        {
            this.Position = position;
        }

    }
}
