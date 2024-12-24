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

namespace MG_Sandbox
{
    internal class Player : Entity
    {
        public Player(Texture2D _texture, Vector2 _position, Color _color) : base(_texture, _position, _color) 
        {

        }
        
        //
        public void Update(GameTime gameTime, List<Entity> collisionGroup)
        {
            
            //
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
                    //velocity.X = -velocity.X;
                    //velocity.Y = -velocity.Y;
                    Debug.WriteLine(velocity);
                }
                else
                {
                    collided = false;
                }
            }
            if (!collided)
            {
                position.X = position.X + velocity.X;
                position.Y = position.Y + velocity.Y;
            }
        }
        //
        //public override void Update(GameTime gameTime, List<Sprite> collisionGroup)
        //{
        //    base.Update(gameTime);
        //}
    }
}
