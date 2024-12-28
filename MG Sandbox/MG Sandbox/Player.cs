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
            this.texture = _texture;
            this.position = _position;
            this.color = _color;
        }
        public void LoadContent()
        {
            spritesheet = texture;
            animator = new(12, 16, new Vector2(64, 64));
            Debug.WriteLine("Player Loaded");
        }
        //
        //
        public override void Update(GameTime gameTime)
        {

            //Set Velocity
            //Debug.WriteLine("Update Player");
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
            /*
            foreach (var ent in entities)
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
            */
            //Apply Movement
            if (!collided)
            {
                position.X = position.X + velocity.X;
                position.Y = position.Y + velocity.Y;
            }
            animator.Update();
        }
        //
        public override void Draw(GameTime gameTime, SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(
                spritesheet,
                new Rectangle((int)position.X, (int)position.Y, 64, 64),
                animator.GetFrame(),
                Color.White
                );
        }
    }
}
