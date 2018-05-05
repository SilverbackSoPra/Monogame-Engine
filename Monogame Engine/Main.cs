using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Monogame_Engine.Engine;
using Monogame_Engine.Engine.Mesh;
using Monogame_Engine.Engine.Renderer;

namespace Monogame_Engine
{
    /// <summary>
    ///     This is the main type for your game.
    /// </summary>
    public sealed class Main : Game
    {
        private GraphicsDeviceManager mGraphics;
        private Camera mCamera;


        private Mesh mCMesh;
        private Actor mCActor;
        private Model mCharacter;
        private Scene mScene;

        private MasterRenderer mRenderer;
        private RenderTarget mTarget;
        private bool mF1KeyDown;

        public Main()
        {

            // Enable user shader with HiDef
            mGraphics = new GraphicsDeviceManager(this) {GraphicsProfile = GraphicsProfile.HiDef, PreferredBackBufferWidth = 1280, PreferredBackBufferHeight = 720};

            Content.RootDirectory = "Content";

            mCamera =  new Camera(new Vector3(15.0f * 4.0f, -25.0f, -65.0f), farPlane: 500.0f);

            mScene = new Scene();

            IsMouseVisible = true;
            mF1KeyDown = false;

        }

        /// <summary>
        ///     Allows the game to perform any initialization it needs to before starting to run.
        ///     This is where it can query for any required services and load any non-graphic
        ///     related content.  Calling base.Initialize will enumerate through any components
        ///     and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        ///     LoadContent will be called once per game and is the place to load
        ///     all of your content.
        /// </summary>
        protected override void LoadContent()
        {

            // TODO: use this.Content to load your game content here
            mRenderer = new MasterRenderer(GraphicsDevice, Content);
            mTarget = new RenderTarget(GraphicsDevice, 1280, 720, 4096);

            mCharacter = Content.Load<Model>("Character Running");

            mCMesh = new Mesh(mCharacter);
            mCActor = new Actor(mCMesh);

            mScene.Add(mCActor);

            for (uint i = 0; i < 900; i++)
            {

                var actor = new Actor(mCMesh);
                mScene.Add(actor);
               
            }

        }

        /// <summary>
        ///     UnloadContent will be called once per game and is the place to unload
        ///     game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        ///     Allows the game to run logic such as updating the world,
        ///     checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.F1) && !mF1KeyDown)
            {
                if (mGraphics.IsFullScreen)
                {
                    mGraphics.IsFullScreen = false;
                    mGraphics.PreferredBackBufferWidth = 1280;
                    mGraphics.PreferredBackBufferHeight = 720;
                }
                else
                {
                    mGraphics.IsFullScreen = true;
                    mGraphics.PreferredBackBufferWidth = 1920;
                    mGraphics.PreferredBackBufferHeight = 1080;
                }

                mGraphics.ApplyChanges();
                mF1KeyDown = true;

            }
            else if (!Keyboard.GetState().IsKeyDown(Keys.F1))
            {
                mF1KeyDown = false;
            }


            mCamera.mRotation.Y = 0.25f;

            var matX = Matrix.CreateRotationX(MathHelper.Pi / 2.0f);
            var matY = Matrix.CreateRotationY(
                (float) gameTime.TotalGameTime.TotalMilliseconds / 1000.0f);
            
            for (uint i = 0; i < 30; i++)
            {
                for (uint j = 0; j < 30; j++)
                {

                    var actor = mScene.mActorBatches[0].mActors[900 - (int)(i * 30 + j)];
                    actor.mModelMatrix = matX * matY * Matrix.CreateTranslation(i * 4.0f, 0.0f, j * 4.0f);

                }
            }
            
            // TODO: Add your update logic here
            mCamera.UpdateView();
            mCamera.UpdatePerspective();

            base.Update(gameTime);
        }

        /// <summary>
        ///     This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            mCActor.mModelMatrix = Matrix.CreateRotationX(MathHelper.Pi / 2.0f) * Matrix.CreateRotationY((float)gameTime.TotalGameTime.TotalMilliseconds / 1000.0f) * Matrix.CreateTranslation(new Vector3(0.0f));

            mRenderer.Render(mTarget, mCamera, mScene);

            base.Draw(gameTime);
        }
    }
}