//Entity.CS
//
//Use: Sprite Class objects that should also have collision applied.
//
namespace MG_Sandbox
{
    internal class Entity : Sprite
    {
        //
        public Vector2 velocity;
        public float speed;
        public bool collided = false;
        //
        //List<Entity> entities;
        public Entity(Texture2D _texture, Vector2 _position, Color _color) : base(_texture, _position, _color) 
        {
            this.texture = _texture;
            this.position = _position;
            this.color = _color;
        }
        //
        public Rectangle Collision
        {
            get
            {
                return new Rectangle(
                    (int)position.X + (int)velocity.X,
                    (int)position.Y + (int)velocity.Y,
                    texture.Width * (int)SCALE,
                    texture.Height * (int)SCALE
                );
            }
        }
    }
}
