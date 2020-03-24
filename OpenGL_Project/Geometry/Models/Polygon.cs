using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace OpenGL_Project.Geometry
{
    public class Polygon : IEquatable<Polygon>
    {
        public const int MinEdgeNumber = 3;

        public List<Coordinate> EdgeCoords;
        private Coordinate _jointCoord;

        public Polygon()
        {
            this.EdgeCoords = new List<Coordinate>();
        }

        public Polygon(List<Coordinate> edgeCoords)
        {
            this.EdgeCoords = new List<Coordinate>(edgeCoords);
        }

        public virtual void InsertEdgeCoord(Coordinate insert)
        {
            if (EdgeCoords.Exists(coord => coord.Equals(insert))) return;
            EdgeCoords.Add(insert);
        }

        public virtual void InsertEdgeCoords(List<Coordinate> insert)
        {
            foreach (Coordinate coord in insert)
            {
                if (EdgeCoords.Exists(x => x.Equals(coord))) continue;
                EdgeCoords.Add(coord);
            }
        }

        public void FlushEdgeCoords()
        {
            EdgeCoords.Clear();
        }

        public int GetEdgeCount()
        {
            return EdgeCoords.Count;
        }

        public virtual bool CheckValid()
        {
            return EdgeCoords.Count >= MinEdgeNumber;
        }


        public bool Equals(Polygon other)
        {
            if (other == null) return false;
            if (EdgeCoords.Count != other.EdgeCoords.Count) return false;

            for(int i = 0; i < EdgeCoords.Count; i++)
            {
                if (!EdgeCoords[i].Equals(other.EdgeCoords[i])) return false;
            }
            return true;
        }

        public Coordinate GetJointCoord()
        {
            if (!CheckValid()) throw new InvalidPolygonException();

            if (_jointCoord == null) _jointCoord = Coordinate.FindJointCoord(EdgeCoords);
            return _jointCoord;
        }

        public virtual Vector GetNormalVec()
        {
            if (!CheckValid()) throw new InvalidPolygonException();
            if (_jointCoord == null) _jointCoord = Coordinate.FindJointCoord(EdgeCoords);

            Vector source, target;
            source = new Vector(_jointCoord, EdgeCoords.Last());
            target = new Vector(_jointCoord, EdgeCoords.First());
            Vector normalVec = Vector.CrossProduct(source, target);

            int beginIndex = 0; Vector temp;
            for (int i = 0; i < EdgeCoords.Count - 1; i++)
            {
                source = new Vector(_jointCoord, EdgeCoords[i]);
                target = new Vector(_jointCoord, EdgeCoords[i + 1]);
                temp = Vector.CrossProduct(source, target);
                normalVec.Rotate(Vector.CrossProduct(normalVec, temp), Vector.FindAngleBetween(normalVec, temp) / (beginIndex + 2));
            }
            return normalVec;
        }

    }
}
