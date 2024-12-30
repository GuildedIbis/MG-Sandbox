//AnimationManager.cs
//
//Use: Control Animation for Sprite Class objects
//
using System.Diagnostics;

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
        public int counter = 0;
        public int activeFrame = 0;
        public int localFrame = 0;
        public int interval = 15;
        public int animDir = 0;
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
                NextFrame();
                SetDirection();
            }
        }
        //
        //
        public void SetDirection()
        {
            var _totalFrames = numFrames / 4;
            //Set Dir
            Debug.Write("animDir: ");
            Debug.WriteLine(animDir);
            activeFrame = localFrame + animDir * _totalFrames;
            localFrame = localFrame + 1;
            Debug.WriteLine(localFrame);
            if (localFrame >= _totalFrames)
            {
                localFrame = localFrame - _totalFrames;
            }
        }
        //
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
