using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenGL_Project.Geometry;
using OpenTK.Graphics;

namespace OpenGL_Project.Graphics
{
    class RenderableCubeObject : RenderableObject
    {

        private const string _meshFile = "Graphics\\Models\\MeshModels\\Cube.obj";
        private static ObjectModel _model = GetObjectModel();
        private static ColorPackage _colorPackage;

        private static ObjectModel GetObjectModel()
        {
            ObjectMeshLoader meshLoader = new ObjectMeshLoader(_meshFile);
            SingularObjectModel model = new SingularObjectModel(meshLoader.ExtractObjectMesh(ObjectMeshLoader.LoadMode.Normal));

            Color4 defaultColor = new Color4(0.66f, 0.99f, 0.99f, 1.0f);
            List<Coordinate> coords = model.GetCoordinates();
            List<Color4> colors = new List<Color4>();
            foreach (Coordinate coord in coords) colors.Add(defaultColor);
            _colorPackage = new ColorPackage(coords, colors);

            return model;
        }

        public RenderableCubeObject() : base(new SealedTransformableObject(_model, HierarchyPackage.SingularHierarchyPack), _colorPackage)
        {

        }

    }
}
