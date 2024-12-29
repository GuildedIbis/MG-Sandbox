//Game1.cs
//
//Main Game
//
using MG_Sandbox.Managers;

namespace MG_Sandbox
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private GameManager _gameManager;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            //Base Window Settings
            Globals.Bounds = new(960, 540);
            _graphics.PreferredBackBufferWidth = Globals.Bounds.X;
            _graphics.PreferredBackBufferHeight = Globals.Bounds.Y;
            _graphics.ApplyChanges();
            Globals.Content = Content;

            //Create Main Game Loop
            _gameManager = new();

            //Base Initialization
            base.Initialize(); 
        }

        protected override void LoadContent()
        {
            //Set Global Access to Main Sprite Batch
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Globals.SpriteBatch = _spriteBatch;
        }

        protected override void Update(GameTime gameTime)
        {
            //Esc: Close Game Loop and Window
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }
                
            //Main Loop
            Globals.Update(gameTime); //Update Game time elapsed
            _gameManager.Update(); //Main Game Logic Update

            //Base Update
            base.Update(gameTime); 
        }

        protected override void Draw(GameTime gameTime)
        {
            //Window Base Color
            GraphicsDevice.Clear(Color.DarkGreen);

            //Main Render
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            _gameManager.Draw();
            _spriteBatch.End();

            //Base Draw
            base.Draw(gameTime);
        }
    }
}
