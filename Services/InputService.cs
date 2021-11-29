using System;
using System.Collections.Generic;
using Raylib_cs;
using key = Raylib_cs.KeyboardKey;
using Project_Cautious.Cast.Basics;

namespace Project_Cautious.Services{
    public class InputService{
        public InputService(){
            
        }

        /// <summary>
        /// Computes whether any button representing left is being pressed.
        /// </summary>
        /// <returns>Bool representing if a key is pressed</returns>
        public bool IsLeftPressed(){
            return (Raylib.IsKeyDown(key.KEY_LEFT) || Raylib.IsKeyDown(key.KEY_A));
        }

        /// <summary>
        /// Computes whether any button representing right is being pressed.
        /// </summary>
        /// <returns>Bool representing if a key is pressed</returns>
        public bool IsRightPressed(){
            return (Raylib.IsKeyDown(key.KEY_RIGHT) || Raylib.IsKeyDown(key.KEY_D));
        }

        /// <summary>
        /// Computes whether any button representing up is being pressed.
        /// </summary>
        /// <returns>Bool representing if a key is pressed</returns>
        public bool IsUpPressed(){
            return (Raylib.IsKeyDown(key.KEY_UP) || Raylib.IsKeyDown(key.KEY_W));
        }

        /// <summary>
        /// Computes whether any button representing down is being pressed.
        /// </summary>
        /// <returns>Bool representing if a key is pressed</returns>
        public bool IsDownPressed(){
            return (Raylib.IsKeyDown(key.KEY_DOWN) || Raylib.IsKeyDown(key.KEY_S));
        }

        public bool IsFocusKeyPressed(){
            return (Raylib.IsKeyDown(key.KEY_LEFT_SHIFT));
        }

        public bool IsFireKeyPressed(){
            return(Raylib.IsKeyDown(key.KEY_SPACE));
        }

        /// <summary>
        /// Gets the direction asked for by the current key presses
        /// </summary>
        /// <returns></returns>
        public Point GetDirection()
        {
            int x = 0;
            int y = 0;

            if (IsLeftPressed())
            {
                x = -1;
            }

            if (IsRightPressed())
            {
                x = 1;
            }
            
            if (IsUpPressed())
            {
                y = -1;
            }
            
            if (IsDownPressed())
            {
                y = 1;
            }
            
            return new Point(x, y);
        }

        public bool IsContinuePressed(){
            return Raylib.IsKeyDown(key.KEY_ENTER);
        }
    }
}