using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Vector2 = Microsoft.Xna.Framework.Vector2;
using Color = Microsoft.Xna.Framework.Color;
using Rectangle = Microsoft.Xna.Framework.Rectangle;
using System.Diagnostics;

namespace MG_Sandbox
{
    internal class AnimationManager
    {
        int numFrames;
        int numCol;
        Vector2 size;

        int counter = 0;
        int activeFrame = 0;
        int interval = 15;

        int rowPos;
        int colPos;
        public AnimationManager(int _numFrames, int _numCol, Vector2 _size) {
            this.numFrames = _numFrames;
            this.numCol = _numCol;
            this.size = _size;
        }

        public void Update()
        {
            counter++;
            //Debug.WriteLine(counter);
            if (counter > interval)
            {
                counter = 0;
                NextFrame(); 
            }
        }

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

        public Rectangle GetFrame()
        {
            return new Rectangle(
                colPos * (int)size.X,
                rowPos * (int)size.Y,
                (int)size.X,
                (int)size.Y);
        }
    }
}
