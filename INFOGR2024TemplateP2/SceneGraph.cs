using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    public class SceneGraph
    {
        public Node sceneNode;
        public Vector2 screenSize;
        public float FOV;


        public SceneGraph(Node sceneNode)
        {
            this.sceneNode = sceneNode;
            this.screenSize = new(640, 360);
            this.FOV = MathHelper.DegreesToRadians(70.0f);
        }

        /// <summary>
        /// renders the scene
        /// </summary>
        /// <param name="camera"></param>
        /// <param name="shader"></param>
        public void Render(Camera camera, Shader shader)
        {
            Matrix4 cameraToScreen = Matrix4.CreatePerspectiveFieldOfView(FOV, screenSize.X / screenSize.Y, 0.1f, 1000);

            Matrix4 worldToCameraTranslation = Matrix4.CreateTranslation(camera.position);
            Matrix4 worldToCameraRotation = new(camera.rightDirection.X, camera.rightDirection.Y, camera.rightDirection.Z, 0,
                                    camera.upDirection.X, camera.upDirection.Y, camera.upDirection.Z, 0,
                                    camera.inDirection.X, camera.inDirection.Y, camera.inDirection.Z, 0,
                                    0,0,0,1);

            Matrix4 worldToScreen = (worldToCameraTranslation * worldToCameraRotation) * cameraToScreen;
            sceneNode.Render(camera, shader, worldToScreen, Matrix4.Identity);
        }

    }

}
