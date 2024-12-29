//Player.cs
//
//Use: The Entity controlled by the client
//
using System.Diagnostics;
using MG_Sandbox.Managers;
//
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
            speed = 40;
            animator = new(12, 16, new Vector2(64, 64));
            Debug.WriteLine("Player Loaded");
        }
        //
        //
        public override void Update()
        {

            //Set Velocity
            //Debug.WriteLine("Update Player");
            if (InputManager.Direction != Vector2.Zero)
            {
                var dir = Vector2.Normalize(InputManager.Direction);
                var newX = (float)(position.X + (dir.X * speed * Globals.TotalSeconds));
                var newY = (float)(position.Y + (dir.Y * speed * Globals.TotalSeconds));
                var newPos = new Vector2(newX, newY);
                position = new Vector2(
                    MathHelper.Clamp(newPos.X, 0, Globals.Bounds.X),
                    MathHelper.Clamp(newPos.Y, 0, Globals.Bounds.Y)
                    );
                
            }
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
            animator.Update();
        }
        //
        public override void Draw()
        {
            Globals.SpriteBatch.Draw(
                spritesheet,
                new Rectangle((int)position.X, (int)position.Y, 64, 64),
                animator.GetFrame(),
                Color.White
                );
        }
    }
}
