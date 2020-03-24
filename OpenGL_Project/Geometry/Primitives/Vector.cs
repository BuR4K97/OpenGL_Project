using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace OpenGL_Project.Geometry
{
    public class Vector : IEquatable<Vector>
    {
        public static Vector ZeroVec = new Vector(0.0f, 0.0f, 0.0f);

        public float XComp, YComp, ZComp;

        public Vector()
        {
            this.XComp = 0.0f;
            this.YComp = 0.0f;
            this.ZComp = 0.0f;
        }

        public Vector(float xComp, float yComp, float zComp)
        {
            this.XComp = xComp;
            this.YComp = yComp;
            this.ZComp = zComp;
        }

        public Vector(Vector copy)
        {
            this.XComp = copy.XComp;
            this.YComp = copy.YComp;
            this.ZComp = copy.ZComp;
        }

        public Vector(Coordinate source, Coordinate target)
        {
            this.XComp = target.XCoord - source.XCoord;
            this.YComp = target.YCoord - source.YCoord;
            this.ZComp = target.ZCoord - source.ZCoord;
        }

        public bool Equals(Vector other)
        {
            if (other == null) return false;
            return (XComp == other.XComp) && (YComp == other.YComp) && (ZComp == other.ZComp);
        }

        public void SetXYZ(float xComp, float yComp, float zComp)
        {
            this.XComp = xComp;
            this.YComp = yComp;
            this.ZComp = zComp;
        }

        public float GetLength()
        {
            return (float) Math.Sqrt(Math.Pow(XComp, 2) + Math.Pow(YComp, 2) + Math.Pow(ZComp, 2));
        }

        public void Scale(float scale)
        {
            XComp *= scale;
            YComp *= scale;
            ZComp *= scale;
        }

        public void Translate(Vector magnitude)
        {
            XComp += magnitude.XComp;
            YComp += magnitude.YComp;
            ZComp += magnitude.ZComp;
        }

        public void Rotate(Vector axis, float angle)
        {
            if (axis.Equals(ZeroVec) || angle == 0.0f) return;

            Matrix4 transform = Matrix4.CreateFromAxisAngle(new Vector3(axis.XComp, axis.YComp, axis.ZComp), angle);
            Vector4 transformed =  Vector4.Transform(transform, new Vector4(XComp, YComp, ZComp, 1.0f));
            XComp = transformed.X;
            YComp = transformed.Y;
            ZComp = transformed.Z;
        }

        public void normalize()
        {
            float magnitude = GetLength();
            XComp /= magnitude;
            YComp /= magnitude;
            ZComp /= magnitude;
        }

        public static Coordinate TranslateCoord(Vector magnitude, Coordinate translate)
        {
            return new Coordinate(translate.XCoord + magnitude.XComp, translate.YCoord + magnitude.YComp, translate.ZCoord + magnitude.ZComp);
        }

        public static bool CompareDirection(Vector source, Vector target)
        {
            float compRate = source.XComp / target.XComp;
            if (compRate != source.YComp / target.YComp) return false;
            return compRate == source.ZComp / target.ZComp;
        }

        public static bool ComparePerpendicular(Vector source, Vector target)
        {
            return  (source.XComp * target.XComp) + (source.YComp * target.YComp) + (source.ZComp * target.ZComp) == 0.0f;
        }

        public static Vector Add(Vector source, Vector target)
        {
            return new Vector(source.XComp + target.XComp, source.YComp + target.YComp, source.ZComp + target.ZComp);
        }

        public static float DotProduct(Vector source, Vector target)
        {
            return (source.XComp * target.XComp) + (source.YComp * target.YComp) + (source.ZComp * target.ZComp);
        }

        public static Vector CrossProduct(Vector source, Vector target)
        {
            return new Vector(source.YComp * target.ZComp - source.ZComp * target.YComp
                                        , source.ZComp * target.XComp - source.XComp * target.ZComp
                                        , source.XComp * target.YComp - source.YComp * target.XComp);
        }

        public static float FindAngleBetween(Vector source, Vector target)
        {
            Vector rotationAxis = Vector.CrossProduct(source, target);
            if (rotationAxis.GetLength() != 0)
            {
                Vector relativeAxis = Vector.CrossProduct(source, rotationAxis);
                double lengthMul = source.GetLength() * target.GetLength();
                double sinAngle = rotationAxis.GetLength() / lengthMul;
                double cosAngle = Vector.DotProduct(source, target) / lengthMul;
                double cosRelativeAngle = Vector.DotProduct(relativeAxis, target) / (relativeAxis.GetLength() * target.GetLength());
                double angle = Math.Asin(sinAngle);
                if (cosAngle < 0)
                {
                    if (cosRelativeAngle > 0) angle = Math.PI + angle;
                    else angle = Math.PI - angle;
                }
                else if (cosRelativeAngle > 0) angle = -angle;
                return (float)angle;
            }
            else
            {
                if (source.GetLength() == 0 || target.GetLength() == 0) return 0.0f;
                if (source.XComp / target.XComp > 0) return 0.0f;
                return (float) Math.PI;
            }
        }

    }
}
