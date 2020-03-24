using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenGL_Project.Geometry;
using OpenGL_Project.Graphics;
using OpenTK;

namespace OpenGL_Project.ProjectAssignment1
{
    class AssignmentOneScene : OpenGLScene
    {
        private VillageGenerator _village;

        public AssignmentOneScene()
        {
            this._village = new VillageGenerator();
        }

        public override void Initialize(float cameraAR)
        {
            _village.Generate();
            SceneElements.AddRange(_village.GetRenderables());

            base.Initialize(cameraAR);
        }

        public void OnUpdate(Object sender, EventArgs args)
        {
            Camera.Rotate(new Vector(0, 1, 0), MathHelper.DegreesToRadians(1));
            Camera.Transform();
        }

        public void OnMouseDown(Coordinate position)
        {
            _village.Attractors.Add(new Attractor(_focusAttractor));
            float scaleX = 1920 / (2 * RenderableTerrainObject.MaxTerrainOffsetX);
            float scaleY = -1080 / (2 * RenderableTerrainObject.MaxTerrainOffsetY);
            Coordinate coord = new Coordinate(position.XCoord / scaleX, position.YCoord / scaleY, 0);
            coord.XCoord -= RenderableTerrainObject.MaxTerrainOffsetX;
            coord.YCoord += RenderableTerrainObject.MaxTerrainOffsetY;
            _village.Attractors.Last().Coord = coord;
            if (generate) { _village.Generate(); SceneElements.Clear(); SceneElements.AddRange(_village.GetRenderables()); }
        }

        bool generate = false;
        public void OnKeyPress(string key)
        {
            if (key.Contains("F", StringComparison.CurrentCultureIgnoreCase))
            {
                generate = !generate;
            }
            if (generate) { _village.Generate(); SceneElements.Clear(); SceneElements.AddRange(_village.GetRenderables()); }
        }

        private Attractor.AttractorType _focusAttractor = Attractor.AttractorType.None;
        public void OnMouseWheel(int delta)
        {
            int attractorValue;
            if (delta > 0)
            {
                attractorValue = (int)_focusAttractor + 1;
                if (attractorValue > (int)Attractor.AttractorType.Tree) attractorValue = (int)Attractor.AttractorType.None;
            }
            else
            {
                attractorValue = (int)_focusAttractor - 1;
                if (attractorValue < (int)Attractor.AttractorType.None) attractorValue = (int)Attractor.AttractorType.Tree;
            }
            _focusAttractor = (Attractor.AttractorType)attractorValue;
        }

    }
}
