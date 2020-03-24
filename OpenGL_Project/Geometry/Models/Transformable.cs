using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace OpenGL_Project.Geometry
{
    public abstract class Transformable
    {

        protected Matrix4 Rotation;
        protected Vector Translation; 
        protected Vector Scaling;

        public Transformable()
        {
            Rotation = Matrix4.CreateFromAxisAngle(new Vector3(0.0f, 0.0f, 1.0f), 0.0f);
            Translation = new Vector(0.0f, 0.0f, 0.0f);
            Scaling = new Vector(1.0f, 1.0f, 1.0f);
        }

        public void Translate(Vector magnitude)
        {
            Translation.Translate(magnitude);
            if(!_transform.Contains(TransformEventArgs.TransformEvent.Translation))
            {
                _transform.Add(TransformEventArgs.TransformEvent.Translation);
            }
        }

        public Vector GetTranslation()
        {
            return Translation;
        }

        public void Rotate(Vector axis, float angle)
        {
            if (axis.Equals(Vector.ZeroVec) || angle == 0.0f) return;

            Rotation = Rotation * Matrix4.CreateFromAxisAngle(new Vector3(axis.XComp, axis.YComp, axis.ZComp), angle);
            if (!_transform.Contains(TransformEventArgs.TransformEvent.Rotation))
            {
                _transform.Add(TransformEventArgs.TransformEvent.Rotation);
            }
        }

        public Matrix4 GetRotation()
        {
            return Rotation;
        }

        public virtual void Scale(Vector magnitude)
        {
            Scaling.SetXYZ(Scaling.XComp * magnitude.XComp, Scaling.YComp * magnitude.YComp, Scaling.ZComp * magnitude.ZComp);
            if (!_transform.Contains(TransformEventArgs.TransformEvent.Scaling))
            {
                _transform.Add(TransformEventArgs.TransformEvent.Scaling);
            }
        }

        public Vector GetScaling()
        {
            return Scaling;
        }

        private bool transformed = true;
        private Matrix4 transform = Matrix4.Identity;
        public Matrix4 GetTransform()
        {
            if (transformed)
            {
                transform = Matrix4.CreateScale(Scaling.XComp, Scaling.YComp, Scaling.ZComp) * Rotation
                * Matrix4.CreateTranslation(Translation.XComp, Translation.YComp, Translation.ZComp);
                transformed = false;
            }
            return transform;
        }

        private List<TransformEventArgs.TransformEvent> _transform = new List<TransformEventArgs.TransformEvent>()
        {
            TransformEventArgs.TransformEvent.Translation,
            TransformEventArgs.TransformEvent.Rotation,
            TransformEventArgs.TransformEvent.Scaling
        };
        public TransformEventHandler TransformHandler;
        public void Transform()
        {
            if (TransformHandler != null && _transform.Count > 0)
            {
                transformed = true;
                TransformHandler.Invoke(this, new TransformEventArgs(_transform));
                _transform.Clear();
            }
        }

        public delegate void TransformEventHandler(Transformable sender, TransformEventArgs args);

    }

    public class TransformEventArgs : EventArgs
    {
        public enum TransformEvent { Translation, Rotation, Scaling }

        public List<TransformEvent> Transform;

        public TransformEventArgs(List<TransformEvent> transform)
        {
            this.Transform = new List<TransformEvent>(transform);
        }
    }
}
