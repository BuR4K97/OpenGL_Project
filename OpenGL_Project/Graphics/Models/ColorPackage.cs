using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenGL_Project.Geometry;
using OpenTK.Graphics;

namespace OpenGL_Project.Graphics
{
    public class ColorPackage
    {
        public static readonly Color4 DefaultColor = new Color4(0.66f, 0.33f, 0.16f, 1.0f);

        public Dictionary<Coordinate, Color4> ColorMap;

        public ColorPackage()
        {
            this.ColorMap = new Dictionary<Coordinate, Color4>();
        }

        public ColorPackage(List<Coordinate> coords, List<Color4> colors)
        {
            this.ColorMap = new Dictionary<Coordinate, Color4>();
            for (int i = 0; i < coords.Count; i++)
            {
                this.ColorMap.Add(coords[i], colors[i]);
            }
        }

        public void Insert(Coordinate coord, Color4 color)
        {
            if (ColorMap.ContainsKey(coord))
            {
                ColorMap[coord] = color;
            }
            else
            {
                ColorMap.Add(coord, color);
            }
        }

        public void Insert(List<Coordinate> coords, List<Color4> colors)
        {
            for (int i = 0; i < coords.Count; i++)
            {
                if (ColorMap.ContainsKey(coords[i]))
                {
                    ColorMap[coords[i]] = colors[i];
                }
                else
                {
                    ColorMap.Add(coords[i], colors[i]);
                }
            }
        }
    }
}
