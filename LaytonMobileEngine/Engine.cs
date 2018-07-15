using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Configuration;

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
        private DialogueManager dialogManager;

        private SpriteFont font;

        private bool hasClicked = false;

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

            //font, has to be moved and modified later;
            font = Content.Load<SpriteFont>("Arial");

            dialogManager = new DialogueManager(GraphicsDevice);

            locManager = new LocationManager(GraphicsDevice, dialogManager);

            spriteManager = new CharacterSpriteManager(GraphicsDevice);

            uiManager = new UIManager(GraphicsDevice);

            fileParser = new ScriptFileParser();

            scriptLoader = new ScriptLoader(locManager, spriteManager, uiManager, dialogManager, fileParser);

            //load script file
            string homepath = Environment.GetEnvironmentVariable("homepath");

            scriptLoader.loadScript(ConfigurationManager.AppSettings["scriptFilePath"]);
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
            bool triggered = false;
            if (state.LeftButton == ButtonState.Pressed)
            {
                if (!hasClicked)
                {
                    //fires once per click
                    triggered = dialogManager.click(state.X, state.Y);
                    if (!triggered) triggered = uiManager.click(state.X, state.Y);
                    if (!triggered) triggered = locManager.currentLocation.click(state.X, state.Y); //Other click stuff, only triggers if nothing else has been clicked.
                    hasClicked = true;
                }
            } else
            {
                hasClicked = false;
            }


            //-- UI UPDATE --//
            uiManager.update();

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

            //DRAWING UI OVERLAY
            uiManager.draw(spriteBatch, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);

            //DRAWING DIALOG
            dialogManager.draw(spriteBatch, font);

            //STOP DRAWING
            spriteBatch.End();

            //DEBUG
            System.Console.WriteLine((1 / gameTime.ElapsedGameTime.TotalSeconds).ToString());

            base.Draw(gameTime);
        }
    }
}
