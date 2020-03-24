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
    class RenderableRiverObject : RenderableObject
    {
        private const string _meshFile = "Graphics\\Models\\MeshModels\\River.obj";
        private static ObjectModel _model = GetObjectModel();
        private static ColorPackage _colorPackage;

        private static ObjectModel GetObjectModel()
        {
            ObjectMeshLoader meshLoader = new ObjectMeshLoader(_meshFile);
            SingularObjectModel model = new SingularObjectModel(meshLoader.ExtractObjectMesh(ObjectMeshLoader.LoadMode.Normal));

            Color4 defaultColor = new Color4(0.19f, 0.51f, 0.82f, 1.0f);
            List<Coordinate> coords = model.GetCoordinates();
            List<Color4> colors = new List<Color4>();
            foreach (Coordinate coord in coords) colors.Add(defaultColor);
            _colorPackage = new ColorPackage(coords, colors);

            return model;
        }

        public RenderableRiverObject() : base(new SealedTransformableObject(_model, HierarchyPackage.SingularHierarchyPack), _colorPackage)
        {

        }

        public const float RiverOffset = 16;
        public void Initialize()
        {
            Random randomGen = new Random();
            Vector trans = new Vector(0, 15.0f, 90.0f);
            const float scale = 5.2f;
            const float rotAngle = (float) Math.PI / 2;
            const float scaleYUpperLim = 7.6f, scaleYLowerLim = 5.2f;

            base.Process();
            float scaleY = (float)randomGen.NextDouble() * (scaleYUpperLim - scaleYLowerLim) + scaleYLowerLim;
            SealedObject.Object.Translate(trans);
            SealedObject.Object.Scale(new Vector(scale, scaleY, scale));
            SealedObject.Object.Rotate(new Vector(0, 0, 1), rotAngle);
            SealedObject.Object.Transform();
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

    }
}
