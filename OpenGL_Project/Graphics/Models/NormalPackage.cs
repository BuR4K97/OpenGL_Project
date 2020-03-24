using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenGL_Project.Geometry;

namespace OpenGL_Project.Graphics
{
    public class NormalPackage
    {

        public Dictionary<Coordinate, Vector> NormalMap;

        public NormalPackage()
        {
            this.NormalMap = new Dictionary<Coordinate, Vector>();
        }

        public NormalPackage(List<Coordinate> coords, List<Vector> normals)
        {
            this.NormalMap = new Dictionary<Coordinate, Vector>();
            for (int i = 0; i < coords.Count; i++)
            {
                this.NormalMap.Add(coords[i], normals[i]);
            }
        }

        public void Insert(Coordinate coord, Vector normal)
        {
            if (NormalMap.ContainsKey(coord))
            {
                NormalMap[coord] = normal;
            }
            else
            {
                NormalMap.Add(coord, normal);
            }
        }

        public void Insert(List<Coordinate> coords, List<Vector> normals)
        {
            for (int i = 0; i < coords.Count; i++)
            {
                if (NormalMap.ContainsKey(coords[i]))
                {
                    NormalMap[coords[i]] = normals[i];
                }
                else
                {
                    NormalMap.Add(coords[i], normals[i]);
                }
            }
        }

        public void Flush()
        {
            NormalMap.Clear();
        }
    }

}
