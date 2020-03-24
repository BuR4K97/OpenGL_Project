using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenGL_Project.Geometry;
using OpenTK;

namespace OpenGL_Project.Graphics
{
    public class MaterialPackage
    {

        public static readonly Material DefaultMaterial = new Material (Material.DefaultAmbient, Material.DefaultDiffuse, Material.DefaultSpecular
            , Material.DefaultShininess);

        public Dictionary<ObjectModel.ComponentKey, Material> MaterialMap;

        public MaterialPackage()
        {
            this.MaterialMap = new Dictionary<ObjectModel.ComponentKey, Material>();
        }

        public MaterialPackage(List<ObjectModel.ComponentKey> comps, List<Material> materials)
        {
            this.MaterialMap = new Dictionary<ObjectModel.ComponentKey, Material>();
            for (int i = 0; i < comps.Count; i++)
            {
                this.MaterialMap.Add(comps[i], materials[i]);
            }
        }

        public void Insert(ObjectModel.ComponentKey comp, Material material)
        {
            if (MaterialMap.ContainsKey(comp))
            {
                MaterialMap[comp] = material;
            }
            else
            {
                MaterialMap.Add(comp, material);
            }
        }

        public void Insert(List<ObjectModel.ComponentKey> comps, List<Material> materials)
        {
            for (int i = 0; i < comps.Count; i++)
            {
                if (MaterialMap.ContainsKey(comps[i]))
                {
                    MaterialMap[comps[i]] = materials[i];
                }
                else
                {
                    MaterialMap.Add(comps[i], materials[i]);
                }
            }
        }
    }
}
