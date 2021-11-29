using System;
using System.Collections.Generic;
using Project_Cautious.Cast.Basics;
using Raylib_cs;

namespace Project_Cautious.Services{
    public class PhysicsService{
        public PhysicsService(){
            
        }

        /// <summary>
        /// Returns true if the two actors overlap.
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public bool IsCollision(Actor first, Actor second)
        {
            if (!(first.canGetHit() && second.canGetHit())){ return false; }

            int x1 = first.GetX();
            int y1 = first.GetY();
            int width1 = first.GetWidth();
            int height1 = first.GetHeight();

            Raylib_cs.Rectangle rectangle1
                = new Raylib_cs.Rectangle(x1, y1, width1, height1);

            int x2 = second.GetX();
            int y2 = second.GetY();
            int width2 = second.GetWidth();
            int height2 = second.GetHeight();

            Raylib_cs.Rectangle rectangle2
                = new Raylib_cs.Rectangle(x2, y2, width2, height2);

            return Raylib.CheckCollisionRecs(rectangle1, rectangle2);
        }
    }
}