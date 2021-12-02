using Project_Cautious.Cast.Basics;
using Project_Cautious;
using System.Collections.Generic;
using System.Numerics;
using System;

namespace Project_Cautious{
    public enum patternName{
        Single,
        Triple
    }

    public static class FirePattern{
        public static AttackPattern getFirePattern(patternName name){
            AttackPattern pattern = new AttackPattern();
            pattern._pattern = new List<Tuple<Point, Point>>();
            Point location;
            Point velocity;
            switch (name){
                case patternName.Single:
                    pattern._cooldown = 60;
                    location = new Point(0,0);
                    velocity = new Point(0,10);
                    pattern._pattern.Add(new Tuple<Point, Point>(location, velocity));
                    break;
                case patternName.Triple:
                    pattern._cooldown = 60;
                    location = new Point(0,0);
                    velocity = new Point(0,10);
                    pattern._pattern.Add(new Tuple<Point, Point>(location, velocity));
                    location = new Point(-30, 0);
                    pattern._pattern.Add(new Tuple<Point, Point>(location, velocity));
                    location = new Point(30, 0);
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