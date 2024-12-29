//Global.cs
//
//Use: Global Usings and Update Delta Time
//
global using Microsoft.Xna.Framework;
global using Microsoft.Xna.Framework.Graphics;
global using Microsoft.Xna.Framework.Input;
global using Microsoft.Xna.Framework.Content;
global using Vector2 = Microsoft.Xna.Framework.Vector2;
global using Color = Microsoft.Xna.Framework.Color;
global using Rectangle = Microsoft.Xna.Framework.Rectangle;



namespace MG_Sandbox
{
    public static class Globals
    {
        public static float TotalSeconds { get; set; }
        public static ContentManager Content { get; set; }
        public static SpriteBatch SpriteBatch { get; set; }
        public static Point Bounds { get; set; }

        public static void Update(GameTime gt)
        {
            TotalSeconds = (float)gt.ElapsedGameTime.TotalSeconds;
        }
    }
}