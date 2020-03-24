using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using OpenGL_Project.Geometry;
using OpenGL_Project.HelperTools;


namespace OpenGL_Project.Graphics
{
    class ObjectMeshLoader
    {

        public enum LoadMode { Normal, Translated }

        private readonly string _filePath;

        public ObjectMeshLoader(string filePath)
        {
            this._filePath = filePath;
        }

        private enum MeshCommand { V, VT, F, G, O, OBJECT, MESH }

        public List<GeometricObject> ExtractObjectMesh(LoadMode loadMode)
        {
            List<GeometricObject> objectMesh = new List<GeometricObject>();

            FileHandler fileHandler = new FileHandler(_filePath);
            fileHandler.ExtractData();
            StringReader scanner = new StringReader(fileHandler.GetSourceData());

            List<Coordinate> vertexCoords = new List<Coordinate>();
            VertexOrder vertexOrder;
            string meshCommandDelimeter = " ";
            int meshCommandIndex;
            string currLine = scanner.ReadLine();
            while (currLine != null)
            {
                meshCommandIndex = currLine.IndexOf(meshCommandDelimeter);
                if (meshCommandIndex != -1)
                {
                    string meshCommand = currLine.Substring(0, meshCommandIndex).ToUpper();
                    if (meshCommand.Equals(MeshCommand.V.ToString()))
                    {
                        vertexCoords.Add(new Coordinate());
                        currLine = currLine.Substring(meshCommandIndex + 1);
                        if (currLine.Substring(0, 1).Equals(meshCommandDelimeter))
                        {
                            currLine = currLine.Substring(1);
                        }

                        meshCommandIndex = currLine.IndexOf(meshCommandDelimeter);
                        vertexCoords.Last().XCoord = Convert.ToSingle(currLine.Substring(0, meshCommandIndex), CultureInfo.InvariantCulture);
                        currLine = currLine.Substring(meshCommandIndex + 1);

                        meshCommandIndex = currLine.IndexOf(meshCommandDelimeter);
                        vertexCoords.Last().YCoord = Convert.ToSingle(currLine.Substring(0, meshCommandIndex), CultureInfo.InvariantCulture);
                        currLine = currLine.Substring(meshCommandIndex + 1);

                        vertexCoords.Last().ZCoord = Convert.ToSingle(currLine, CultureInfo.InvariantCulture);
                    }
                    else if (meshCommand.Equals(MeshCommand.VT.ToString()))
                    {
                        currLine = currLine.Substring(meshCommandIndex + 1);

                        //meshCommandIndex = currLine.IndexOf(meshCommandDelimeter);
                        ///////////////////////// Handle Texture Meshing ///////////////////////
                        //currLine = currLine.Substring(meshCommandIndex + 1);

                        //meshCommandIndex = currLine.IndexOf(meshCommandDelimeter);
                        ///////////////////////// Handle Texture Meshing ///////////////////////
                        //currLine = currLine.Substring(meshCommandIndex + 1);

                    }
                    else if (meshCommand.Equals(MeshCommand.F.ToString()))
                    {
                        vertexOrder = new VertexOrder();
                        currLine = currLine.Substring(meshCommandIndex + 1);

                        meshCommandIndex = currLine.IndexOf(meshCommandDelimeter);
                        while (meshCommandIndex != -1)
                        {
                            vertexOrder.InsertIndex(Convert.ToInt32(currLine.Substring(0, meshCommandIndex).Split('/').First()) - 1);
                            currLine = currLine.Substring(meshCommandIndex + 1);
                            meshCommandIndex = currLine.IndexOf(meshCommandDelimeter);
                        }
                        if (currLine.Length > 0)
                        {
                            vertexOrder.InsertIndex(Convert.ToInt32(currLine.Split('/').First()) - 1);
                        }
                        objectMesh.Last().InsertPolygon(vertexOrder.ConstructPolygon(vertexCoords));
                    }
                    else if (currLine.Contains(MeshCommand.OBJECT.ToString() + " " + MeshCommand.MESH.ToString(), StringComparison.CurrentCultureIgnoreCase)
                                || meshCommand.Equals(MeshCommand.O.ToString()))
                    {
                        objectMesh.Add(new GeometricObject());
                    }
                }
                currLine = scanner.ReadLine();
            }
            
            if (loadMode == LoadMode.Translated)
            {
                throw new NotImplementedException();
            }

            return objectMesh;
        }

        private class VertexOrder
        {
            private GeometricObject.PolygonMode _mode = GeometricObject.PolygonMode.Invalid;
            private List<int> _indices = new List<int>();

            public void InsertIndex(int insert)
            {
                _indices.Add(insert);
                if (_indices.Count < Polygon.MinEdgeNumber) _mode = GeometricObject.PolygonMode.Invalid;
                if (_indices.Count == Triangle.EdgeNumber) _mode = GeometricObject.PolygonMode.Triangular;
                else if (_indices.Count == Quadrangle.EdgeNumber) _mode = GeometricObject.PolygonMode.Quadratic;
                else _mode = GeometricObject.PolygonMode.Polygonal;
             
            }

            public Polygon ConstructPolygon(List<Coordinate> vertexCoords)
            {
                Polygon polygon;
                if (_mode == GeometricObject.PolygonMode.Triangular)
                {
                    polygon = new Triangle();
                }
                else if (_mode == GeometricObject.PolygonMode.Quadratic)
                {
                    polygon = new Quadrangle(); 
                }
                else
                {
                    throw new InvalidObjectMeshException();
                }

                List<Coordinate> edgeCoords = new List<Coordinate>();
                foreach (int index in _indices)
                {
                    edgeCoords.Add(vertexCoords[index]);
                }
                polygon.InsertEdgeCoords(edgeCoords);
                return polygon;
            }
        }

    }

    public static class StringExtensions
    {
        public static bool Contains(this string source, string target, StringComparison comp)
        {
            if (target == null)
                throw new ArgumentNullException("substring", "substring cannot be null.");
            else if (!Enum.IsDefined(typeof(StringComparison), comp))
                throw new ArgumentException("comp is not a member of StringComparison", "comp");

            return source.IndexOf(target, comp) >= 0;
        }
    }

}
