using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace OpenGL_Project.Geometry
{
    class TransformableObject : Transformable
    {

        public ObjectModel Model;

        public TransformableObject(ObjectModel model)
        {
            this.Model = model;
        }

        public ObjectModel.StructType GetStructType()
        {
            return Model.GetStructType();
        }

        public SingularObjectModel GetPrimaryComp()
        {
            if (Model is SingularObjectModel)
            {
                SingularObjectModel singularModel = Model as SingularObjectModel;
                return singularModel;
            }
            else
            {
                HierarchicalObjectModel hierarchicalModel = Model as HierarchicalObjectModel;
                return hierarchicalModel.GetPrimaryComp();
            }
        }

        public TransformableObject GetSubComp(ObjectModel.ComponentKey key)
        {
            if (Model is SingularObjectModel)
            {
                throw new InvalidHierarchicalAccessException();
            }
            else
            {
                return (Model as HierarchicalObjectModel).GetSubComp(key);
            }
        }

        public Dictionary<ObjectModel.ComponentKey, TransformableObject> GetSubComps()
        {
            if (Model is SingularObjectModel)
            {
                throw new InvalidHierarchicalAccessException();
            }
            else
            {
                return (Model as HierarchicalObjectModel).GetSubComps();
            }
        }

    }

    
}
