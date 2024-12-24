using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace MG_Sandbox
{
    internal class Inputs
    {
        bool space_pressed = false;
        public Inputs()
        {
            
        }
        public void SpacePressed()
        {
            
            if (!space_pressed && Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                space_pressed = true;
                Debug.WriteLine("Space key pressed!");
            }
            if (Keyboard.GetState().IsKeyUp(Keys.Space))
            {
                space_pressed = false;
            }
        }
        public void MouseLeftPressed()
        {
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                Debug.WriteLine("Left Button Clicked");
            }
        }
        
    }
}
