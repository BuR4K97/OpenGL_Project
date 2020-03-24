using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenGL_Project.Geometry;
using OpenGL_Project.Graphics;
using OpenTK.Graphics;

namespace OpenGL_Project.ProjectAssignment1
{
    class RenderableTreeFolliageObject : RenderableObject
    {

        private const string _meshFile = "Graphics\\Models\\MeshModels\\TreeFolliage.obj";
        private static ObjectModel _model = GetObjectModel();
        private static ColorPackage _colorPackage;

        private static ObjectModel GetObjectModel()
        {
            ObjectMeshLoader meshLoader = new ObjectMeshLoader(_meshFile);
            SingularObjectModel model = new SingularObjectModel(meshLoader.ExtractObjectMesh(ObjectMeshLoader.LoadMode.Normal));

            Color4 defaultColor = new Color4(0.10f, 0.30f, 0.09f, 1.0f);
            List<Coordinate> coords = model.GetCoordinates();
            List<Color4> colors = new List<Color4>();
            foreach (Coordinate coord in coords) colors.Add(defaultColor);
            _colorPackage = new ColorPackage(coords, colors);

            return model;
        }

        public RenderableTreeFolliageObject() : base(new SealedTransformableObject(_model, HierarchyPackage.SingularHierarchyPack), _colorPackage)
        {

        }

        public void Scale(float scale)
        {
            SealedObject.Object.Scale(new Vector(scale, scale, scale));
        }

        public void Translate(Vector translate)
        {
            SealedObject.Object.Translate(translate);
        }

        public void Rotate(float angle)
        {
            SealedObject.Object.Rotate(new Vector(0, 0, 1), angle);
        }

        public void Transform()
        {
            SealedObject.Object.Transform();
        }

        public void Initialize()
        {
            Random randomGen = new Random();
            const float transZ = 30.0f;

            base.Process();
            SealedObject.Object.Translate(new Vector(0, 0, transZ));
            SealedObject.Object.Transform();
        }

    }
}
