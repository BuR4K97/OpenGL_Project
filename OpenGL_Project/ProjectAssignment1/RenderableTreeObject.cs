using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenGL_Project.Geometry;
using OpenGL_Project.Graphics;

namespace OpenGL_Project.ProjectAssignment1
{
    class RenderableTreeObject : IRenderable
    {

        private RenderableTreeBodyObject _treeBody;
        private RenderableTreeFolliageObject _treeFolliage;

        public RenderableTreeObject()
        {
            this._treeBody = new RenderableTreeBodyObject();
            this._treeFolliage = new RenderableTreeFolliageObject();
        }

        public void Initialize()
        {
            _treeBody.Initialize();
            _treeFolliage.Initialize();

            Random randomGen = new Random();
            const float rotAngleUpperLim = (float)(2 * Math.PI), rotAngleLowerLim = 0.0f;
            const float scaleUpperLim = 1.08f, scaleLowerLim = 0.85f;

            float rotAngle = (float)randomGen.NextDouble() * (rotAngleUpperLim - rotAngleLowerLim) + rotAngleLowerLim;
            float scale = (float)randomGen.NextDouble() * (scaleUpperLim - scaleLowerLim) + scaleLowerLim;
            Rotate(rotAngle);
            Scale(scale);
            Transform();
        }

        public void Scale(float scale)
        {
            _treeBody.Scale(scale);
            _treeFolliage.Scale(scale);
        }

        public void Translate(Vector translate)
        {
            _treeBody.Translate(translate);
            _treeFolliage.Translate(translate);
        }

        public void Rotate(float angle)
        {
            _treeBody.Rotate(angle);
            _treeFolliage.Rotate(angle);
        }

        public void Transform()
        {
            _treeBody.Transform();
            _treeFolliage.Transform();
        }

        public void Render()
        {
            _treeFolliage.Render();
            _treeBody.Render();
        }

    }
}
