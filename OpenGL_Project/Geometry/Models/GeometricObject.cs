using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL_Project.Geometry
{
    public class GeometricObject : IEquatable<GeometricObject>
    {
        public enum PolygonMode { Invalid, Triangular, Quadratic, Polygonal }

        public List<Polygon> Polygons;
        public PolygonMode Mode;

        public GeometricObject()
        {
            this.Polygons = new List<Polygon>();
            this.Mode = PolygonMode.Invalid;
        }

        public GeometricObject(List<Polygon> polygons)
        {
            this.Polygons = new List<Polygon>(polygons);
            this.Mode = PolygonMode.Invalid;
            foreach (Polygon polygon in this.Polygons)
            {
                if (polygon is Triangle) SetPolygonMode(PolygonMode.Triangular);
                else if (polygon is Quadrangle) SetPolygonMode(PolygonMode.Quadratic);
                else SetPolygonMode(PolygonMode.Polygonal);
            }
        }

        public virtual void InsertPolygon(Polygon insert)
        {
            if (Polygons.Exists(polygon => polygon.Equals(insert))) return;
            Polygons.Add(insert);
            if (insert is Triangle) SetPolygonMode(PolygonMode.Triangular);
            else if (insert is Quadrangle) SetPolygonMode(PolygonMode.Quadratic);
            else SetPolygonMode(PolygonMode.Polygonal);
        }

        public virtual void InsertPolygons(List<Polygon> insert)
        {
            foreach (Polygon polygon in insert)
            {
                if (Polygons.Exists(x => x.Equals(polygon))) continue;
                Polygons.Add(polygon);

                if (polygon is Triangle) SetPolygonMode(PolygonMode.Triangular);
                else if (polygon is Quadrangle) SetPolygonMode(PolygonMode.Quadratic);
                else SetPolygonMode(PolygonMode.Polygonal);
            }
        }

        public void FlushPolygons()
        {
            Polygons.Clear();
            Mode = PolygonMode.Invalid;
        }

        private void SetPolygonMode(PolygonMode mode)
        {
            if (Mode == PolygonMode.Invalid)
            {
                Mode = mode;
            }
            else if (Mode != mode)
            {
                throw new InvalidGeometricObjectConstructionException();
            }
        }

        public List<Coordinate> GetCoordinates()
        {
            List<Coordinate> coords = new List<Coordinate>();
            foreach (Polygon polygon in Polygons)
            {
                foreach (Coordinate coord in polygon.EdgeCoords)
                {
                    if (coords.Contains(coord)) continue;
                    coords.Add(coord);
                }
            }
            return coords;
        }
        public int GetPolygonCount()
        {
            return Polygons.Count;
        }

        public bool Equals(GeometricObject other)
        {
            if (other == null) return false;
            if (Polygons.Count != other.Polygons.Count) return false;
            if (Mode != other.Mode) return false;

            foreach (Polygon polygon in Polygons)
            {
                if (!other.Polygons.Contains(polygon)) return false;
            }
            return true;
        }
    }
}
