using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenGL_Project.Geometry;
using OpenGL_Project.Graphics;
using OpenTK;

namespace OpenGL_Project.ProjectAssignment3
{
    class RenderableHyperboloid : RenderableObject
    {
        private SuperquadricHyperboloid _hyperboloid;
        private MaterialPackage _materialPack;

        private static SealedTransformableObject GetSealedObj()
        {
            SingularObjectModel model = new SingularObjectModel();
            model.InsertGeometricObj(new SuperquadricHyperboloid());
            return new SealedTransformableObject(model, HierarchyPackage.SingularHierarchyPack);
        }

        private static MaterialPackage GetMaterialPackage()
        {
            MaterialPackage pack = new MaterialPackage();
            pack.Insert(SingularObjectModel.SingularCompID, new Material(MaterialPackage.DefaultMaterial));
            return pack;
        }

        public RenderableHyperboloid() : base(GetSealedObj(), null, null, GetMaterialPackage())
        {
            this._hyperboloid = (SuperquadricHyperboloid) base.SealedObject.Object.Model.GetIdentities().First().Value.First();
        }

        public void SetPhiResolParam(float paramVal)
        {
            _hyperboloid.PhiResolParam = paramVal;
        }

        public void SetThetaResolParam(float paramVal)
        {
            _hyperboloid.ThetaResolParam = paramVal;
        }

        public void SetXCompParam(float paramVal)
        {
            _hyperboloid.XCompParam = paramVal;
        }

        public void SetYCompParam(float paramVal)
        {
            _hyperboloid.YCompParam = paramVal;
        }

        public void SetZCompParam(float paramVal)
        {
            _hyperboloid.ZCompParam = paramVal;
        }

        public void ReconstructModel()
        {
            _hyperboloid.GenerateCoords();
            base.NormalPack = _hyperboloid.Normals;
            base.Process();
        }

        public void Scale(float scale)
        {
            SealedObject.GetComp(SingularObjectModel.SingularCompID).Scale(new Vector(scale, scale, scale));
        }

        public void Translate(Vector translate)
        {
            SealedObject.GetComp(SingularObjectModel.SingularCompID).Translate(translate);
        }

        public void Rotate(Vector axis, float angle)
        {
            SealedObject.GetComp(SingularObjectModel.SingularCompID).Rotate(axis, angle);
        }

        public void Transform()
        {
            SealedObject.GetComp(SingularObjectModel.SingularCompID).Transform();
        }

        public void Initialize()
        {
            const float transZ = 30.0f;
            const float scale = 15.0f;

            SealedObject.GetComp(SingularObjectModel.SingularCompID).Translate(new Vector(0, 0, transZ));
            SealedObject.GetComp(SingularObjectModel.SingularCompID).Scale(new Vector(scale, scale, scale));
            SealedObject.GetComp(SingularObjectModel.SingularCompID).Transform();
        }

        public void SetAmbientCoeff(Vector4 coeff)
        {
            MaterialPack.MaterialMap[SingularObjectModel.SingularCompID].SetAmbientCoeff(coeff);
        }

        public void SetDiffuseCoeff(Vector4 coeff)
        {
            MaterialPack.MaterialMap[SingularObjectModel.SingularCompID].SetDiffuseCoeff(coeff);
        }

        public void SetSpecularCoeff(Vector4 coeff)
        {
            MaterialPack.MaterialMap[SingularObjectModel.SingularCompID].SetSpecularCoeff(coeff);
        }

        public void SetShininessCoeff(float coeff)
        {
            MaterialPack.MaterialMap[SingularObjectModel.SingularCompID].SetShininessCoeff(coeff);
        }

        public void TransformMaterial()
        {
            MaterialPack.MaterialMap[SingularObjectModel.SingularCompID].Transform();
        }
    }
}
