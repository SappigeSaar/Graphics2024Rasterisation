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

        //updates camera position
        public void Translate(Vector3 direction)
        {
            position -= direction.X * rightDirection + direction.Y * upDirection + direction.Z * - inDirection;
        }
        
        /// <summary>
        /// rotate viewing direction around X axis
        /// </summary>
        /// <param name="x"></param>
        public void RotateX(float x)
        {
            Matrix3 rotation = Matrix3.CreateRotationX(x);
            upDirection *= rotation;
            rightDirection *= rotation;
            inDirection *= rotation;
        }

        /// <summary>
        /// rotate viewing direction around Y axis
        /// </summary>
        /// <param name="x"></param>
        public void RotateY(float x)
        {
            Matrix3 rotation = Matrix3.CreateRotationY(x);
            upDirection *= rotation;
            rightDirection *= rotation;
            inDirection *= rotation;
        }

        /// <summary>
        /// rotate viewing direction around Z axis
        /// </summary>
        /// <param name="x"></param>
        public void RotateZ(float x)
        {
            Matrix3 rotation = Matrix3.CreateRotationZ(x);
            upDirection *= rotation;
            rightDirection *= rotation;
            inDirection *= rotation;
        }
    }
}
