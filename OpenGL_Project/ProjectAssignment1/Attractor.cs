using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenGL_Project.Geometry;

namespace OpenGL_Project.ProjectAssignment1
{
    class Attractor
    {
        public enum AttractorType { None, Rock, Home, Tree }

        public AttractorType Type;
        public Coordinate Coord;

        public Attractor(AttractorType type)
        {
            this.Type = type;
        }

        public double GetProbabilisticAttraction(Entity entity)
        {
            double distance = Coordinate.GetDistance(Coord, entity.Position);
            distance = Math.Pow(1 / distance, 1);
            return  distance;
            
        }
    }
}
