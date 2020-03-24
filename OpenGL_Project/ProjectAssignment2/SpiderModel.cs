using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenGL_Project.Geometry;
using OpenGL_Project.Graphics;

namespace OpenGL_Project.ProjectAssignment2
{
    public static class SpiderModel
    {
        private static readonly Dictionary<ObjectModel.ComponentKey, string> _meshFiles = new Dictionary<ObjectModel.ComponentKey, string>()
        {
            { SpiderHiearchyPackage.body,  "ProjectAssignment2\\MeshModels\\Spider\\Body.obj" },
            { SpiderHiearchyPackage.uleg1, "ProjectAssignment2\\MeshModels\\Spider\\ULeg1.obj" },
            { SpiderHiearchyPackage.uleg2, "ProjectAssignment2\\MeshModels\\Spider\\ULeg2.obj" },
            { SpiderHiearchyPackage.uleg3, "ProjectAssignment2\\MeshModels\\Spider\\ULeg3.obj" },
            { SpiderHiearchyPackage.uleg4, "ProjectAssignment2\\MeshModels\\Spider\\ULeg4.obj" },
            { SpiderHiearchyPackage.uleg5, "ProjectAssignment2\\MeshModels\\Spider\\ULeg5.obj" },
            { SpiderHiearchyPackage.uleg6, "ProjectAssignment2\\MeshModels\\Spider\\ULeg6.obj" },
            { SpiderHiearchyPackage.uleg7, "ProjectAssignment2\\MeshModels\\Spider\\ULeg7.obj" },
            { SpiderHiearchyPackage.uleg8, "ProjectAssignment2\\MeshModels\\Spider\\ULeg8.obj" },
            { SpiderHiearchyPackage.bleg1, "ProjectAssignment2\\MeshModels\\Spider\\BLeg1.obj" },
            { SpiderHiearchyPackage.bleg2, "ProjectAssignment2\\MeshModels\\Spider\\BLeg2.obj" },
            { SpiderHiearchyPackage.bleg3, "ProjectAssignment2\\MeshModels\\Spider\\BLeg3.obj" },
            { SpiderHiearchyPackage.bleg4, "ProjectAssignment2\\MeshModels\\Spider\\BLeg4.obj" },
            { SpiderHiearchyPackage.bleg5, "ProjectAssignment2\\MeshModels\\Spider\\BLeg5.obj" },
            { SpiderHiearchyPackage.bleg6, "ProjectAssignment2\\MeshModels\\Spider\\BLeg6.obj" },
            { SpiderHiearchyPackage.bleg7, "ProjectAssignment2\\MeshModels\\Spider\\BLeg7.obj" },
            { SpiderHiearchyPackage.bleg8, "ProjectAssignment2\\MeshModels\\Spider\\BLeg8.obj" },
        };

        public static readonly ObjectModel Model = GetObjectModel();

        private static ObjectModel GetObjectModel()
        {
            Dictionary<ObjectModel.ComponentKey, ObjectModel> meshModels = new Dictionary<ObjectModel.ComponentKey, ObjectModel>();
            ObjectMeshLoader meshLoader;
            foreach (KeyValuePair<ObjectModel.ComponentKey, string> meshFile in _meshFiles)
            {
                meshLoader = new ObjectMeshLoader(meshFile.Value);
                meshModels.Add(meshFile.Key, new SingularObjectModel(meshLoader.ExtractObjectMesh(ObjectMeshLoader.LoadMode.Normal)));
            }

            for(int i = SpiderHiearchyPackage.HP.ComponentMap.Count - 1; i >= 0; i--)
            {
                KeyValuePair<ObjectModel.ComponentKey, List<ObjectModel.ComponentKey>> compMap = SpiderHiearchyPackage.HP.ComponentMap.ElementAt(i);
                if (compMap.Value.Count > 1)
                {
                    ObjectModel.ComponentKey parentComp;
                    if (compMap.Value.Count > 2)
                    {
                        parentComp = compMap.Value[compMap.Value.Count - 3];
                    }
                    else
                    {
                        parentComp = compMap.Value[compMap.Value.Count - 1];
                    }

                    if (meshModels[parentComp].GetStructType() != ObjectModel.StructType.Hierarchical)
                    {
                        SingularObjectModel primaryComp = meshModels[parentComp] as SingularObjectModel;
                        meshModels[parentComp] = new HierarchicalObjectModel(primaryComp);
                    }
                    (meshModels[parentComp] as HierarchicalObjectModel).InsertSubComp(compMap.Key, new TransformableObject(meshModels[compMap.Key]));
                }
            }
            return meshModels[SpiderHiearchyPackage.body];
        }

    }

