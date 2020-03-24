using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL_Project.Geometry
{
    class HierarchicalObjectModel : ObjectModel
    {

        private SingularObjectModel _primaryComp;
        private Dictionary<ComponentKey, TransformableObject> _subComps;

        public HierarchicalObjectModel(SingularObjectModel primaryComp)
        {
            this._primaryComp = primaryComp;
            this._subComps = new Dictionary<ComponentKey, TransformableObject>();
        }

        public HierarchicalObjectModel(SingularObjectModel primaryComp, Dictionary<ComponentKey, TransformableObject> subComps)
        {
            this._primaryComp = primaryComp;
            this._subComps = new Dictionary<ComponentKey, TransformableObject>(subComps);
        }

        public void InsertSubComp(ComponentKey id, TransformableObject insert)
        {
            if (_subComps.ContainsKey(id)) return;

            _subComps.Add(id, insert);
        }

        public void InsertSubComps(Dictionary<ComponentKey, TransformableObject> insert)
        {
            foreach (KeyValuePair<ComponentKey, TransformableObject> comp in insert)
            {
                if (_subComps.ContainsKey(comp.Key)) continue;

                _subComps.Add(comp.Key, comp.Value);
            }
        }

        public void FlushSubComps()
        {
            _subComps.Clear();
        }

        public int GetSubCompCount()
        {
            return _subComps.Count;
        }

        public override StructType GetStructType()
        {
            return StructType.Hierarchical;
        }

        public SingularObjectModel GetPrimaryComp()
        {
            return _primaryComp;
        }

        public TransformableObject GetSubComp(ComponentKey compID)
        {
            TransformableObject comp;
            if (_subComps.TryGetValue(compID, out comp))
            {
                return comp;
            }
            throw new InvalidHierarchicalAccessException();
        }

        public Dictionary<ComponentKey, TransformableObject> GetSubComps()
        {
            return _subComps;
        }

        public override Dictionary<ComponentKey, List<GeometricObject>> GetIdentities()
        {
            Dictionary<ComponentKey, List<GeometricObject>> identities = _primaryComp.GetIdentities();

            List<KeyValuePair<ComponentKey, List<GeometricObject>>> temp = identities.ToList();
            foreach (KeyValuePair<ComponentKey, TransformableObject> comp in _subComps)
            {
                Dictionary<ComponentKey, List<GeometricObject>> tempIdentities = comp.Value.Model.GetIdentities();
                tempIdentities.Add(comp.Key, tempIdentities.First().Value);
                tempIdentities.Remove(SingularObjectModel.SingularCompID);
                temp.AddRange(tempIdentities.ToList());
            }
            identities = temp.ToDictionary(pair => pair.Key, pair => pair.Value);
            return identities;
        }

    }
}
