using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL_Project.Geometry
{
    public class HierarchyPackage
    {
        public static readonly HierarchyPackage SingularHierarchyPack = new HierarchyPackage(new Dictionary<ObjectModel.ComponentKey, List<ObjectModel.ComponentKey>>()
        {
            {SingularObjectModel.SingularCompID, new List<ObjectModel.ComponentKey>() { } }
        });

        public readonly Dictionary<ObjectModel.ComponentKey, List<ObjectModel.ComponentKey>> ComponentMap;


        public HierarchyPackage(Dictionary<ObjectModel.ComponentKey, List<ObjectModel.ComponentKey>> componentMap)
        {
            this.ComponentMap = new Dictionary<ObjectModel.ComponentKey, List<ObjectModel.ComponentKey>>(componentMap);
        }

    }
}
