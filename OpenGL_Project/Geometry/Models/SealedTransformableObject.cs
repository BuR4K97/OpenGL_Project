using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL_Project.Geometry
{
    class SealedTransformableObject
    {
        public readonly TransformableObject Object;
        public HierarchyPackage HierarchyPack;

        public SealedTransformableObject(ObjectModel objectModel, HierarchyPackage hierarchyPack)
        {
            this.Object = new TransformableObject(objectModel);
            this.HierarchyPack = hierarchyPack;
        }

        public TransformableObject GetComp(ObjectModel.ComponentKey compID)
        {
            List<ObjectModel.ComponentKey> path = HierarchyPack.ComponentMap[compID];
            TransformableObject comp = Object;
            for (int i = 0; i < path.Count; i++)
            {
                comp = comp.GetSubComp(path[i]);
            }
            return comp;
        }

    }
}
