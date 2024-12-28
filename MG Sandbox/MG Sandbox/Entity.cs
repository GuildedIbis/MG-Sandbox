using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static System.Formats.Asn1.AsnWriter;
using Vector2 = Microsoft.Xna.Framework.Vector2;
using Color = Microsoft.Xna.Framework.Color;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace MG_Sandbox
{
    internal class Entity : Sprite
    {
        //
        public Vector2 velocity;
        public double speed;
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
 
        //
     
        //
        //public override void Update(GameTime gameTime, List<Sprite> collisionGroup)
        //{
        //    base.Update(gameTime);
        //}
    }
}
