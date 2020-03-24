using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenGL_Project.Geometry;
using OpenGL_Project.Graphics;

namespace OpenGL_Project.ProjectAssignment1
{
    class VillageGenerator
    {

        private Dictionary<Entity, IRenderable> _entities;
        public List<Attractor> Attractors = new List<Attractor>();

        public VillageGenerator()
        {
            this._entities = new Dictionary<Entity, IRenderable>();
            this.Attractors = new List<Attractor>();
            Attractors.Add(new Attractor(Attractor.AttractorType.None));
            Attractors[0].Coord = new Coordinate(0, RenderableTerrainObject.MaxTerrainOffsetY / 2, 0.0f);
            Attractors.Add(new Attractor(Attractor.AttractorType.None));
            Attractors[1].Coord = new Coordinate(0, -RenderableTerrainObject.MaxTerrainOffsetY / 2, 0.0f);
        }

        public List<IRenderable> GetRenderables()
        {
            List<IRenderable> renderables = new List<IRenderable>();
            foreach (IRenderable renderable in _entities.Values)
            {
                renderables.Add(renderable);
            }
            return renderables;
        }

        public void FlushAttractors()
        {
            Attractors = Attractors.Take(2).ToList();
        }

        public void Generate()
        {
            _entities.Clear();

            RenderableTerrainObject terrain = new RenderableTerrainObject();
            terrain.Initialize();
            _entities.Add(new Entity(Coordinate.Origin), terrain);

            RenderableRiverObject river = new RenderableRiverObject();
            river.Initialize();
            _entities.Add(new Entity(Coordinate.Origin), river);

            float xCoordLowerLim = RenderableRiverObject.RiverOffset;
            float xCoordUpperLim = RenderableTerrainObject.MaxTerrainOffsetX;

            float yCoordLowerLim = 0;
            float yCoordUpperLim = RenderableTerrainObject.MaxTerrainOffsetY;

            float offsetValue = Entity.EntityRadius;

            float currXCoord, currYCoord;
            for (int i = 0; i < 2; i++) //Splitting up x dimension into 2 subcomponent (Negative and Positive)
            {
                int xStepCount = (int)((xCoordUpperLim - xCoordLowerLim) / offsetValue);
                for (int n = 0; n < 2; n++) //Splitting up y dimension into 2 subcomponent (Negative and positive)
                {
                    int yStepCount = (int)((yCoordUpperLim - yCoordLowerLim) / offsetValue);
                    for (int j = 0; j < Math.Abs(xStepCount) + 1; j++)
                    {
                        if (xStepCount < 0) currXCoord = xCoordLowerLim - j * offsetValue;
                        else currXCoord = xCoordLowerLim + j * offsetValue;
                        for (int k = 0; k < Math.Abs(yStepCount) + 1; k++)
                        {
                            if (yStepCount < 0)
                            {
                                if (k == 0) continue;
                                currYCoord = yCoordLowerLim - k * offsetValue;
                            }
                            else currYCoord = yCoordLowerLim + k * offsetValue;
                            _entities.Add(new Entity(new Coordinate(currXCoord, currYCoord, 0.0f)), null);
                        }
                    }
                    yCoordLowerLim *= -1;
                    yCoordUpperLim *= -1;
                }
                xCoordLowerLim *= -1;
                xCoordUpperLim *= -1;
            }

            //Attractors.Add(new Attractor(Attractor.AttractorType.Rock));
            //Attractors[0].Coord = new Coordinate(RenderableTerrainObject.MaxTerrainOffsetX, -RenderableTerrainObject.MaxTerrainOffsetY, 0.0f);
            //Attractors.Add(new Attractor(Attractor.AttractorType.Home));
            //Attractors[1].Coord = new Coordinate(-RenderableTerrainObject.MaxTerrainOffsetX, RenderableTerrainObject.MaxTerrainOffsetY, 0.0f);
            //Attractors.Add(new Attractor(Attractor.AttractorType.Tree));
            //Attractors[2].Coord = new Coordinate(-RenderableTerrainObject.MaxTerrainOffsetX, -RenderableTerrainObject.MaxTerrainOffsetY, 0.0f);
            //Attractors.Add(new Attractor(Attractor.AttractorType.Tree));
            //Attractors[3].Coord = new Coordinate(RenderableTerrainObject.MaxTerrainOffsetX, RenderableTerrainObject.MaxTerrainOffsetY, 0.0f);
           
            Random randomGen = new Random();
            Dictionary<Attractor, double> attractions = new Dictionary<Attractor, double>();
            foreach (Attractor attractor in Attractors) attractions.Add(attractor, 0);

            for (int i = 2; i < _entities.Count; i++)
            {
                Entity entity = _entities.ElementAt(i).Key;
                double totalAttraction = 0;
                foreach (Attractor attractor in Attractors)
                {
                    attractions[attractor] = attractor.GetProbabilisticAttraction(entity);
                    totalAttraction += attractions[attractor];
                }
                //attractions.OrderBy(x => x.Value);


                totalAttraction = randomGen.NextDouble() * totalAttraction;
                int currIndex = -1;
                while (totalAttraction > 0)
                {
                    currIndex++;
                    totalAttraction -= attractions.ElementAt(currIndex).Value;
                }
                //bool forward = true; int currIndex = 0;
                //while (true)
                //{
                //    totalAttraction -= attractions.ElementAt(currIndex).Value;
                //    if (totalAttraction > 0)
                //    {
                //        if (forward)
                //        {
                //            currIndex += 2;
                //            if (currIndex >= attractions.Count - 1)
                //            {
                //                forward = false;
                //                currIndex = attractions.Count - 1;
                //            }
                //        }
                //        else if (currIndex == attractions.Count - 1)
                //        {
                //            currIndex--;
                //        }
                //        else
                //        {
                //            currIndex -= 2;
                //        }
                //    }
                //    else break;
                //}
               
                switch (attractions.ElementAt(currIndex).Key.Type)
                {
                    case Attractor.AttractorType.Home:
                        {
                            RenderableHomeObject r = new RenderableHomeObject();
                            r.Initialize();
                            r.Translate(new Vector(Coordinate.Origin, entity.Position));
                            r.Transform();
                            _entities[entity] = r;
                            break;
                        }
                    case Attractor.AttractorType.Rock:
                        {
                            RenderableRockObject r = new RenderableRockObject();
                            r.Initialize();
                            r.Translate(new Vector(Coordinate.Origin, entity.Position));
                            r.Transform();
                            _entities[entity] = r;
                            break;
                        }
                    case Attractor.AttractorType.Tree:
                        {
                            RenderableTreeObject r = new RenderableTreeObject();
                            r.Initialize();
                            r.Translate(new Vector(Coordinate.Origin, entity.Position));
                            r.Transform();
                            _entities[entity] = r;
                            break;
                        }
                    default:
                        {
                            _entities.Remove(entity);
                            i--;
                            break;
                        }
                }
            }
        }
    }
}
