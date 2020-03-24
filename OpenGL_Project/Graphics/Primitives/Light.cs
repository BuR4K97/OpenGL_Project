using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenGL_Project.Geometry;
using OpenTK.Graphics;

namespace OpenGL_Project.Graphics
{
    public class Light
    {
        public static readonly Vector DefaultDirection = new Vector(0.0f, 0.0f, 1.0f);
        public static readonly Color4 DefaultColor = Color4.White;

        public Vector Direction;
        public Color4 Color;

        public Light(Vector direction, Color4 color)
        {
            this.Direction = direction;
            this.Color = color;
        }

        public void SetDirection(Vector direction)
        {
            this.Direction = direction;
            if (!_transform.Contains(LightEventArgs.LightEvent.Direction))
            {
                _transform.Add(LightEventArgs.LightEvent.Direction);
            }
        }

        public void SetColor(Color4 color)
        {
            this.Color = color;
            if (!_transform.Contains(LightEventArgs.LightEvent.Color))
            {
                _transform.Add(LightEventArgs.LightEvent.Color);
            }
        }

        private List<LightEventArgs.LightEvent> _transform = new List<LightEventArgs.LightEvent>()
        {
            LightEventArgs.LightEvent.Direction,
            LightEventArgs.LightEvent.Color
        };
        public LightEventHandler TransformHandler;
        public void Transform()
        {
            if (TransformHandler != null && _transform.Count > 0)
            {
                TransformHandler.Invoke(this, new LightEventArgs(_transform));
                _transform.Clear();
            }
        }

        public delegate void LightEventHandler(Light sender, LightEventArgs args);

    }

    public class LightEventArgs : EventArgs
    {
        public enum LightEvent { Direction, Color }

        public List<LightEvent> Transform;

        public LightEventArgs(List<LightEvent> transform)
        {
            this.Transform = new List<LightEvent>(transform);
        }
    }
}
