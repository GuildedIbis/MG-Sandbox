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
        private readonly int _resolutionWidth = 480;
        private readonly int _resolutionHeight = 270;
        private int _virtualWidth = 480;
        private int _virtualHeight = 270;
        private Matrix _screenScaleMatrix;
        public bool vsync { get; private set; }
        private bool _isResizing;
        private Viewport _viewport;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = _resolutionWidth;
            _graphics.PreferredBackBufferHeight = _resolutionHeight;
            _graphics.SynchronizeWithVerticalRetrace = vsync;
            _graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            //_graphics.IsFullScreen = true;
            Window.AllowUserResizing = true;
            Window.ClientSizeChanged += OnClientSlizeChanged;


        }
        private void OnClientSlizeChanged(object sender, EventArgs e)
        {
            if (!_isResizing && Window.ClientBounds.Width > 0 && Window.ClientBounds.Height > 0)
            {
                _isResizing = true;
                UpdateScreenScaleMatrix();
                _isResizing = false;
            }
        }

        protected override void Initialize()
        {
            //Base Window Settings
            Globals.Bounds = new(_resolutionWidth, _resolutionHeight);
            //_graphics.PreferredBackBufferWidth = Globals.Bounds.X;
            //_graphics.PreferredBackBufferHeight = Globals.Bounds.Y;
            //_graphics.ApplyChanges();
            Globals.Content = Content;
            //GameWindow.AllowUserResizing = true;
            UpdateScreenScaleMatrix();

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
            GraphicsDevice.Clear(Color.Black);
            GraphicsDevice.Viewport = _viewport;

            //Main Render
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: _screenScaleMatrix);
            _gameManager.Draw();

            _spriteBatch.End();

            //Base Draw
            base.Draw(gameTime);
        }

        private void UpdateScreenScaleMatrix()
        {
            //When scaled up, there is a visible jitter to diagonal movement
            //Presumably this is because it is drawing at the normalized value, .7 pixels
            //To fix this, try making the positions floats but the renders integers
            //Get Screen Size
            float screenWidth = GraphicsDevice.PresentationParameters.BackBufferWidth;
            float screenHeight = GraphicsDevice.PresentationParameters.BackBufferHeight;

            //Get Virtual Screen Size (maintaining aspect ratio)
            if (screenWidth / _resolutionWidth > screenHeight / _resolutionHeight)
            {
                float aspect = screenHeight / _resolutionHeight; 
                _virtualWidth = (int)(aspect * _resolutionWidth);
                _virtualHeight = (int)screenHeight;
            }
            else
            {
                float aspect = screenWidth / _resolutionWidth;
                _virtualWidth = (int)screenWidth;
                _virtualHeight = (int)(aspect * _resolutionHeight);
            }
            
            _screenScaleMatrix = Matrix.CreateScale(_virtualWidth / (float)_resolutionWidth);

            _viewport = new Viewport
            {
                X = (int)(screenWidth / 2 - _virtualWidth / 2),
                Y = (int)(screenHeight / 2 - _virtualHeight / 2),
                Width = _virtualWidth,
                Height = _virtualHeight,
                MinDepth = 0,
                MaxDepth = 1
            };
        }
    }
}
