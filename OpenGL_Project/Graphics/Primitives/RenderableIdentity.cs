using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenGL_Project.Geometry;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Graphics;
using OpenTK;

namespace OpenGL_Project.Graphics
{
    public class RenderableIdentity : Renderable
    {
        private List<GeometricObject> _identity;
        private ColorPackage _colorPackage;
        private NormalPackage _normalPackage;
        private Dictionary<ObjectModel.ComponentKey, JointTransform> _jointTransforms;

        private readonly List<Vertex> _vertices;
        private GeometricObject.PolygonMode _polygonMode;

        public RenderableIdentity(List<GeometricObject> identity, ColorPackage colorPackage = null, NormalPackage normalPackage = null)
        {
            this._identity = identity;
            this._colorPackage = colorPackage;
            this._normalPackage = normalPackage;
            this._jointTransforms = new Dictionary<ObjectModel.ComponentKey, JointTransform>();
            this._vertices = new List<Vertex>();
            this._polygonMode = GeometricObject.PolygonMode.Invalid;
        }

        public void SetIdentity(List<GeometricObject> identity, ColorPackage colorPackage = null, NormalPackage normalPackage = null)
        {
            _identity = identity;
            _colorPackage = colorPackage;
            _normalPackage = normalPackage;
        }

        public void Process()
        {
            Indexing = BeginMode.Triangles;
            foreach (GeometricObject geometricObj in _identity)
            {
                SetPolygonMode(geometricObj.Mode);
            }
            if (_polygonMode == GeometricObject.PolygonMode.Quadratic)
            {
                Indexing = BeginMode.Quads;
            }

            Vector polygonNormal = null;
            foreach (GeometricObject geometricObj in _identity)
            {
                foreach (Polygon polygon in geometricObj.Polygons)
                {
                    if(_normalPackage == null) polygonNormal = polygon.GetNormalVec();
                    foreach (Coordinate coord in polygon.EdgeCoords)
                    {
                        int vertexIndex = _vertices.FindIndex(vertex => vertex.Coord.Equals(coord));
                        if (vertexIndex != -1 && _normalPackage == null)
                        {
                            _vertices[vertexIndex].IntegrateNormalVec(polygonNormal);
                        }
                        else
                        {
                            Vertex insert;
                            Color4 color = ColorPackage.DefaultColor;
                            Vector normal = polygonNormal;
                            if (_colorPackage != null) color = _colorPackage.ColorMap[coord];
                            if (_normalPackage != null) normal = _normalPackage.NormalMap[coord];
                            insert = new Vertex(coord, color, normal, Vertex.DefaultJointIndex, Vertex.DefaultJointCoeff);
                            _vertices.Add(insert);
                            vertexIndex = _vertices.Count - 1;
                        }
                        Indices.Add((uint) vertexIndex);
                    }
                }
            }
            foreach (Vertex vertex in _vertices)
            {
                Vertices.Add(vertex.GetVertexData());
            }
            BufferData();
            _vertices.Clear();
            _polygonMode = GeometricObject.PolygonMode.Invalid;
        }

        private void SetPolygonMode(GeometricObject.PolygonMode mode)
        {
            if (_polygonMode == GeometricObject.PolygonMode.Invalid)
            {
                if (mode == GeometricObject.PolygonMode.Triangular || mode == GeometricObject.PolygonMode.Quadratic)
                {
                    _polygonMode = mode;
                }
                else
                {
                    throw new InvalidRenderableIdentityException();
                }
            }
            else if (_polygonMode != mode)
            {
                throw new InvalidRenderableIdentityException();
            }
        }

        public void SetTransform(Matrix4 transform)
        {
            ModelUniform = transform;
        }

        public void SetJointTransform(ObjectModel.ComponentKey joint, Matrix4 transform)
        {
            if (_jointTransforms.TryGetValue(joint, out JointTransform jointTransform))
            {
                jointTransform.Transform = transform;
            }
            else
            {
                _jointTransforms.Add(joint, new JointTransform(transform));
                JointTransforms.Add(_jointTransforms[joint]);
            }
        }

        public void SetMaterialTransform(Vector4 ambientCoeff, Vector4 diffuseCoeff, Vector4 specularCoeff, float shininessCoeff)
        {
            AmbientCoeff = ambientCoeff;
            DiffuseCoeff = diffuseCoeff;
            SpecularCoeff = specularCoeff;
            ShininessCoeff = shininessCoeff;
        }

    }
}
