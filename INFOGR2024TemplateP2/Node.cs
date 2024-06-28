using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    public class Node
    {
        public Matrix4 objectToParent;
        private Mesh? mesh;
        public List<Node> leaves;

        /// <summary>
        /// create a node with a mesh
        /// </summary>
        /// <param name="mesh"></param>
        public Node (Mesh mesh)
        {
            this.mesh = mesh;
            this.objectToParent = mesh.modelMatrix;
            this.leaves = new List<Node>();
        }

        /// <summary>
        /// create a node with leaves
        /// </summary>
        /// <param name="leaves"></param>
        public Node(List<Node> leaves)
        {
            this.leaves = leaves;
            objectToParent = Matrix4.Identity;
        }

        /// <summary>
        /// render this node and all its children
        /// </summary>
        /// <param name="camera"></param>
        /// <param name="shader"></param>
        /// <param name="worldToScreen"></param>
        /// <param name="parentTransformation"></param>
        public void Render(Camera camera, Shader shader, Matrix4 worldToScreen, Matrix4 parentTransformation)
        {
            Matrix4 objectToWorld = objectToParent * parentTransformation;
            Matrix4 objectToScreen = objectToWorld * worldToScreen;

            if (mesh != null) mesh.Render(camera, shader, objectToScreen, objectToWorld);

            //render all the leaves
            foreach (Node leaf in leaves) leaf.Render(camera, shader, worldToScreen, objectToWorld);

        }

        public void AddNode(Node node)
        {
            leaves.Add(node);
        }

        public void AddNode(Mesh mesh)
        {
            leaves.Add(new Node(mesh));
        }
    }
}
