using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenGL_Project.Configurations;
using OpenGL_Project.HelperTools;
using OpenTK.Graphics.OpenGL4;

namespace OpenGL_Project.Graphics
{
    public class ShaderProgram
    {
        private const string _vertexShaderFile = "Graphics\\Shaders\\VertexShader.glsl";
        private const string _fragmentShaderFile = "Graphics\\Shaders\\FragmentShader.glsl";
        public const int MAX_JOINTS = 15;

        private int _vertexShaderProgramId;
        private int _fragmentShaderProgramId;
        private int _programId;

        private List<int> _jointTransformLocs, _jointIDefaultTransformLocs;
        private int _modelUniformLoc, _viewUniformLoc, _projectionUniformLoc;
        private int _ambientCoefficientUniformLoc, _diffuseCoefficientUniformLoc, _specularCoefficientUniformLoc, _shininessCoefficientUniformLoc;
        private int _lightColorUniformLoc, _lightDirectionUniformLoc;
        private int _positionAttrLoc, _colorAttrLoc, _normalVecAttrLoc, _jointIndexAttrLoc, _jointCoeffAttrLoc;

        public ShaderProgram()
        {
            this._jointTransformLocs = new List<int>();
            this._jointTransformLocs.Capacity = MAX_JOINTS;
            this._jointIDefaultTransformLocs = new List<int>();
            this._jointIDefaultTransformLocs.Capacity = MAX_JOINTS;
        }

        public bool InitializeProgram()
        {
            if (!_disposed) return false;

            using (FileHandler fileHandler = new FileHandler(_vertexShaderFile))
            {
                fileHandler.ExtractData();
                _vertexShaderProgramId = GL.CreateShader(ShaderType.VertexShader);
                GL.ShaderSource(_vertexShaderProgramId, fileHandler.GetSourceData());
                GL.CompileShader(_vertexShaderProgramId);
                Console.WriteLine(GL.GetShaderInfoLog(_vertexShaderProgramId));
            }

            using (FileHandler fileHandler = new FileHandler(_fragmentShaderFile))
            {
                fileHandler.ExtractData();
                _fragmentShaderProgramId = GL.CreateShader(ShaderType.FragmentShader);
                GL.ShaderSource(_fragmentShaderProgramId, fileHandler.GetSourceData());
                GL.CompileShader(_fragmentShaderProgramId);
                Console.WriteLine(GL.GetShaderInfoLog(_fragmentShaderProgramId));
            }

            _programId = GL.CreateProgram();
            GL.AttachShader(_programId, _vertexShaderProgramId);
            GL.AttachShader(_programId, _fragmentShaderProgramId);
            GL.LinkProgram(_programId);

            _modelUniformLoc = GL.GetUniformLocation(_programId, "model");
            _viewUniformLoc = GL.GetUniformLocation(_programId, "view");
            _projectionUniformLoc = GL.GetUniformLocation(_programId, "projection");

            for (int i = 0; i < MAX_JOINTS; i++)
            {
                _jointTransformLocs.Add(GL.GetAttribLocation(_programId, "joints[" + i + "].transform"));
                _jointIDefaultTransformLocs.Add(GL.GetAttribLocation(_programId, "joints[" + i + "].idefaultTransform"));
            }
            
            _ambientCoefficientUniformLoc = GL.GetUniformLocation(_programId, "ambientCoefficient");
            _diffuseCoefficientUniformLoc = GL.GetUniformLocation(_programId, "diffuseCoefficient");
            _specularCoefficientUniformLoc = GL.GetUniformLocation(_programId, "specularCoefficient");
            _shininessCoefficientUniformLoc = GL.GetUniformLocation(_programId, "shininessCoefficient");

            _lightColorUniformLoc = GL.GetUniformLocation(_programId, "lightColor");
            _lightDirectionUniformLoc = GL.GetUniformLocation(_programId, "lightDirection");

            _positionAttrLoc = GL.GetAttribLocation(_programId, "position");
            _colorAttrLoc = GL.GetAttribLocation(_programId, "color");
            _normalVecAttrLoc = GL.GetAttribLocation(_programId, "normal");
            _jointIndexAttrLoc = GL.GetAttribLocation(_programId, "jointIndex");
            _jointCoeffAttrLoc = GL.GetAttribLocation(_programId, "jointCoefficient");

            _disposed = false;
            return true;
        }

        public bool Activate()
        {
            GLConfig glConfig = AppConfig.GetService<GLConfig>();
            if (!_disposed)
            {
                GL.UseProgram(_programId);
                glConfig.ModelUniformLoc = _modelUniformLoc;
                glConfig.ViewUniformLoc = _viewUniformLoc;
                glConfig.ProjectionUniformLoc = _projectionUniformLoc;
                for (int i = 0; i < MAX_JOINTS; i++) glConfig.JointTransformLocs.Add(_jointTransformLocs[i]);
                for (int i = 0; i < MAX_JOINTS; i++) glConfig.JointIDefaultTransformLocs.Add(_jointIDefaultTransformLocs[i]);
                glConfig.AmbientCoefficientUniformLoc = _ambientCoefficientUniformLoc;
                glConfig.DiffuseCoefficientUniformLoc = _diffuseCoefficientUniformLoc;
                glConfig.SpecularCoefficientUniformLoc = _specularCoefficientUniformLoc;
                glConfig.ShininessCoefficientUniformLoc = _shininessCoefficientUniformLoc;
                glConfig.LightColorUniformLoc = _lightColorUniformLoc;
                glConfig.LightDirectionUniformLoc = _lightDirectionUniformLoc;
                glConfig.PositionAttrLoc = _positionAttrLoc;
                glConfig.ColorAttrLoc = _colorAttrLoc;
                glConfig.NormalVecAttrLoc = _normalVecAttrLoc;
                glConfig.JointIndexAttrLoc = _jointIndexAttrLoc;
                glConfig.JointCoeffAttrLoc = _jointCoeffAttrLoc;
                return true;
            }
           return false; 
        }

        private bool _disposed = true;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                GL.DetachShader(_programId, _vertexShaderProgramId);
                GL.DetachShader(_programId, _fragmentShaderProgramId);
                GL.DeleteShader(_vertexShaderProgramId);
                GL.DeleteShader(_fragmentShaderProgramId);
                GL.DeleteProgram(_programId);
                _disposed = true;
            }
        }

    }
}
