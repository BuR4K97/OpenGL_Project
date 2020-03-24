using OpenGL_Project.Geometry;
using OpenTK;
using System.Collections.Generic;
using System.Linq;

namespace OpenGL_Project.Graphics
{
    class RenderableObject : IRenderable
    {
        public SealedTransformableObject SealedObject;
        public ColorPackage ColorPack;
        public NormalPackage NormalPack;
        public MaterialPackage MaterialPack;

        private Dictionary<ObjectModel.ComponentKey, RenderableIdentity> _identities;
        private Dictionary<Transformable, ObjectModel.ComponentKey> _transformableKeys;
        private Dictionary<Material, ObjectModel.ComponentKey> _materialKeys;

        public RenderableObject(SealedTransformableObject sealedTransformableObject, ColorPackage colorPackage = null
            , NormalPackage normalPackage = null, MaterialPackage materialPackage = null)
        {
            this.SealedObject = sealedTransformableObject;
            this.ColorPack = colorPackage;
            this.NormalPack = normalPackage;
            this.MaterialPack = materialPackage;
            this._identities = new Dictionary<ObjectModel.ComponentKey, RenderableIdentity>();
            this._transformableKeys = new Dictionary<Transformable, ObjectModel.ComponentKey>();
            this._materialKeys = new Dictionary<Material, ObjectModel.ComponentKey>();
        }

        public void Render()
        {
            foreach (RenderableIdentity renderable in _identities.Values)
            {
                renderable.Render();
            }
        }

        public void Process()
        {
            _identities.Clear();
            _transformableKeys.Clear();
            _materialKeys.Clear();

            Dictionary<ObjectModel.ComponentKey, TransformableObject> comps = new Dictionary<ObjectModel.ComponentKey, TransformableObject>()
            {
                { SingularObjectModel.SingularCompID, SealedObject.Object }
            };

            Dictionary<ObjectModel.ComponentKey, TransformableObject> subComps;
            foreach (KeyValuePair<ObjectModel.ComponentKey, TransformableObject> comp in comps)
            {
                _identities.Add(comp.Key, new RenderableIdentity(comp.Value.GetPrimaryComp().GetIdentities().First().Value, ColorPack, NormalPack));
                _identities.Last().Value.Process();
                _identities.Last().Value.SetJointTransform(SingularObjectModel.SingularCompID, Matrix4.Identity);
                comp.Value.TransformHandler += TransformEventHandler;
                _transformableKeys.Add(comp.Value, comp.Key);
                if (MaterialPack == null)
                {
                    _identities.Last().Value.SetMaterialTransform(MaterialPackage.DefaultMaterial.GetAmbientCoeff()
                        , MaterialPackage.DefaultMaterial.GetDiffuseCoeff(), MaterialPackage.DefaultMaterial.GetSpecularCoeff()
                        , MaterialPackage.DefaultMaterial.GetShininessCoeff());
                }
                else
                {
                    MaterialPack.MaterialMap[comp.Key].TransformHandler += MaterialTransformEventHandler;
                    _materialKeys.Add(MaterialPack.MaterialMap[comp.Key], comp.Key);
                    MaterialPack.MaterialMap[comp.Key].Transform();
                }

                if (comp.Value.GetStructType() == ObjectModel.StructType.Hierarchical)
                {
                    subComps = comp.Value.GetSubComps();
                    foreach (KeyValuePair<ObjectModel.ComponentKey, TransformableObject> subComp in subComps)
                    {
                        comps.Add(subComp.Key, subComp.Value);
                        _identities.Last().Value.SetJointTransform(subComp.Key, subComp.Value.GetTransform());
                    }
                }
            }
            SealedObject.Object.Transform();
        }

        private void TransformEventHandler(Transformable sender, TransformEventArgs args)
        {
            ObjectModel.ComponentKey transformableKey;
            _transformableKeys.TryGetValue(sender, out transformableKey);
            if (transformableKey == null)
            {
                throw new InvalidTransformEventHandlerException();
            }

            List<ObjectModel.ComponentKey> initialPath = SealedObject.HierarchyPack.ComponentMap[_transformableKeys[sender]];
            TransformableObject initialComp = SealedObject.Object;
            Matrix4 globalTransform = new Matrix4() { M11 = 1, M22 = 1, M33 = 1, M44 = 1 };
            for (int i = 0; i < initialPath.Count - 1; i++)
            {
                globalTransform = initialComp.GetTransform() * globalTransform;
                initialComp = initialComp.GetSubComp(initialPath[i]);
            }
            if (initialPath.Count > 0)
            {
                globalTransform = initialComp.GetTransform() * globalTransform;
                initialComp = initialComp.GetSubComp(initialPath.Last());
                _identities[initialPath[initialPath.Count - 1]].SetJointTransform(initialPath.Last(), initialComp.GetTransform());
            }

            Dictionary<TransformableObject, Matrix4> components = new Dictionary<TransformableObject, Matrix4>();
            components.Add(initialComp, initialComp.GetTransform() * globalTransform);

            KeyValuePair<TransformableObject, Matrix4> currComp;
            Dictionary<ObjectModel.ComponentKey, TransformableObject> subComps;
            while (components.Count > 0)
            {
                currComp = components.First();
                components.Remove(currComp.Key);
                if (currComp.Key.GetStructType() == ObjectModel.StructType.Hierarchical)
                {
                    subComps = currComp.Key.GetSubComps();
                    foreach (KeyValuePair<ObjectModel.ComponentKey, TransformableObject> comp in subComps)
                    {
                        components.Add(comp.Value, comp.Value.GetTransform() * currComp.Value);
                    }
                }
                _identities[_transformableKeys[currComp.Key]].SetTransform(currComp.Value);
            }
        }

        private void MaterialTransformEventHandler(Material sender, MaterialEventArgs args)
        {
            ObjectModel.ComponentKey materialKey;
            _materialKeys.TryGetValue(sender, out materialKey);
            if (materialKey == null)
            {
                throw new InvalidMaterialEventHandlerException();
            }
            _identities[materialKey].SetMaterialTransform(sender.GetAmbientCoeff(), sender.GetDiffuseCoeff(), sender.GetSpecularCoeff()
                , sender.GetShininessCoeff());
        }

    }
}
