//Entity.CS
//
//Use: Sprite Class objects that should also have collision applied.
//
using System.Diagnostics;

namespace MG_Sandbox.Entities
{
    internal class Entity : Sprite
    {
        //
        public Vector2 velocity;
        public Vector2 velNorm;
        public int moveAngle;
        public int lastAngle;
        public float speed;
        public bool collided = false;
        //
        public Entity(Texture2D _texture, Vector2 _position, Color _color) : base(_texture, _position, _color)
        {
            texture = _texture;
            position = _position;
            color = _color;
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

        public int MoveDirectionAngle(double dirX, double dirY)
        {
            var radians = Math.Atan2(dirX, dirY);
            var angle = radians * (180 / Math.PI);
            angle = angle - 90;
            angle = (angle + 360) % 360;
            return (int)angle;
        }
    }
}
