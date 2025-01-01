//InputManager.cs
//
//Use: Receive and Apply Input from Player {and probably other} Class objects 
//
using System.Diagnostics;

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
        public static bool MoveKeyPressed { get; private set; }

        public static KeyboardState keyboardState;
        public static KeyboardState lastKeyState;
        public static bool anyKey;
        public InputManager()
        {

        }
        public static void Update()
        {
            lastKeyState = keyboardState;
            keyboardState = Keyboard.GetState();
            _direction = Vector2.Zero;
            if (keyboardState.IsKeyDown(Keys.W)) _direction.Y = -1;
            if (keyboardState.IsKeyDown(Keys.S)) _direction.Y = 1;
            if (keyboardState.IsKeyDown(Keys.A)) _direction.X = -1;
            if (keyboardState.IsKeyDown(Keys.D)) _direction.X = 1;
            Direction = _direction;

            anyKey = false;
            IsKeyPressed(Keys.W);
            IsKeyPressed(Keys.S);
            IsKeyPressed(Keys.A);
            IsKeyPressed(Keys.D);


            _directionArrows = Vector2.Zero;
            if (keyboardState.IsKeyDown(Keys.Up)) _directionArrows.Y++;
            if (keyboardState.IsKeyDown(Keys.Down)) _directionArrows.Y--;
            if (keyboardState.IsKeyDown(Keys.Left)) _directionArrows.X--;
            if (keyboardState.IsKeyDown(Keys.Right)) _directionArrows.X++;

            MouseClicked = (Mouse.GetState().LeftButton == ButtonState.Pressed) && (_lastMouseState.LeftButton == ButtonState.Released);
            _lastMouseState = Mouse.GetState();
        }
        
        public static bool IsKeyPressed(Keys key)
        {
            if (keyboardState.IsKeyDown(key) && !lastKeyState.IsKeyDown(key))
            {
                Debug.WriteLine("Key Pressed");
                anyKey = true;
                return true; 
            }
            else 
            { return false; }
        }

        public static bool IsKeyHeld(Keys key)
        {
            return keyboardState.IsKeyDown(key);
        }

    }
}
