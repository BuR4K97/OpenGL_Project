using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL_Project.Geometry
{
    public abstract class ObjectModel
    {
        public enum StructType { Singular, Hierarchical }

        public abstract StructType GetStructType();
        public abstract Dictionary<ComponentKey, List<GeometricObject>> GetIdentities();

        public class ComponentKey : IEquatable<ComponentKey>
        {
            public string ID;

            public bool Equals(ComponentKey other)
            {
                if (other == null) return false;

                return ID.Equals(other.ID, StringComparison.CurrentCultureIgnoreCase);
            }
        }
    }
}
