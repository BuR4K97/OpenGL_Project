using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenGL_Project.Geometry;
using OpenGL_Project.Graphics;
using OpenTK.Graphics;

namespace OpenGL_Project.ProjectAssignment2
{
    class RenderableSpider : RenderableObject
    {

        private static Dictionary<ObjectModel.ComponentKey, Color4> compColors = new Dictionary<ObjectModel.ComponentKey, Color4>()
        {
            { SpiderHiearchyPackage.body, new Color4(0.0f, 0.0f, 0.0f, 1.0f) },
            { SpiderHiearchyPackage.uleg1, new Color4(0.3f, 0.05f, 0.09f, 1.0f) },
            { SpiderHiearchyPackage.uleg2, new Color4(0.3f, 0.05f, 0.09f, 1.0f) },
            { SpiderHiearchyPackage.uleg3, new Color4(0.3f, 0.05f, 0.09f, 1.0f) },
            { SpiderHiearchyPackage.uleg4, new Color4(0.3f, 0.05f, 0.09f, 1.0f) },
            { SpiderHiearchyPackage.uleg5, new Color4(0.3f, 0.05f, 0.09f, 1.0f) },
            { SpiderHiearchyPackage.uleg6, new Color4(0.3f, 0.05f, 0.09f, 1.0f) },
            { SpiderHiearchyPackage.uleg7, new Color4(0.3f, 0.05f, 0.09f, 1.0f) },
            { SpiderHiearchyPackage.uleg8, new Color4(0.3f, 0.05f, 0.09f, 1.0f) },
            { SpiderHiearchyPackage.bleg1, new Color4(0.6f, 0.1f, 0.18f, 1.0f) },
            { SpiderHiearchyPackage.bleg2, new Color4(0.6f, 0.1f, 0.18f, 1.0f) },
            { SpiderHiearchyPackage.bleg3, new Color4(0.6f, 0.1f, 0.18f, 1.0f) },
            { SpiderHiearchyPackage.bleg4, new Color4(0.6f, 0.1f, 0.18f, 1.0f) },
            { SpiderHiearchyPackage.bleg5, new Color4(0.6f, 0.1f, 0.18f, 1.0f) },
            { SpiderHiearchyPackage.bleg6, new Color4(0.6f, 0.1f, 0.18f, 1.0f) },
            { SpiderHiearchyPackage.bleg7, new Color4(0.6f, 0.1f, 0.18f, 1.0f) },
            { SpiderHiearchyPackage.bleg8, new Color4(0.6f, 0.1f, 0.18f, 1.0f) },
        };
        private static ColorPackage _colorPackage = GetColorMap();

        private static ColorPackage GetColorMap()
        {
            Dictionary<ObjectModel.ComponentKey, List<GeometricObject>> identities = SpiderModel.Model.GetIdentities();
            ColorPackage _colorPackage = new ColorPackage();
            List<Coordinate> coords; List<Color4> colors;
            foreach (KeyValuePair<ObjectModel.ComponentKey, List<GeometricObject>> identity in identities)
            {
                coords = new List<Coordinate>(); colors = new List<Color4>();
                foreach (GeometricObject geobj in identity.Value)
                {
                    foreach (Coordinate coord in geobj.GetCoordinates())
                    {
                        if (coords.Contains(coord)) continue;
                        coords.Add(coord);
                    }
                }
                foreach (Coordinate coord in coords) colors.Add(compColors[identity.Key]);
                _colorPackage.Insert(coords, colors);
            }

            return _colorPackage;
        }

        public RenderableSpider(SealedTransformableObject sealedObject) : base(sealedObject, _colorPackage) {}

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
            const float transZ = 0.0f;
            const float scale = 1.0f;

            base.Process();
            SealedObject.Object.Translate(new Vector(0, 0, transZ));
            SealedObject.Object.Scale(new Vector(scale, scale, scale));
            SealedObject.Object.Transform();
        }

    }
 
}
