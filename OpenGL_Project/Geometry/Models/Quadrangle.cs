using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL_Project.Geometry
{
    class Quadrangle : Polygon
    {

        public const int EdgeNumber = 4;

        public Quadrangle()
        {
            this.EdgeCoords = new List<Coordinate>();
        }

        public Quadrangle(List<Coordinate> edgeCoords)
        {
            if (edgeCoords.Count > EdgeNumber) throw new InvalidQuadrangleConstructionException();

            this.EdgeCoords = new List<Coordinate>(edgeCoords);
        }

        public override void InsertEdgeCoord(Coordinate insert)
        {
            if (EdgeCoords.Count + 1 > EdgeNumber) throw new InvalidQuadrangleConstructionException();

            if (EdgeCoords.Exists(coord => coord.Equals(insert))) return;
            EdgeCoords.Add(insert);
        }

        public override void InsertEdgeCoords(List<Coordinate> insert)
        {
            if (EdgeCoords.Count + insert.Count > EdgeNumber) throw new InvalidQuadrangleConstructionException();

            foreach (Coordinate coord in insert)
            {
                if (EdgeCoords.Exists(x => x.Equals(coord))) continue;
                EdgeCoords.Add(coord);
            }
        }

        public override bool CheckValid()
        {
            return EdgeCoords.Count == EdgeNumber;
        }

    }
}
