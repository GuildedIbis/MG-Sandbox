//Sprite.cs
//
//Use: Base Class for rendering 2D textures (with transformations)
//
using MG_Sandbox.Managers;

namespace MG_Sandbox
{
    internal class Sprite
    {
        //
        public static readonly double SCALE = 1.0;
        //
        public Texture2D texture;
        public Texture2D spritesheet;
        public AnimationManager animator;
        public Vector2 position;
        public Color color;
        //
        public Rectangle Rect
        {
            get
            {
                return new Rectangle(
                    (int)position.X,
                    (int)position.Y,
                    texture.Width * (int)SCALE,
                    texture.Height * (int)SCALE
                );
            }
        }
        public Sprite(Texture2D _texture, Vector2 _position, Color _color)
        {
            this.texture = _texture;
            this.position = _position;
            this.color = _color;
        }
        public virtual void Update()
        {
            
        }

        public virtual void Draw()
        {
            Globals.SpriteBatch.Draw(texture, Rect, Color.White);
        }
    }
}
