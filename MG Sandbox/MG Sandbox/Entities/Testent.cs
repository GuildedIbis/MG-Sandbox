//Testent.cs
//
//Use: Running independently in Game1
//
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using MG_Sandbox.Managers;
//
namespace MG_Sandbox.Entities
{
    internal class Testent : Entity
    {
        public AnimationManager animWalkRight;
        public AnimationManager animWalkUp;
        public AnimationManager animWalkLeft;
        public AnimationManager animWalkDown;
        public AnimationManager animIdleRight;
        public AnimationManager animIdleUp;
        public AnimationManager animIdleLeft;
        public AnimationManager animIdleDown;


        int[] animKey = new int[] { };
        List<int> keyList = new List<int>();
        public Testent(Texture2D _texture, Vector2 _position, Color _color) : base(_texture, _position, _color)
        {
            texture = _texture;
            position = _position;
            color = _color;
        }
        public void LoadContent()
        {
            speed = 40;
            PlayerLoadAnimations();
        }
        //
        //
        public override void Update()
        {

            //Set Velocity
            PlayerMove();
            //PlayerCollide();
            PlayerUpdateAnimations();
            animator.Update();
            //Debug.WriteLine(position.X);
            //Debug.WriteLine(position.Y);
        }
        //
        //
        public override void Draw()
        {
            int _drawPosX = (int)position.X;
            int _drawPosY = (int)position.Y;
            Debug.WriteLine(_drawPosX);
            Debug.WriteLine(_drawPosY);
            Globals.SpriteBatch.Draw(
                texture,
                new Rectangle(_drawPosX, _drawPosY, 64, 64),
                new Rectangle(_drawPosX, _drawPosY, 64, 64),
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
                lastAngle = moveAngle;
                //animator.animDir = moveAngle / 90;
                position = new Vector2(
                    MathHelper.Clamp(newPos.X, 0, Globals.Bounds.X),
                    MathHelper.Clamp(newPos.Y, 0, Globals.Bounds.Y)
                    );
                //position = position + normDir * speed * Globals.TotalSeconds;
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
        //
        //
        public void PlayerLoadAnimations()
        {
            animKey = new int[] { 0, 1, 2, 3 };
            keyList.Clear();
            keyList.AddRange(animKey);
            animWalkRight = new(keyList, 16, new Vector2(64, 64));

            animKey = new int[] { 4, 5, 6, 7 };
            keyList.Clear();
            keyList.AddRange(animKey);
            animWalkUp = new(keyList, 16, new Vector2(64, 64));

            animKey = new int[] { 8, 9, 10, 11 };
            keyList.Clear();
            keyList.AddRange(animKey);
            animWalkLeft = new(keyList, 16, new Vector2(64, 64));

            animKey = new int[] { 12, 13, 14, 15 };
            keyList.Clear();
            keyList.AddRange(animKey);
            animWalkDown = new(keyList, 16, new Vector2(64, 64));

            animKey = new int[] { 1 };
            keyList.Clear();
            keyList.AddRange(animKey);
            animIdleRight = new(keyList, 16, new Vector2(64, 64));

            animKey = new int[] { 5 };
            keyList.Clear();
            keyList.AddRange(animKey);
            animIdleUp = new(keyList, 16, new Vector2(64, 64));

            animKey = new int[] { 9 };
            keyList.Clear();
            keyList.AddRange(animKey);
            animIdleLeft = new(keyList, 16, new Vector2(64, 64));

            animKey = new int[] { 13 };
            keyList.Clear();
            keyList.AddRange(animKey);
            animIdleDown = new(keyList, 16, new Vector2(64, 64));
        }
        //
        //
        public void PlayerUpdateAnimations()
        {
            if (InputManager.Direction != Vector2.Zero)
            {
                switch (moveAngle / 90)
                {
                    case 0:
                        animator = animWalkRight;
                        break;
                    case 1:
                        animator = animWalkUp;
                        break;
                    case 2:
                        animator = animWalkLeft;
                        break;
                    case 3:
                        animator = animWalkDown;
                        break;
                    default:
                        Debug.WriteLine("Default Animation");
                        break;
                }
            }
            else
            {
                switch (lastAngle / 90)
                {
                    case 0:
                        animator = animIdleRight;
                        break;
                    case 1:
                        animator = animIdleUp;
                        break;
                    case 2:
                        animator = animIdleLeft;
                        break;
                    case 3:
                        animator = animIdleDown;
                        break;
                    default:
                        Debug.WriteLine("Default Animation");
                        break;
                }
            };
        }
    }
}
