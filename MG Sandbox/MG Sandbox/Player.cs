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
using System.Reflection.Metadata;

namespace MG_Sandbox
{
    internal class Player : Entity
    {
        public Vector2 velNorm;
        AnimationManager animator;
        Texture2D spritesheet;
        public Player(Texture2D _texture, Vector2 _position, Color _color) : base(_texture, _position, _color) 
        {
            //All Values Inherited
        }
        public void LoadContent()
        {
            animator = new(16, 16, new Vector2(64, 64));
        }
        //
        public void Update(GameTime gameTime, List<Entity> collisionGroup)
        {

            //Set Velocity
            velocity.X = 0;
            velocity.Y = 0;
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                velocity.X = 1;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                velocity.X = -1;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                velocity.Y = 1;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                velocity.Y = -1;
            }
            //Normalize Veloicty 
            //velNorm = Vector2.Normalize(velocity);
            //if (velocity.X != 0) { velocity.X = velNorm.X; }
            //if (velocity.Y != 0) { velocity.Y = velNorm.Y; }
            //Calculate Collision
            
            foreach (var ent in collisionGroup)
            {
                if (ent == this)
                { continue; }
                if (ent.Collision.Intersects(this.Collision))
                {
                    collided = true;
                    Debug.WriteLine("Collided");
                    velocity.X = 0;
                    velocity.Y = 0;
                    Debug.WriteLine(velocity);
                }
                else
                {
                    collided = false;
                }
            }
            
            //Apply Movement
            if (!collided)
            {
                position.X = position.X + velocity.X;
                position.Y = position.Y + velocity.Y;
            }
        }
        //
        public void Draw(GameTime gameTime, SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(
                spritesheet,
                new Rectangle(0, 0, 64, 64),
                animator.GetFrame(),
                Color.White
                );
        }
    }
}
