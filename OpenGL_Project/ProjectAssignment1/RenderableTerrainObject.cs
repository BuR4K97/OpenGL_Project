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
    class RenderableTerrainObject : RenderableObject
    {

        private static ObjectModel _model = GetObjectModel();
        private static ColorPackage _colorPackage;

        private static ObjectModel GetObjectModel()
        {
            List<Coordinate> edgeCoords = new List<Coordinate>()
            {
                new Coordinate(0.5f, 0.5f, 0.0f),
                new Coordinate(0.5f, -0.5f, 0.0f),
                new Coordinate(-0.5f, -0.5f, 0.0f),
                new Coordinate(-0.5f, 0.5f, 0.0f),
            };
            List<Polygon> polygons = new List<Polygon>() { new Triangle(), new Triangle() };
            polygons[0].InsertEdgeCoord(edgeCoords[0]);
            polygons[0].InsertEdgeCoord(edgeCoords[1]);
            polygons[0].InsertEdgeCoord(edgeCoords[2]);

            polygons[1].InsertEdgeCoord(edgeCoords[2]);
            polygons[1].InsertEdgeCoord(edgeCoords[3]);
            polygons[1].InsertEdgeCoord(edgeCoords[0]);

            List<GeometricObject> geobj = new List<GeometricObject>() { new GeometricObject(polygons)};

            SingularObjectModel model = new SingularObjectModel(geobj);

            Color4 defaultColor = new Color4(0.035f, 0.70f, 0.36f, 1.0f);
            List<Coordinate> coords = model.GetCoordinates();
            List<Color4> colors = new List<Color4>();
            foreach (Coordinate coord in coords) colors.Add(defaultColor);
            _colorPackage = new ColorPackage(coords, colors);

            return model;
        }

        public RenderableTerrainObject() : base(new SealedTransformableObject(_model, HierarchyPackage.SingularHierarchyPack), _colorPackage)
        {

        }

        public const float MaxTerrainOffsetX = 48, MaxTerrainOffsetY = 26;
        public void Initialize()
        {
            const float transZ = 100.0f;
            const float scale = 1000.0f;

            base.Process();
            SealedObject.Object.Translate(new Vector(0, 0, transZ));
            SealedObject.Object.Scale(new Vector(scale, scale, scale));
            SealedObject.Object.Transform();
        }

    }
}
