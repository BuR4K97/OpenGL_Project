using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenGL_Project.Geometry;
using OpenGL_Project.Graphics;

namespace OpenGL_Project.ProjectAssignment3
{
    class SuperquadricHyperboloid : GeometricObject
    {
        public const int DefaultPhiResolParam = 1;
        public const int DefaultThetaResolParam = 1;
        public const int DefaultXCompParam = 5;
        public const int DefaultYCompParam = 5;
        public const int DefaultZCompParam = 5;
        private const int _meshResol = 48;

        public float PhiResolParam;
        public float ThetaResolParam;
        public float XCompParam;
        public float YCompParam;
        public float ZCompParam;

        public NormalPackage Normals;

        public SuperquadricHyperboloid()
        {
            this.PhiResolParam = 0.0f;
            this.ThetaResolParam = 0.0f;
            this.XCompParam = 0.0f;
            this.YCompParam = 0.0f;
            this.ZCompParam = 0.0f;
            this.Normals = new NormalPackage();
        }

        public void GenerateCoords()
        {
            List<Coordinate> coords = new List<Coordinate>();

            Normals.Flush();
            Coordinate coord; Vector normal;
            float angleDiff = (float)(2 * Math.PI / _meshResol);
            for (float theta = 0.0f; theta < 2 * Math.PI; theta += angleDiff)
            {
                for (float phi = 0.0f; phi < 2 * Math.PI; phi += angleDiff)
                {
                    coord = new Coordinate((float)(XCompParam * (Math.Pow(1 / Math.Cos(phi), PhiResolParam)) * Math.Pow(Math.Cos(theta), ThetaResolParam))
                        , (float)(YCompParam * (Math.Pow(1 / Math.Cos(phi), PhiResolParam)) * Math.Pow(Math.Sin(theta), ThetaResolParam))
                        , (float)(ZCompParam * Math.Pow(Math.Tan(phi), PhiResolParam)));
                    coord.normalize();
                    normal = new Vector((float)(Math.Pow(1 / Math.Cos(phi), 2 - PhiResolParam) * Math.Pow(Math.Cos(theta), 2 - ThetaResolParam) / XCompParam)
                        , (float)(Math.Pow(1 / Math.Cos(phi), 2 - PhiResolParam) * Math.Pow(Math.Sin(theta), 2 - ThetaResolParam) / YCompParam)
                        , (float)(Math.Pow(Math.Tan(phi), 2 - PhiResolParam) / ZCompParam));
                    normal.normalize();
                    coords.Add(coord);
                    Normals.Insert(coord, normal);
                }
            }

            FlushPolygons();
            int currPulseOffset, adjacentPulseOffset;
            List<Coordinate> edgeCoords = new List<Coordinate>();
            for (int pulseIndex = 0; pulseIndex < _meshResol; pulseIndex++)
            {
                currPulseOffset = pulseIndex * _meshResol;
                if (pulseIndex == _meshResol - 1) adjacentPulseOffset = 0;
                else adjacentPulseOffset = currPulseOffset + _meshResol;
                for (int triangleIndex = 0; triangleIndex < _meshResol - 1; triangleIndex++)
                {
                    edgeCoords.Clear();
                    edgeCoords.Add(coords[currPulseOffset + triangleIndex]);
                    edgeCoords.Add(coords[adjacentPulseOffset + triangleIndex]);
                    edgeCoords.Add(coords[currPulseOffset + triangleIndex + 1]);
                    InsertPolygon(new Triangle(edgeCoords));

                    edgeCoords.Clear();
                    edgeCoords.Add(coords[adjacentPulseOffset + triangleIndex]);
                    edgeCoords.Add(coords[adjacentPulseOffset + triangleIndex + 1]);
                    edgeCoords.Add(coords[currPulseOffset + triangleIndex + 1]);
                    InsertPolygon(new Triangle(edgeCoords));
                }
                edgeCoords.Clear();
                edgeCoords.Add(coords[currPulseOffset + _meshResol - 1]);
                edgeCoords.Add(coords[adjacentPulseOffset + _meshResol - 1]);
                edgeCoords.Add(coords[currPulseOffset]);
                InsertPolygon(new Triangle(edgeCoords));

                edgeCoords.Clear();
                edgeCoords.Add(coords[adjacentPulseOffset + _meshResol - 1]);
                edgeCoords.Add(coords[adjacentPulseOffset]);
                edgeCoords.Add(coords[currPulseOffset]);
                InsertPolygon(new Triangle(edgeCoords));
            }
        }
    }
}
