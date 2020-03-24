using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL_Project.Geometry
{
    class Triangle : Polygon
    {

        public const int EdgeNumber = 3;

        public Triangle()
        {
            this.EdgeCoords = new List<Coordinate>();
        }

        public Triangle(List<Coordinate> edgeCoords)
        {
            if (edgeCoords.Count > EdgeNumber) throw new InvalidTriangleConstructionException();

            this.EdgeCoords = new List<Coordinate>(edgeCoords);
        }

        public override void InsertEdgeCoord(Coordinate insert)
        {
            if (EdgeCoords.Count + 1 > EdgeNumber) throw new InvalidTriangleConstructionException();

            if (EdgeCoords.Exists(coord => coord.Equals(insert))) return;
            EdgeCoords.Add(insert);
        }

        public override void InsertEdgeCoords(List<Coordinate> insert)
        {
            if (EdgeCoords.Count + insert.Count > EdgeNumber) throw new InvalidTriangleConstructionException();

            foreach (Coordinate coord in insert)
            {
                if (EdgeCoords.Exists(x => x.Equals(coord))) continue;
                EdgeCoords.Add(coord);
            }
        }

        public override Vector GetNormalVec()
        {
            if (!CheckValid()) throw new InvalidPolygonException();

            return Vector.CrossProduct(new Vector(EdgeCoords[1], EdgeCoords[0]), new Vector(EdgeCoords[2], EdgeCoords[0])); ;
        }

    }
}
