using System.Diagnostics;
using OpenTK.Mathematics;

namespace Template
{
    class MyApplication
    {
        // member variables
        public Surface screen;                  // background surface for printing etc.
        Mesh? teapot, floor;                    // meshes to draw using OpenGL
        float a = 0;                            // teapot rotation angle
        readonly Stopwatch timer = new();       // timer for measuring frame duration
        Shader? shader;                         // shader to use for rendering
        Shader? postproc;                       // shader to use for post processing
        Texture? wood1, wood2;                          // texture to use for rendering
        RenderTarget? target;                   // intermediate render target
        ScreenQuad? quad;                       // screen filling quad for post processing
        readonly bool useRenderTarget = true;   // required for post processing

        public SceneGraph? sceneGraph;
        public Camera camera = new Camera();

        // constructor
        public MyApplication(Surface screen)
        {
            this.screen = screen;
        }
        // initialize
        public void Init()
        {
            // load nodes
            Node scene = new Node(new List<Node>());

            sceneGraph = new SceneGraph(scene);

            // load a texture
            wood1 = new Texture("../../../assets/wood.jpg");
            wood2 = new Texture("../../../assets/wall.jpg");

            Matrix4 offset = Matrix4.CreateTranslation(0, 0, 40);

            // load teapot
            teapot = new Mesh("../../../assets/teapot.obj", Matrix4.CreateScale(3.0f) * offset, wood1);
            floor = new Mesh("../../../assets/floor.obj", Matrix4.CreateScale(10.0f) * offset, wood2);
            
            scene.AddNode(teapot);
            scene.AddNode(floor);

            // initialize stopwatch
            timer.Reset();
            timer.Start();
            // create shaders
            shader = new Shader("../../../shaders/vs.glsl", "../../../shaders/fs.glsl");
            postproc = new Shader("../../../shaders/vs_post.glsl", "../../../shaders/fs_post.glsl");
           
            // create the render target
            if (useRenderTarget) target = new RenderTarget(screen.width, screen.height);
            quad = new ScreenQuad();
        }

        // tick for background surface
        public void Tick()
        {
            screen.Clear(0);
           // screen.Print("hello world", 2, 2, 0xffff00);
        }

        // tick for OpenGL rendering code
        public void RenderGL()
        {
            // measure frame duration
            float frameDuration = timer.ElapsedMilliseconds;
            timer.Reset();
            timer.Start();
            //THIS IS EVERY FRAME

            // update rotation
            RotateTeapot(frameDuration);

            if (useRenderTarget && target != null && quad != null)
            {
                // enable render target
                target.Bind();

                // render scene to render target
                if (shader != null && wood1 != null && wood2 != null)
                {
                    sceneGraph.Render(camera, shader);
                }

                // render quad
                target.Unbind();
                if (postproc != null)
                    quad.Render(postproc, target.GetTextureID());
            }
            else
            {
                // render scene directly to the screen
                if (shader != null && wood1 != null && wood2 != null)
                {
                    sceneGraph.Render(camera, shader);
                }
            }
        }

        /// <summary>
        /// rotate the teapot
        /// </summary>
        /// <param name="frameDuration"></param>
        private void RotateTeapot(float frameDuration)
        {
            a += 0.001f * frameDuration;
            if (a > 0.09)
                a -= 0.001f * frameDuration;

            Matrix4 relativePosition = sceneGraph.sceneNode.leaves[0].objectToParent;
            Matrix4 potRotation =  Matrix4.CreateFromAxisAngle(new Vector3(0, 1, 0), a) * relativePosition;
            sceneGraph.sceneNode.leaves[0].objectToParent = potRotation;
        }
    }
}