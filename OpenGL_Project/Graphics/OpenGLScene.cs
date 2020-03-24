using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenGL_Project.Geometry;
using OpenGL_Project.Configurations;
using OpenTK.Graphics.OpenGL4;
using OpenTK;

namespace OpenGL_Project.Graphics
{
    public abstract class OpenGLScene
    {

        protected List<IRenderable> SceneElements;
        protected Camera Camera;
        protected Light Light;
        
        public OpenGLScene()
        {
            this.SceneElements = new List<IRenderable>();
            this.Camera = new Camera();
            this.Light = new Light(Light.DefaultDirection, Light.DefaultColor);
            this.Camera.TransformHandler += CameraTransformEventHandler;
            this.Camera.AttributeEventHandler += CameraAttributeEventHandler;
            this.Light.TransformHandler += LightTransformEventHandler;
        }
        
        public virtual void Initialize(float cameraAR)
        {
            Camera.SetAspectRatio(cameraAR);
            Camera.Transform();
            Camera.ConfigureAttribute();
            Light.Transform();
        }

        public void Render()
        {
            foreach (IRenderable renderable in SceneElements)
            {
                renderable.Render();
            }
        }

        private void CameraTransformEventHandler(Transformable sender, TransformEventArgs args)
        {
            if (sender is Camera)
            {
                Camera camera = sender as Camera;
                if (camera == Camera)
                {
                    Matrix4 view = camera.GetView();
                    GLConfig glConfig = AppConfig.GetService<GLConfig>();
                    GL.UniformMatrix4(glConfig.ViewUniformLoc, false, ref view);
                }
                else
                {
                    throw new InvalidTransformEventHandlerException();
                }
            }
            else
            {
                throw new InvalidTransformEventHandlerException();
            }
        }

        private void CameraAttributeEventHandler(Camera sender, CameraAttributeEventArgs args)
        {
            if (Camera == sender)
            {
                Matrix4 projection = sender.GetProjection();
                GLConfig glConfig = AppConfig.GetService<GLConfig>();
                GL.UniformMatrix4(glConfig.ProjectionUniformLoc, false, ref projection);
            }
            else
            {
                throw new InvalidCameraAttributeEventHandlerException();
            }
        }

        private void LightTransformEventHandler(Light sender, LightEventArgs args)
        {
            if (Light == sender)
            {
                GLConfig glConfig = AppConfig.GetService<GLConfig>();
                Vector4 color = new Vector4(Light.Color.R, Light.Color.G, Light.Color.B, Light.Color.A);
                Vector3 direction = new Vector3(Light.Direction.XComp, Light.Direction.YComp, Light.Direction.ZComp);
                GL.Uniform4(glConfig.LightColorUniformLoc, ref color);
                GL.Uniform3(glConfig.LightDirectionUniformLoc, ref direction);
            }
            else
            {
                throw new InvalidLightEventHandlerException();
            }
        }

    }
}
