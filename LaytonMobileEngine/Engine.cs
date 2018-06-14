using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace LaytonMobileEngine
{
    public class Engine : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private LocationManager locManager;
        private CharacterSpriteManager spriteManager;
        private ScriptLoader scriptLoader;
        private UIManager uiManager;
        private ScriptFileParser fileParser;


        public Engine()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            //engine settings setup
            graphics.PreferredBackBufferWidth = 1200;
            graphics.PreferredBackBufferHeight = 720;
        }

        protected override void Initialize()
        {
            //no clue what to put here
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            locManager = new LocationManager(GraphicsDevice);

            spriteManager = new CharacterSpriteManager(GraphicsDevice);

            uiManager = new UIManager(GraphicsDevice);

            scriptLoader = new ScriptLoader(locManager, spriteManager, uiManager);

            fileParser = new ScriptFileParser();

            //load script file
            string homepath = Environment.GetEnvironmentVariable("homepath");
            scriptLoader.loadScript(homepath + "\\Source\\Repos\\LaytonMobileEngine\\TestScript");
            //loading script Jacob's way
            fileParser.loadFile(homepath + "\\Source\\Repos\\LaytonMobileEngine\\ScriptFiles\\TestScriptFile.txt");
        }

        protected override void UnloadContent()
        {
            // TODO: Unload content
            // NOTE: HOW!!
        }

        protected override void Update(GameTime gameTime)
        {
            //-- DEV EXIT --//
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //-- MOUSE INPUT --//
            MouseState state = Mouse.GetState();

            //cursor move
            uiManager.mouse.mouseX = state.X;
            uiManager.mouse.mouseY = state.Y;

            //mouse click left
            //TODO ADD MOUSE CLICK HANDLER

            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            //SCREEN WIPE
            GraphicsDevice.Clear(Color.Purple);

            //START DRAWING
            spriteBatch.Begin();

            //DRAWING LOCATION
            locManager.currentLocation.draw(spriteBatch, spriteManager, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);

            //FINAL DRAWING UI OVERLAY
            uiManager.draw(spriteBatch, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);

            //STOP DRAWING
            spriteBatch.End();

            //DEBUG
            System.Console.WriteLine((1 / gameTime.ElapsedGameTime.TotalSeconds).ToString());

            base.Draw(gameTime);
        }
    }
}
