using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LaytonMobileEngine
{
    public class Engine : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private LocationManager locManager;
        private CharacterSpriteManager spriteManager;
        private ScriptLoader scriptLoader;


        public Engine()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 1200;
            graphics.PreferredBackBufferHeight = 720;
        }

        protected override void Initialize()
        {
            // TODO: Add script loader

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            locManager = new LocationManager(GraphicsDevice);

            spriteManager = new CharacterSpriteManager(GraphicsDevice);

            scriptLoader = new ScriptLoader(locManager, spriteManager);

            //load script file
            scriptLoader.loadScript("");
        }

        protected override void UnloadContent()
        {
            // TODO: Unload content
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: add update logic

            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            locManager.currentLocation.draw(spriteBatch, spriteManager, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            System.Console.WriteLine((1 / gameTime.ElapsedGameTime.TotalSeconds).ToString());
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
