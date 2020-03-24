using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenGL_Project.Geometry;
using OpenGL_Project.Graphics;
using OpenTK.Input;
using OpenTK;

namespace OpenGL_Project.ProjectAssignment3
{
    class AssignmentThreeScene : OpenGLScene
    {

        private RenderableToroid _toroid;
        private RenderableHyperboloid _hyperboloid;

        public override void Initialize(float cameraAR)
        {
            _toroid = new RenderableToroid();
            _hyperboloid = new RenderableHyperboloid();

            _toroid.SetPhiResolParam(SuperquadricToroid.DefaultPhiResolParam);
            _toroid.SetThetaResolParam(SuperquadricToroid.DefaultThetaResolParam);
            _toroid.SetXCompParam(SuperquadricToroid.DefaultXCompParam);
            _toroid.SetYCompParam(SuperquadricToroid.DefaultYCompParam);
            _toroid.SetZCompParam(SuperquadricToroid.DefaultZCompParam);
            _toroid.SetOffsetParam(SuperquadricToroid.DefaultOffsetParam);
            _toroid.ReconstructModel();

            _toroid.Initialize();
            _hyperboloid.Initialize();
            SceneElements.Add(_toroid);

            base.Initialize(cameraAR);
        }

        public void OnUpdate(object sender, EventArgs args)
        {
            if (SceneElements.First() is RenderableToroid)
            {
                _toroid.Rotate(new Vector(1.0f, 1.0f, 0.1f), MathHelper.DegreesToRadians(1.0f));
                _toroid.Transform();
            }
            else
            {
                _hyperboloid.Rotate(new Vector(1.0f, 1.0f, 0.1f), MathHelper.DegreesToRadians(1.0f));
                _hyperboloid.Transform();
            }
            
        }

        public void GenerateModelEventHandler(ModelControl sender, GenerateModelEventArgs args)
        {
            if (args.Type == GenerateModelEventArgs.ModelType.SuperquadricToroid)
            {
                
                _toroid.SetPhiResolParam(args.PhiParam);
                _toroid.SetThetaResolParam(args.ThetaParam);
                _toroid.SetXCompParam(args.XScale);
                _toroid.SetYCompParam(args.YScale);
                _toroid.SetZCompParam(args.ZScale);
                _toroid.ReconstructModel();
                SceneElements.Clear();
                SceneElements.Add(_toroid);
            }
            else
            {
                _hyperboloid.SetPhiResolParam(args.PhiParam);
                _hyperboloid.SetThetaResolParam(args.ThetaParam);
                _hyperboloid.SetXCompParam(args.XScale);
                _hyperboloid.SetYCompParam(args.YScale);
                _hyperboloid.SetZCompParam(args.ZScale);
                _hyperboloid.ReconstructModel();
                SceneElements.Clear();
                SceneElements.Add(_hyperboloid);
            }
        }

        public void ZoomEventHandler(CameraControl sender, ZoomEventArgs args)
        {
            if (args.zoomScale == 0 || args.zoomScale == 10) return;
            Camera.SetFOV(MathHelper.DegreesToRadians(args.zoomScale * 18));
            Camera.ConfigureAttribute();
        }
    }
}
