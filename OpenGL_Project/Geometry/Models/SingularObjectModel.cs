using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL_Project.Geometry
{
    internal class SingularObjectModel : ObjectModel
    {

        public static readonly ComponentKey SingularCompID = new ComponentKey() { ID = "SingularComp" };

        public List<GeometricObject> GeometricObjs;
        public GeometricObject.PolygonMode PolygonMode;

        public SingularObjectModel()
        {
            this.GeometricObjs = new List<GeometricObject>();
            this.PolygonMode = GeometricObject.PolygonMode.Invalid;
        }

        public SingularObjectModel(List<GeometricObject> geometricObjs)
        {
            this.GeometricObjs = new List<GeometricObject>(geometricObjs);
            foreach (GeometricObject geobj in geometricObjs)
            {
                if (geobj.Mode != GeometricObject.PolygonMode.Invalid) SetPolygonMode(geobj.Mode);
            }
        }

        public void InsertGeometricObj(GeometricObject insert)
        {
            if (GeometricObjs.Exists(obj => obj.Equals(insert))) return;

            GeometricObjs.Add(insert);
            if (insert.Mode != GeometricObject.PolygonMode.Invalid) SetPolygonMode(insert.Mode);
        }

        public void InsertGeometricObjs(List<GeometricObject> insert)
        {
            foreach (GeometricObject obj in insert)
            {
                if (GeometricObjs.Exists(x => x.Equals(obj))) continue;

                GeometricObjs.Add(obj);
                if (obj.Mode != GeometricObject.PolygonMode.Invalid) SetPolygonMode(obj.Mode);
            }
        }

        public void FlushGeometricObjs()
        {
            GeometricObjs.Clear();
            PolygonMode = GeometricObject.PolygonMode.Invalid;
        }

        private void SetPolygonMode(GeometricObject.PolygonMode mode)
        {
            if (PolygonMode == GeometricObject.PolygonMode.Invalid)
            {
                PolygonMode = mode;
            }
            else if (PolygonMode != mode)
            {
                throw new InvalidSingularObjectModelConstructionException();
            }
        }

        public int GetGeometricObjCount()
        {
            return GeometricObjs.Count;
        }

        public override StructType GetStructType()
        {
            return StructType.Singular;
        }

        public override Dictionary<ComponentKey, List<GeometricObject>> GetIdentities()
        {
            Dictionary<ComponentKey, List<GeometricObject>> identities = new Dictionary<ComponentKey, List<GeometricObject>>();
            identities.Add(SingularCompID, GeometricObjs);
            return identities;
        }

        public List<Coordinate> GetCoordinates()
        {
            List<Coordinate> coords = new List<Coordinate>(); 
            foreach (GeometricObject geobj in GeometricObjs)
            {
                foreach (Coordinate coord in geobj.GetCoordinates())
                {
                    if (coords.Contains(coord)) continue;
                    coords.Add(coord);
                }
            }
            return coords;
        }

    }
}
