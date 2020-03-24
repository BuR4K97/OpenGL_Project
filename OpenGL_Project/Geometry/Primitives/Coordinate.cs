using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL_Project.Geometry
{
    public class Coordinate : IEquatable<Coordinate>
    {
        public const int DimensionNumber = 3;
        public static readonly Coordinate Origin = new Coordinate(0.0f, 0.0f, 0.0f);

        public float XCoord, YCoord, ZCoord;

        public Coordinate()
        {
            this.XCoord = 0.0f;
            this.YCoord = 0.0f;
            this.ZCoord = 0.0f;
        }

        public Coordinate(float xCoord, float yCoord, float zCoord)
        {
            this.XCoord = xCoord;
            this.YCoord = yCoord;
            this.ZCoord = zCoord;
        }

        public Coordinate(Coordinate copy)
        {
            this.XCoord = copy.XCoord;
            this.YCoord = copy.YCoord;
            this.ZCoord = copy.ZCoord;
        }

        public bool Equals(Coordinate other)
        {
            return (XCoord == other.XCoord) && (YCoord == other.YCoord) && (ZCoord == other.ZCoord);
        }

        public static float GetXCoordDiff(Coordinate source, Coordinate target)
        {
            return target.XCoord - source.XCoord;
        }

        public static float GetYCoordDiff(Coordinate source, Coordinate target)
        {
            return target.YCoord - source.YCoord;
        }

        public static float GetZCoordDiff(Coordinate source, Coordinate target)
        {
            return target.ZCoord - source.ZCoord;
        }

        public static float GetDistance(Coordinate source, Coordinate target)
        {
            return (float) Math.Sqrt(Math.Pow(Convert.ToDouble(source.XCoord - target.XCoord), 2) + Math.Pow(Convert.ToDouble(source.YCoord - target.YCoord), 2)
                    + Math.Pow(Convert.ToDouble(source.ZCoord - target.ZCoord), 2));
        }

        public static Coordinate FindJointCoord(List<Coordinate> coords)
        {
            float xCoordMean = 0.0f, yCoordMean = 0.0f, zCoordMean = 0.0f;
            foreach (Coordinate coord in coords)
            {
                xCoordMean += coord.XCoord;
                yCoordMean += coord.YCoord;
                zCoordMean += coord.ZCoord;
            }
            xCoordMean /= coords.Count;
            yCoordMean /= coords.Count;
            zCoordMean /= coords.Count;
            return new Coordinate(xCoordMean, yCoordMean, zCoordMean);
        }

        public void normalize()
        {
            float magnitude = GetDistance(Origin, this);
            XCoord /= magnitude;
            YCoord /= magnitude;
            ZCoord /= magnitude;
        }
    }
}
