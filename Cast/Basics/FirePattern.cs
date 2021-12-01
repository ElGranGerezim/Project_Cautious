using Project_Cautious.Cast.Basics;
using Project_Cautious;
using System.Collections.Generic;
using System.Numerics;
using System;

namespace Project_Cautious{
    public enum patternName{
        Single
    }

    public static class FirePattern{
        public static AttackPattern getFirePattern(patternName name){
            AttackPattern pattern = new AttackPattern();
            switch (name){
                case patternName.Single:
                    pattern._pattern = new List<Tuple<Point, Point>>();
                    pattern._cooldown = 60;
                    Point location = new Point(0,0);
                    Point velocity = new Point(0,10);
                    pattern._pattern.Add(new Tuple<Point, Point>(location, velocity));
                    break;
            }
            return pattern;
        }
    }
    public struct AttackPattern{
        public List<Tuple<Point,Point>> _pattern;
        public string _name;
        public int _cooldown;
    }
}