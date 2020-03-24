using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenGL_Project.Configurations;
using OpenGL_Project.Geometry;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using OpenTK;


namespace OpenGL_Project.Graphics
{
    public class GLConfig : IConfig
    {

        public enum VertexAttrib { Position = 0, Color = 1, Normal = 2, JointIndex = 3, JointCoeff = 4 }
        public const int MajorGLVersion = 4, MinorGLVersion = 4;
        public const int MAX_JOINTS = ShaderProgram.MAX_JOINTS;
        public static readonly Color4 _defaultColor = new Color4(0.65f, 0.65f, 0.65f, 1.0f);

        public Coordinate ViewPortCoordLB, ViewPortCoordRU; 

        private ShaderProgram _shaderProgram;
        public List<int> JointTransformLocs, JointIDefaultTransformLocs;
        public int ModelUniformLoc, ViewUniformLoc, ProjectionUniformLoc;
        public int AmbientCoefficientUniformLoc, DiffuseCoefficientUniformLoc, SpecularCoefficientUniformLoc, ShininessCoefficientUniformLoc;
        public int LightColorUniformLoc, LightDirectionUniformLoc;
        public int PositionAttrLoc, ColorAttrLoc, NormalVecAttrLoc, JointIndexAttrLoc, JointCoeffAttrLoc;

        public GLConfig()
        {
            this.ViewPortCoordLB = new Coordinate();
            this.ViewPortCoordRU = new Coordinate();
            this.JointTransformLocs = new List<int>();
            this.JointTransformLocs.Capacity = MAX_JOINTS;
            this.JointIDefaultTransformLocs = new List<int>();
            this.JointIDefaultTransformLocs.Capacity = MAX_JOINTS;
        }

        public void Initialize()
        {
            GL.Viewport((int)ViewPortCoordLB.XCoord, (int)ViewPortCoordLB.YCoord
                , (int)Coordinate.GetXCoordDiff(ViewPortCoordLB, ViewPortCoordRU), (int)Coordinate.GetYCoordDiff(ViewPortCoordLB, ViewPortCoordRU));
            GL.ClearColor(_defaultColor);
            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.Blend);
            GL.DepthFunc(DepthFunction.Lequal);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

            _shaderProgram = new ShaderProgram();
            _shaderProgram.InitializeProgram();
            _shaderProgram.Activate();
        }

        public void UpdateViewPort(int lbXCorrd, int lbYCoord, int ruXCoord, int ruYCoord)
        {
            ViewPortCoordLB.XCoord = lbXCorrd;
            ViewPortCoordLB.YCoord = lbYCoord;
            ViewPortCoordRU.XCoord = ruXCoord;
            ViewPortCoordRU.YCoord = ruYCoord;
            GL.Viewport((int) ViewPortCoordLB.XCoord, (int) ViewPortCoordLB.YCoord
                , (int) Coordinate.GetXCoordDiff(ViewPortCoordLB, ViewPortCoordRU), (int) Coordinate.GetYCoordDiff(ViewPortCoordLB, ViewPortCoordRU));
        }

    }
}
