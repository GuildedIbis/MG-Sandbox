//AnimationManager.cs
//
//Use: Control Animation for Sprite Class objects
//
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MG_Sandbox.Managers
{
    internal class AnimationManager
    {
        //
        Vector2 size;
        Vector2 velocity;
        List<int> animKeys;
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
        public AnimationManager(List<int> _animKeys, int _numCol, Vector2 _size)
        {
            animKeys = _animKeys;
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
            //if (velocity != 0)
            if (counter > interval)
            {
                counter = 0;
                localFrame++;
                //Debug.WriteLine(colPos);
                if (localFrame >= animKeys.Count)
                {
                    localFrame = 0;

                }
                SetDirection();
            }
        }
        //
        //
        public void SetDirection()
        {
            //Set Dir
            Debug.Write("animDir: ");
            Debug.WriteLine(animDir);
            
        }
        //
        //
        public Rectangle GetFrame()
        {
            colPos = animKeys.ElementAt(localFrame) % numCol;
            rowPos = animKeys.ElementAt(localFrame) / numCol;
            return new Rectangle(
                colPos * (int)size.X,
                rowPos * (int)size.Y,
                (int)size.X,
                (int)size.Y);
        }
        //
        //
        public void MoveAnimation()
        {
            switch(animDir)
            {
                case 0:
                    return anim
                    break;
            }
        }
    }
}
