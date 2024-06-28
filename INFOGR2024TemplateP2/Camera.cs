using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    public class Camera
    {
        public Vector3 position;

        public Vector3 upDirection;
        public Vector3 rightDirection;
        public Vector3 inDirection;

        public Camera()
        {
            position = (0, -5, 15);

            upDirection = (0, 1, 0);
            rightDirection = (1, 0, 0);
            inDirection = (0, 0, -1);
        }

        /// <summary>
        /// changes the camera's position based on the given direcion
        /// </summary>
        /// <param name="direction"></param>
        public void Translate(Vector3 direction)
        {
            position -= direction.X * rightDirection + direction.Y * upDirection + direction.Z * - inDirection;
        }
        
        /// <summary>
        /// rotates the viewing direction around X axis
        /// </summary>
        /// <param name="angle">the angle of the rotation</param>
        public void RotateX(float angle)
        {
            Matrix3 rotation = Matrix3.CreateRotationX(angle);
            upDirection *= rotation;
            rightDirection *= rotation;
            inDirection *= rotation;
        }

        /// <summary>
        /// rotate viewing direction around Y axis
        /// </summary>
        /// <param name="angle">the angl;e of the rotation</param>
        public void RotateY(float angle)
        {
            Matrix3 rotation = Matrix3.CreateRotationY(angle);
            upDirection *= rotation;
            rightDirection *= rotation;
            inDirection *= rotation;
        }

    }
}
