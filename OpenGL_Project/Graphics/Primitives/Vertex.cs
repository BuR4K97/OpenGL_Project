using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenGL_Project.Geometry;
using OpenTK.Graphics;

namespace OpenGL_Project.Graphics
{
    class Vertex : IEquatable<Coordinate>
    {

        public const int DefaultJointIndex = 0;
        public const float DefaultJointCoeff = 0.0f;

        public readonly Coordinate Coord;
        public Color4 Color;
        public Vector NormalVec;
        public int JointIndex;
        public float JointCoeff;

        public Vertex(Coordinate coord, Color4 color, Vector normal, int jointIndex, float jointCoeff)
        {
            this.Coord = coord;
            this.Color = color;
            this.NormalVec = normal;
            this.JointIndex = jointIndex;
            this.JointCoeff = jointCoeff;
        }

        public bool Equals(Coordinate other)
        {
            if (other == null) return false;
            return Coord.Equals(other);
        }

        private int _integrateDegree = 1;
        public bool IntegrateNormalVec(Vector integrate)
        {
            float angle = Vector.FindAngleBetween(NormalVec, integrate);
            if (angle == (float) Math.PI) return false;

            angle /= ++_integrateDegree;
            NormalVec.Rotate(Vector.CrossProduct(NormalVec, integrate), angle);
            return true;
        }

        public VertexData GetVertexData()
        {
            return new VertexData().SetXYZ(Coord.XCoord, Coord.YCoord, Coord.ZCoord)
                                            .SetRGBA(Color.R, Color.G, Color.B, Color.A)
                                            .SetNormal(NormalVec.XComp, NormalVec.YComp, NormalVec.ZComp)
                                            .SetJointIndex(JointIndex).SetJointCoeff(JointCoeff);
        }

    }
}
