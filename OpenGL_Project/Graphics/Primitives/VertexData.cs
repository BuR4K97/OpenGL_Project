using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL_Project.Graphics
{
    public class VertexData
    {
        public const int FloatByteCount = sizeof(float);
        public const int IntegerByteCount = sizeof(int);

        public const int PositionElementCount = 4;
        public const int ColorElementCount = 4;
        public const int NormalVecElementCount = 3;
        public const int JointIndexElementCount = 1;
        public const int JointCoeffElementCount = 1;

        public const int PositionOffset = 0;
        public const int ColorOffset = PositionOffset + PositionElementCount * FloatByteCount;
        public const int NormalVecOffset = ColorOffset + ColorElementCount * FloatByteCount;
        public const int JointIndexOffset = NormalVecOffset + NormalVecElementCount * FloatByteCount;
        public const int JointCoeffOffset = JointIndexOffset + JointIndexElementCount * IntegerByteCount;
        public const int VertexByteCount = JointCoeffOffset + JointCoeffElementCount * FloatByteCount;

        public float[] Position = { 0.0f, 0.0f, 0.0f, 1.0f };
        public float[] Color = { 0.0f, 0.0f, 0.0f, 1.0f };
        public float[] NormalVec = { 0.0f, 0.0f, 0.0f };
        public int JointIndex = 0;
        public float JointCoeff = 0.0f;

        public VertexData SetXYZ(float x, float y, float z)
        {
            Position[0] = x;
            Position[1] = y;
            Position[2] = z;
            return this;
        }

        public VertexData SetRGBA(float r, float g, float b, float a)
        {
            Color[0] = r;
            Color[1] = g;
            Color[2] = b;
            Color[3] = a;
            return this;
        }

        public VertexData SetNormal(float x, float y, float z)
        {
            NormalVec[0] = x;
            NormalVec[1] = y;
            NormalVec[2] = z;
            return this;
        }

        public VertexData SetJointIndex(int i)
        {
            JointIndex = i;
            return this;
        }

        public VertexData SetJointCoeff(float c)
        {
            JointCoeff = c;
            return this;
        }

        public float[] GetBufferData()
        {
            float[] vertexArr = new float[PositionElementCount + ColorElementCount + NormalVecElementCount + JointIndexElementCount + JointCoeffElementCount];

            int currIndex = 0;
            for (int i = 0; i < PositionElementCount; i++) vertexArr[currIndex++] = Position[i];
            for (int i = 0; i < ColorElementCount; i++) vertexArr[currIndex++] = Color[i];
            for (int i = 0; i < NormalVecElementCount; i++) vertexArr[currIndex++] = NormalVec[i];
            vertexArr[currIndex++] = JointIndex;
            vertexArr[currIndex++] = JointCoeff;
            return vertexArr;
        }

    }
}