    public class SpiderHiearchyPackage : HierarchyPackage
    {
        public static ObjectModel.ComponentKey body  = SingularObjectModel.SingularCompID;
        public static ObjectModel.ComponentKey uleg1 = new ObjectModel.ComponentKey() { ID = "uleg1" };
        public static ObjectModel.ComponentKey uleg2 = new ObjectModel.ComponentKey() { ID = "uleg2" };
        public static ObjectModel.ComponentKey uleg3 = new ObjectModel.ComponentKey() { ID = "uleg3" };
        public static ObjectModel.ComponentKey uleg4 = new ObjectModel.ComponentKey() { ID = "uleg4" };
        public static ObjectModel.ComponentKey uleg5 = new ObjectModel.ComponentKey() { ID = "uleg5" };
        public static ObjectModel.ComponentKey uleg6 = new ObjectModel.ComponentKey() { ID = "uleg6" };
        public static ObjectModel.ComponentKey uleg7 = new ObjectModel.ComponentKey() { ID = "uleg7" };
        public static ObjectModel.ComponentKey uleg8 = new ObjectModel.ComponentKey() { ID = "uleg8" };
        public static ObjectModel.ComponentKey bleg1 = new ObjectModel.ComponentKey() { ID = "bleg1" };
        public static ObjectModel.ComponentKey bleg2 = new ObjectModel.ComponentKey() { ID = "bleg2" };
        public static ObjectModel.ComponentKey bleg3 = new ObjectModel.ComponentKey() { ID = "bleg3" };
        public static ObjectModel.ComponentKey bleg4 = new ObjectModel.ComponentKey() { ID = "bleg4" };
        public static ObjectModel.ComponentKey bleg5 = new ObjectModel.ComponentKey() { ID = "bleg5" };
        public static ObjectModel.ComponentKey bleg6 = new ObjectModel.ComponentKey() { ID = "bleg6" };
        public static ObjectModel.ComponentKey bleg7 = new ObjectModel.ComponentKey() { ID = "bleg7" };
        public static ObjectModel.ComponentKey bleg8 = new ObjectModel.ComponentKey() { ID = "bleg8" };

        private static readonly Dictionary<ObjectModel.ComponentKey, List<ObjectModel.ComponentKey>> _compMap
            = new Dictionary<ObjectModel.ComponentKey, List<ObjectModel.ComponentKey>>()
            {
                { body,  new List<ObjectModel.ComponentKey>() { } },
                { uleg1, new List<ObjectModel.ComponentKey>() { uleg1 } },
                { uleg2, new List<ObjectModel.ComponentKey>() { uleg2 } },
                { uleg3, new List<ObjectModel.ComponentKey>() { uleg3 } },
                { uleg4, new List<ObjectModel.ComponentKey>() { uleg4 } },
                { uleg5, new List<ObjectModel.ComponentKey>() { uleg5 } },
                { uleg6, new List<ObjectModel.ComponentKey>() { uleg6 } },
                { uleg7, new List<ObjectModel.ComponentKey>() { uleg7 } },
                { uleg8, new List<ObjectModel.ComponentKey>() { uleg8 } },
                { bleg1, new List<ObjectModel.ComponentKey>() { uleg1, bleg1 } },
                { bleg2, new List<ObjectModel.ComponentKey>() { uleg2, bleg2 } },
                { bleg3, new List<ObjectModel.ComponentKey>() { uleg3, bleg3 } },
                { bleg4, new List<ObjectModel.ComponentKey>() { uleg4, bleg4 } },
                { bleg5, new List<ObjectModel.ComponentKey>() { uleg5, bleg5 } },
                { bleg6, new List<ObjectModel.ComponentKey>() { uleg6, bleg6 } },
                { bleg7, new List<ObjectModel.ComponentKey>() { uleg7, bleg7 } },
                { bleg8, new List<ObjectModel.ComponentKey>() { uleg8, bleg8 } },
            };

        public static readonly SpiderHiearchyPackage HP = new SpiderHiearchyPackage();

        private SpiderHiearchyPackage() : base(_compMap) {}
    }
}
