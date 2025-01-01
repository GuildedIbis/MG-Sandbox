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
        public int numCol = 0;
        public int rowPos = 0;
        public int colPos = 0;
        //
        public List<List<int>> animations = new List<List<int>>();
        public List<int> animKeys = new List<int>();
        public int counter = 0;
        public int activeFrame = 0;
        public int localFrame = 0;
        public int interval = 15;
        public int animationIndex = 0;
        //
        public AnimationManager(List<int> _animKeys, int _numCol, Vector2 _size)
        {
            animKeys.Clear();
            animKeys.AddRange(_animKeys);
            numCol = _numCol;
            size = _size;
        }
        //
        //
        public void Update()
        {
            if (animKeys.Count >= 1)
            {
                counter++;
                //velocity = _velocity;
                //Debug.WriteLine(counter);
                //if (velocity != 0)
                if (counter > interval)
                {
                    Debug.WriteLine(animKeys);
                    counter = 0;
                    localFrame++;
                    //Debug.WriteLine(colPos);
                    if (localFrame >= animKeys.Count)
                    {
                        localFrame = 0;

                    }
                    //SetDirection();
                }
            }
        }
        //
        //
        public void SetDirection()
        {
            //Set Dir
            Debug.Write("animDir: ");
            //Debug.WriteLine(animDir);
            
        }
        //
        //
        public Rectangle GetFrame()
        {
            //Debug.WriteLine(animKeys.Count());
            if (animKeys.Count >= 1)
            {
                colPos = animKeys.ElementAt(localFrame) % numCol;
                rowPos = animKeys.ElementAt(localFrame) / numCol;
            }
            return new Rectangle(
                colPos * (int)size.X,
                rowPos * (int)size.Y,
                (int)size.X,
                (int)size.Y);
        }
        //
        /*
        public void MoveAnimation()
        {
            switch(animDir)
            {
                case 0:
                    return anim
                    break;
            }
        }
        */
    }
}
