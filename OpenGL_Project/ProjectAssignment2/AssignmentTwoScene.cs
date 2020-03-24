using System;
using OpenGL_Project.Geometry;
using OpenGL_Project.Graphics;
using OpenTK;

namespace OpenGL_Project.ProjectAssignment2
{
    class AssignmentTwoScene : OpenGLScene
    {
        
        public AssignmentTwoScene() { }

        private SealedTransformableObject transformableSpiderObj;
        public override void Initialize(float cameraAR)
        {
            transformableSpiderObj = new SealedTransformableObject(SpiderModel.Model, SpiderHiearchyPackage.HP);
            RenderableSpider spider = new RenderableSpider(transformableSpiderObj);
            spider.Initialize();
            spider.Translate(new Vector(0, 0, 10));
            spider.Transform();
            SceneElements.Add(spider);

            base.Initialize(cameraAR);
        }

        public void OnUpdate(object sender, EventArgs args)
        {
            Camera.Rotate(new Vector(0, 1, 0), MathHelper.DegreesToRadians(1));
            Camera.Transform();
        }

        private ObjectModel.ComponentKey focusComp = SpiderHiearchyPackage.body;
        private TransformEventArgs.TransformEvent activeTransform = TransformEventArgs.TransformEvent.Translation;
        private bool ub = true;
        public void OnKeyPress(string key)
        {
            if (key.Equals("m"))
            {
                if (activeTransform == TransformEventArgs.TransformEvent.Translation)
                    activeTransform = TransformEventArgs.TransformEvent.Rotation;
                else
                    activeTransform = TransformEventArgs.TransformEvent.Translation;
            }
            else if (key.Equals("b"))
            {
                ub = !ub;
            }

            if (key.Equals("1")) focusComp = SpiderHiearchyPackage.body;
            else if (ub) {
                if (key.Equals("2")) focusComp = SpiderHiearchyPackage.uleg1;
                else if (key.Equals("3")) focusComp = SpiderHiearchyPackage.uleg2;
                else if (key.Equals("4")) focusComp = SpiderHiearchyPackage.uleg3;
                else if (key.Equals("5")) focusComp = SpiderHiearchyPackage.uleg4;
                else if (key.Equals("6")) focusComp = SpiderHiearchyPackage.uleg5;
                else if (key.Equals("7")) focusComp = SpiderHiearchyPackage.uleg6;
                else if (key.Equals("8")) focusComp = SpiderHiearchyPackage.uleg7;
                else if (key.Equals("9")) focusComp = SpiderHiearchyPackage.uleg8;
            }
            else { 
                if (key.Equals("2")) focusComp = SpiderHiearchyPackage.bleg1;
                else if (key.Equals("3")) focusComp = SpiderHiearchyPackage.bleg2;
                else if (key.Equals("4")) focusComp = SpiderHiearchyPackage.bleg3;
                else if (key.Equals("5")) focusComp = SpiderHiearchyPackage.bleg4;
                else if (key.Equals("6")) focusComp = SpiderHiearchyPackage.bleg5;
                else if (key.Equals("7")) focusComp = SpiderHiearchyPackage.bleg6;
                else if (key.Equals("8")) focusComp = SpiderHiearchyPackage.bleg7;
                else if (key.Equals("9")) focusComp = SpiderHiearchyPackage.bleg8;
            }

            TransformableObject transform = transformableSpiderObj.GetComp(focusComp);
            if (key.Equals("q"))
            {
                if (activeTransform == TransformEventArgs.TransformEvent.Rotation)
                    transform.Rotate(new Vector(0, 0, 1), 5.0f);
                else
                    transform.Translate(new Vector(0, 0, 0.1f));
                transform.Transform();
            }
            else if (key.Equals("e"))
            {
                if (focusComp != SpiderHiearchyPackage.body) transform = transform.GetSubComp(focusComp);
                if (activeTransform == TransformEventArgs.TransformEvent.Rotation)
                    transform.Rotate(new Vector(0, 0, 1), -5.0f);
                else
                    transform.Translate(new Vector(0, 0, -0.1f));
                transform.Transform();
            }
            else if (key.Equals("w"))
            {
                if (focusComp != SpiderHiearchyPackage.body) transform = transform.GetSubComp(focusComp);
                if (activeTransform == TransformEventArgs.TransformEvent.Rotation)
                    transform.Rotate(new Vector(0, 1, 0), 5.0f);
                else
                    transform.Translate(new Vector(0, 0.1f, 0));
                transform.Transform();
            }
            else if (key.Equals("s"))
            {
                if (focusComp != SpiderHiearchyPackage.body) transform = transform.GetSubComp(focusComp);
                if (activeTransform == TransformEventArgs.TransformEvent.Rotation)
                    transform.Rotate(new Vector(0, 1, 0), -5.0f);
                else
                    transform.Translate(new Vector(0, -0.1f, 0));
                transform.Transform();
            }
            else if (key.Equals("a"))
            {
                if (focusComp != SpiderHiearchyPackage.body) transform = transform.GetSubComp(focusComp);
                if (activeTransform == TransformEventArgs.TransformEvent.Rotation)
                    transform.Rotate(new Vector(1, 0, 0), 5.0f);
                else
                    transform.Translate(new Vector(0.1f, 0, 0));
                transform.Transform();
            }
            else if (key.Equals("d"))
            {
                if (focusComp != SpiderHiearchyPackage.body) transform = transform.GetSubComp(focusComp);
                if (activeTransform == TransformEventArgs.TransformEvent.Rotation)
                    transform.Rotate(new Vector(1, 0, 0), -5.0f);
                else
                    transform.Translate(new Vector(-0.1f, 0, 0));
                transform.Transform();
            }
        }

    }
}