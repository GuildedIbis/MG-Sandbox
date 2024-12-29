//InputManager.cs
//
//Use: Receive and Apply Input from Player {and probably other} Class objects 
//
namespace MG_Sandbox.Managers
{
    internal class InputManager
    {
        private static MouseState _lastMouseState;
        private static Vector2 _direction;
        public static Vector2 Direction = _direction;
        private static Vector2 _directionArrows;
        public static Vector2 DirectionArrows => _directionArrows;
        public static Vector2 MousePosition => Mouse.GetState().Position.ToVector2();
        public static bool MouseClicked { get; private set; }
        public InputManager()
        {

        }
        public static void Update()
        {

            var keyboardState = Keyboard.GetState();

            _direction = Vector2.Zero;
            if (keyboardState.IsKeyDown(Keys.W)) _direction.Y = -1;
            if (keyboardState.IsKeyDown(Keys.S)) _direction.Y = 1;
            if (keyboardState.IsKeyDown(Keys.A)) _direction.X = -1;
            if (keyboardState.IsKeyDown(Keys.D)) _direction.X = 1;
            Direction = _direction;

            _directionArrows = Vector2.Zero;
            if (keyboardState.IsKeyDown(Keys.Up)) _directionArrows.Y++;
            if (keyboardState.IsKeyDown(Keys.Down)) _directionArrows.Y--;
            if (keyboardState.IsKeyDown(Keys.Left)) _directionArrows.X--;
            if (keyboardState.IsKeyDown(Keys.Right)) _directionArrows.X++;

            MouseClicked = (Mouse.GetState().LeftButton == ButtonState.Pressed) && (_lastMouseState.LeftButton == ButtonState.Released);
            _lastMouseState = Mouse.GetState();
        }
        

    }
}
