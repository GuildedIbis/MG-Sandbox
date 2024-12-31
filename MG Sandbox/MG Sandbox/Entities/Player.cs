//Player.cs
//
//Use: The Entity controlled by the client
//
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using MG_Sandbox.Managers;
//
namespace MG_Sandbox.Entities
{
    internal class Player : Entity
    {
        public List<int> animWalkRight;
        public List<int> animWalkUp;
        public List<int> animWalkLeft;
        public List<int> animWalkDown;
        int[] animKey = new int[] { };
        public Player(Texture2D _texture, Vector2 _position, Color _color) : base(_texture, _position, _color)
        {
            texture = _texture;
            position = _position;
            color = _color;
        }
        public void LoadContent()
        {
            
            spritesheet = texture;
            speed = 40;
            
            Debug.WriteLine("Player Loaded");
            List<int> animWalkRight = new List<int>();
            animKey = new int[] { 0, 1, 2, 3 };
            animWalkRight.AddRange(animKey);

            List<int> animWalkUp = new List<int>();
            animKey =  new int[] { 4, 5, 6, 7 };
            animWalkUp.AddRange(animKey);

            List<int> animWalkLeft = new List<int>();
            animKey = new int[] { 8, 9, 10, 11 };
            animWalkLeft.AddRange(animKey);

            List<int> animWalkDown = new List<int>();
            animKey = new int[] { 12, 13, 14, 15 };
            animWalkDown.AddRange(animKey);

            //Debug.WriteLine(animWalkUp.Count);

            animator = new(animWalkUp, 16, new Vector2(64, 64));
        }
        //
        //
        public override void Update()
        {

            //Set Velocity
            PlayerMove();
            //PlayerCollide();
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
        //
        //
        public void PlayerMove()
        {
            if (InputManager.Direction != Vector2.Zero)
            {
                var dir = InputManager.Direction;
                var normDir = Vector2.Normalize(dir);

                var newX = (float)(position.X + normDir.X * speed * Globals.TotalSeconds);
                var newY = (float)(position.Y + normDir.Y * speed * Globals.TotalSeconds);
                var newPos = new Vector2(newX, newY);
                moveAngle = MoveDirectionAngle((double)dir.X, (double)dir.Y);
                animator.animDir = moveAngle / 90;
                position = new Vector2(
                    MathHelper.Clamp(newPos.X, 0, Globals.Bounds.X),
                    MathHelper.Clamp(newPos.Y, 0, Globals.Bounds.Y)
                    );
                if (InputManager.MoveKeyPressed)
                { 
                    switch (moveAngle / 90)
                    {
                        case 0:
                            animator = new(animWalkRight, 16, new Vector2(64, 64));
                            break;
                    }
                }

            }
        }
        //
        //
        public void PlayerCollide()
        {
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
        }
    }
}
