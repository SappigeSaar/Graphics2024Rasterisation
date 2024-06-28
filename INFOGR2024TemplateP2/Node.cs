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

        public Node (Mesh mesh)
        {
            this.mesh = mesh;
            this.objectToParent = mesh.modelMatrix;
            this.leaves = new List<Node>();
        }

        public Node(List<Node> leaves)
        {
            this.leaves = leaves;
            objectToParent = Matrix4.Identity;
        }
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
