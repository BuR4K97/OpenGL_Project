using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenGL_Project.Geometry;
using OpenGL_Project.Graphics;

namespace OpenGL_Project.ProjectAssignment1
{
    class RenderableHomeObject : IRenderable
    {
        private RenderableHomeGroundObject _homeGround;
        private RenderableHomeFloorObject _homeFloor;
        private RenderableHomeFlueObject _homeFlue;

        public RenderableHomeObject()
        {
            this._homeGround = new RenderableHomeGroundObject();
            this._homeFloor = new RenderableHomeFloorObject();
            this._homeFlue = new RenderableHomeFlueObject();
        }

        public void Initialize()
        {
            _homeGround.Initialize();
            _homeFloor.Initialize();
            _homeFlue.Initialize();

            Random randomGen = new Random();

            const float rotAngleUpperLim = (float) (2 * Math.PI), rotAngleLowerLim = 0.0f;
            const float scaleUpperLim = 0.70f, scaleLowerLim = 0.52f;
            float rotAngle = (float) randomGen.NextDouble() * (rotAngleUpperLim - rotAngleLowerLim) + rotAngleLowerLim;
            float scale = (float)randomGen.NextDouble() * (scaleUpperLim - scaleLowerLim) + scaleLowerLim;
            Rotate(rotAngle);
            Scale(scale);
            Transform();
        }

        public void Scale(float scale)
        {
            _homeGround.Scale(scale);
            _homeFloor.Scale(scale);
            _homeFlue.Scale(scale);
        }

        public void Translate(Vector translate)
        {
            _homeGround.Translate(translate);
            _homeFloor.Translate(translate);
            _homeFlue.Translate(translate);
        }

        public void Rotate(float angle)
        {
            _homeGround.Rotate(angle);
            _homeFloor.Rotate(angle);
            _homeFlue.Rotate(angle);
        }

        public void Transform()
        {
            _homeGround.Transform();
            _homeFloor.Transform();
            _homeFlue.Transform();
        }

        public void Render()
        {
            _homeGround.Render();
            _homeFloor.Render();
            _homeFlue.Render();
        }
    }
}
