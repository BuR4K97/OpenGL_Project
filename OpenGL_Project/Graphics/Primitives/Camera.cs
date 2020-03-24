using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenGL_Project.Geometry;
using OpenTK;

namespace OpenGL_Project.Graphics
{
    public class Camera : Transformable
    {

        public const float DefaultFOV = (float) (90.0f / 180.0f * Math.PI);
        public const float DefaultAspectRatio = 4.0f / 3.0f;
        private const float DefaultNearPlane = 0.1f;
        private const float DefaultFarPlane = 100.0f;

        private float _fieldOfView;
        private float _aspectRatio;
        private readonly float _nearPlane;
        private readonly float _farPlane;

        public Camera(float fieldOfView = DefaultFOV, float aspectRatio = DefaultAspectRatio)
        {
            this._fieldOfView = fieldOfView;
            this._aspectRatio = aspectRatio;
            this._nearPlane = DefaultNearPlane;
            this._farPlane = DefaultFarPlane;
        }

        public void SetFOV(float angle)
        {
            if (angle >= 0.0f && angle <= Math.PI)
            {
                _fieldOfView = angle;
            }
            else
            {
                throw new InvalidFOVValueException();
            }

            if (!_attributeEvents.Contains(CameraAttributeEventArgs.AttributeEvent.FOV))
            {
                _attributeEvents.Add(CameraAttributeEventArgs.AttributeEvent.FOV);
            }
        }

        public void SetAspectRatio(float ratio)
        {
            _aspectRatio = ratio;

            if (!_attributeEvents.Contains(CameraAttributeEventArgs.AttributeEvent.AR))
            {
                _attributeEvents.Add(CameraAttributeEventArgs.AttributeEvent.AR);
            }
        }

        public override void Scale(Vector magnitude)
        {
            throw new InvalidCameraTransformationException();
        }

        private List<CameraAttributeEventArgs.AttributeEvent> _attributeEvents = new List<CameraAttributeEventArgs.AttributeEvent>() { CameraAttributeEventArgs.AttributeEvent.FOV };
        public CameraAttributeEventHandler AttributeEventHandler;
        public void ConfigureAttribute()
        {
            if (AttributeEventHandler != null && _attributeEvents.Count > 0)
            {
                AttributeEventHandler.Invoke(this, new CameraAttributeEventArgs(_attributeEvents));
                _attributeEvents.Clear();
            }
        }


        public Matrix4 GetView()
        {
            return Rotation * Matrix4.CreateTranslation(-Translation.XComp, -Translation.YComp, -Translation.ZComp);
        }

        public Matrix4 GetProjection()
        {
            float yScale = 1.0f / (float) Math.Tan(_fieldOfView / 2.0f);
            float xScale = yScale / _aspectRatio;
            float frustumLength = _farPlane - _nearPlane;

            Matrix4 projection = new Matrix4()
            {
                M11 = xScale,
                M22 = yScale,
                M33 = ((_farPlane + _nearPlane) / frustumLength),
                M34 = 1,
                M43 = -((2 * _nearPlane * _farPlane) / frustumLength),
                M44 = 0
            };
            return projection;
        }

        public delegate void CameraAttributeEventHandler(Camera sender, CameraAttributeEventArgs args);

    }

    public class CameraAttributeEventArgs : EventArgs
    {
        public enum AttributeEvent { FOV, AR }

        public List<AttributeEvent> AttributeEvents;

        public CameraAttributeEventArgs(List<AttributeEvent> attributeEvents)
        {
            this.AttributeEvents = new List<AttributeEvent>(attributeEvents);
        }
    }
}
