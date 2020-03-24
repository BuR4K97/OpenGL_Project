using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenGL_Project.Configurations;
using OpenTK.Graphics.OpenGL4;
using OpenTK;

namespace OpenGL_Project.Graphics
{
    public abstract class Renderable : IRenderable, IDisposable
    {
        protected List<VertexData> Vertices;
        protected List<uint> Indices;

        protected List<JointTransform> JointTransforms;
        protected BeginMode Indexing;
        protected Matrix4 ModelUniform;
        protected Vector4 AmbientCoeff;
        protected Vector4 DiffuseCoeff;
        protected Vector4 SpecularCoeff;
        protected float ShininessCoeff;

        private readonly int _vertexArrID, _vertexBufferID, _indexBufferID;

        protected Renderable()
        {
            this.Vertices = new List<VertexData>();
            this.Indices = new List<uint>();

            this.JointTransforms = new List<JointTransform>();
            this.JointTransforms.Capacity = GLConfig.MAX_JOINTS;
            this.Indexing = BeginMode.Triangles;
            this.ModelUniform = Matrix4.Identity;
            this.AmbientCoeff = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
            this.DiffuseCoeff = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
            this.SpecularCoeff = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
            this.ShininessCoeff = 1.0f;

            this._vertexArrID = GL.GenVertexArray();
            this._vertexBufferID = GL.GenBuffer();
            this._indexBufferID = GL.GenBuffer();
        }

        private int IndicesCount;
        public void BufferData()
        {
            GLConfig glConfig = AppConfig.GetService<GLConfig>();
            List<float> bufferData = new List<float>();
            foreach (VertexData vertex in Vertices) bufferData.AddRange(vertex.GetBufferData());

            GL.BindVertexArray(_vertexArrID);
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferID);
            GL.BufferData(BufferTarget.ArrayBuffer, bufferData.Count * VertexData.FloatByteCount, bufferData.ToArray(), BufferUsageHint.DynamicDraw);

            GL.VertexAttribPointer(glConfig.PositionAttrLoc, VertexData.PositionElementCount, VertexAttribPointerType.Float, false
                , VertexData.VertexByteCount, VertexData.PositionOffset);
            GL.VertexAttribPointer(glConfig.ColorAttrLoc, VertexData.ColorElementCount, VertexAttribPointerType.Float, false
                , VertexData.VertexByteCount, VertexData.ColorOffset);
            GL.VertexAttribPointer(glConfig.NormalVecAttrLoc, VertexData.NormalVecElementCount, VertexAttribPointerType.Float, false
                , VertexData.VertexByteCount, VertexData.NormalVecOffset);
            GL.VertexAttribPointer(glConfig.JointIndexAttrLoc, VertexData.JointIndexElementCount, VertexAttribPointerType.Int, false
                , VertexData.VertexByteCount, VertexData.JointIndexOffset);
            GL.VertexAttribPointer(glConfig.JointCoeffAttrLoc, VertexData.JointCoeffElementCount, VertexAttribPointerType.Float, false
                , VertexData.VertexByteCount, VertexData.JointCoeffOffset);

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, _indexBufferID);
            GL.BufferData(BufferTarget.ElementArrayBuffer, Indices.Count * sizeof(uint), Indices.ToArray(), BufferUsageHint.DynamicDraw);

            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindVertexArray(0);

            IndicesCount = Indices.Count;
            Vertices.Clear();
            Indices.Clear();
        }

        public void Render()
        {
            GLConfig glConfig = AppConfig.GetService<GLConfig>();

            GL.UniformMatrix4(glConfig.ModelUniformLoc, false, ref ModelUniform);
            for (int i = 0; i < JointTransforms.Count; i++)
            {
                GL.UniformMatrix4(glConfig.JointTransformLocs[i], false, ref JointTransforms[i].Transform);
                GL.UniformMatrix4(glConfig.JointIDefaultTransformLocs[i], false, ref JointTransforms[i].IDefaultTransform);
            }
            GL.Uniform4(glConfig.AmbientCoefficientUniformLoc, ref AmbientCoeff);
            GL.Uniform4(glConfig.DiffuseCoefficientUniformLoc, ref DiffuseCoeff);
            GL.Uniform4(glConfig.SpecularCoefficientUniformLoc, ref SpecularCoeff);
            GL.Uniform1(glConfig.ShininessCoefficientUniformLoc, ShininessCoeff);

            GL.BindVertexArray(_vertexArrID);
            GL.EnableVertexArrayAttrib(_vertexArrID, (int) GLConfig.VertexAttrib.Position);
            GL.EnableVertexArrayAttrib(_vertexArrID, (int) GLConfig.VertexAttrib.Color);
            GL.EnableVertexArrayAttrib(_vertexArrID, (int) GLConfig.VertexAttrib.Normal);
            GL.EnableVertexArrayAttrib(_vertexArrID, (int) GLConfig.VertexAttrib.JointIndex);
            GL.EnableVertexArrayAttrib(_vertexArrID, (int) GLConfig.VertexAttrib.JointCoeff);

            GL.DrawElements(Indexing, IndicesCount, DrawElementsType.UnsignedInt, 0);

            GL.DisableVertexArrayAttrib(_vertexArrID, (int) GLConfig.VertexAttrib.Position);
            GL.DisableVertexArrayAttrib(_vertexArrID, (int) GLConfig.VertexAttrib.Color);
            GL.DisableVertexArrayAttrib(_vertexArrID, (int) GLConfig.VertexAttrib.Normal);
            GL.DisableVertexArrayAttrib(_vertexArrID, (int) GLConfig.VertexAttrib.JointIndex);
            GL.DisableVertexArrayAttrib(_vertexArrID, (int) GLConfig.VertexAttrib.JointCoeff);
            GL.BindVertexArray(0);
        }

        public void Dispose()
        {
            GL.DeleteBuffer(_vertexBufferID);
            GL.DeleteBuffer(_indexBufferID);
            GL.DeleteVertexArray(_vertexArrID);
        }

    }

    public class JointTransform
    {
        public Matrix4 Transform;
        public Matrix4 IDefaultTransform;

        public JointTransform(Matrix4 transform)
        {
            this.Transform = transform;
            this.IDefaultTransform = transform;
        }
    }
}
