using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace OpenGL_Project.Graphics
{
    public class Material
    {

        public static readonly Vector4 DefaultAmbient = new Vector4(0.1f, 0.1f, 0.1f, 1.0f);
        public static readonly Vector4 DefaultDiffuse = new Vector4(0.8f, 0.8f, 0.8f, 1.0f);
        public static readonly Vector4 DefaultSpecular = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
        public const float DefaultShininess = 3.0f;

        private Vector4 _ambientCoeff;
        private Vector4 _diffuseCoeff;
        private Vector4 _specularCoeff;
        private float _shininessCoeff;

        public Material(Vector4 ambientCoeff, Vector4 diffuseCoeff, Vector4 specularCoeff, float shininessCoeff)
        {
            this._ambientCoeff = ambientCoeff;
            this._diffuseCoeff = diffuseCoeff;
            this._specularCoeff = specularCoeff;
            this._shininessCoeff = shininessCoeff;
        }

        public Material(Material copy)
        {
            this._ambientCoeff = copy._ambientCoeff;
            this._diffuseCoeff = copy._diffuseCoeff;
            this._specularCoeff = copy._specularCoeff;
            this._shininessCoeff = copy._shininessCoeff;
        }

        public void SetAmbientCoeff(Vector4 coeff)
        {
            this._ambientCoeff = coeff;
            if (!_transform.Contains(MaterialEventArgs.MaterialEvent.Ambient))
            {
                _transform.Add(MaterialEventArgs.MaterialEvent.Ambient);
            }
        }

        public Vector4 GetAmbientCoeff()
        {
            return this._ambientCoeff;
        }

        public void SetDiffuseCoeff(Vector4 coeff)
        {
            this._diffuseCoeff = coeff;
            if (!_transform.Contains(MaterialEventArgs.MaterialEvent.Diffuse))
            {
                _transform.Add(MaterialEventArgs.MaterialEvent.Diffuse);
            }
        }

        public Vector4 GetDiffuseCoeff()
        {
            return this._diffuseCoeff;
        }

        public void SetSpecularCoeff(Vector4 coeff)
        {
            this._specularCoeff = coeff;
            if (!_transform.Contains(MaterialEventArgs.MaterialEvent.Specular))
            {
                _transform.Add(MaterialEventArgs.MaterialEvent.Specular);
            }
        }

        public Vector4 GetSpecularCoeff()
        {
            return this._specularCoeff;
        }

        public void SetShininessCoeff(float coeff)
        {
            this._shininessCoeff = coeff;
            if (!_transform.Contains(MaterialEventArgs.MaterialEvent.Shininess))
            {
                _transform.Add(MaterialEventArgs.MaterialEvent.Shininess);
            }
        }

        public float GetShininessCoeff()
        {
            return this._shininessCoeff;
        }

        private List<MaterialEventArgs.MaterialEvent> _transform = new List<MaterialEventArgs.MaterialEvent>()
        {
            MaterialEventArgs.MaterialEvent.Ambient,
            MaterialEventArgs.MaterialEvent.Diffuse,
            MaterialEventArgs.MaterialEvent.Specular,
            MaterialEventArgs.MaterialEvent.Shininess
        };
        public MaterialEventHandler TransformHandler;
        public void Transform()
        {
            if (TransformHandler != null)
            {
                TransformHandler.Invoke(this, new MaterialEventArgs(_transform));
                _transform.Clear();
            }
        }

        public delegate void MaterialEventHandler(Material sender, MaterialEventArgs args);

    }

    public class MaterialEventArgs : EventArgs
    {

        public enum MaterialEvent { Ambient, Diffuse, Specular, Shininess };

        public List<MaterialEvent> Transform;

        public MaterialEventArgs(List<MaterialEvent> transform)
        {
            this.Transform = new List<MaterialEvent>(transform);
        }

    }
}
