//AnimationManager.cs
//
//Use: Control Animation for Sprite Class objects
//
namespace MG_Sandbox.Managers
{
    internal class AnimationManager
    {
        //
        Vector2 size;
        Vector2 velocity;
        int numFrames;
        int numCol;
        int rowPos;
        int colPos;
        //
        int counter = 0;
        int activeFrame = 0;
        int localFrame = 0;
        int interval = 15;
        //
        public AnimationManager(int _numFrames, int _numCol, Vector2 _size)
        {
            numFrames = _numFrames;
            numCol = _numCol;
            size = _size;
        }
        //
        //
        public void Update()
        {
            counter++;
            //velocity = _velocity;
            //Debug.WriteLine(counter);
            if (counter > interval)
            {
                counter = 0;
                //SetDirection();
                NextFrame();
            }
        }
        //
        /*
        public void SetDirection()
        {
            var _totalFrames = numFrames / 4;
            var _direction;

            _direction =
            //Set Dir
            activeFrame = localFrame + _direction * _totalFrames;
            localFrame = localFrame + sprite_get_speed(sprite_index) / _frameRate;
            //Cuts the degree by 90 to give you a number between 0 and 3
            //The 0-3 is multiplied by the 1/4 frame number because all four sprites are within a single sprite.
            //Local frame then increments in the speed of the animation
            if (local_frame >= _totalFrames)
            {
                animation_end = true;
                local_frame = local_frame - _totalFrames;
            }
            else animation_end = false;
        }
        */
        //
        public void NextFrame()
        {
            activeFrame++;
            colPos++;
            //Debug.WriteLine(colPos);
            if (activeFrame >= numFrames)
            {
                activeFrame = 0;
                colPos = 0;
                rowPos = 0;
            }
            if (colPos >= numCol)
            {
                colPos = 0;
                rowPos++;
            }
        }
        //
        //
        public Rectangle GetFrame()
        {
            return new Rectangle(
                colPos * (int)size.X,
                rowPos * (int)size.Y,
                (int)size.X,
                (int)size.Y);
        }
        //
    }
}
