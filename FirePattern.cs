using Project_Cautious.Cast.Basics;
using Project_Cautious;
using System.Collections.Generic;
using System.Numerics;
using System;

namespace Project_Cautious{
    public enum patternName{
        Single,
        SingleFast,
        Triple,
        Shotgun,
        Laser,
        Flak,
        V
    }

    public static class FirePattern{
        public static AttackPattern getFirePattern(patternName name){
            Random rand = new Random();
            AttackPattern pattern = new AttackPattern();
            pattern._pattern = new List<Tuple<Point, Point>>();
            Point location;
            Point velocity;
            switch (name){
                case patternName.Single:
                    pattern._cooldown = 120;
                    location = new Point(0,0);
                    velocity = new Point(0,5);
                    pattern._pattern.Add(new Tuple<Point, Point>(location, velocity));
                    break;
                case patternName.SingleFast:
                    pattern._cooldown = 60;
                    location = new Point(0,0);
                    velocity = new Point(0,5);
                    pattern._pattern.Add(new Tuple<Point, Point>(location, velocity));
                    break;
                case patternName.Triple:
                    pattern._cooldown = 120;
                    location = new Point(0,0);
                    velocity = new Point(0,3);
                    pattern._pattern.Add(new Tuple<Point, Point>(location, velocity));
                    location = new Point(3 * Constants.DEFAULT_SQUARE_SIZE, 0);
                    pattern._pattern.Add(new Tuple<Point, Point>(location, velocity));
                    location = new Point(-(3*Constants.DEFAULT_SQUARE_SIZE), 0);
                    pattern._pattern.Add(new Tuple<Point, Point>(location, velocity));
                    break;
                case patternName.Shotgun:
                    pattern._cooldown = 60;
                    location = new Point(0,0);
                    velocity = new Point(0,5);
                    pattern._pattern.Add(new Tuple<Point, Point>(location, velocity));
                    velocity = new Point(2,5);
                    pattern._pattern.Add(new Tuple<Point, Point>(location, velocity));
                    velocity = new Point(-2, 5);
                    pattern._pattern.Add(new Tuple<Point, Point>(location,velocity));
                    break;
                case patternName.Laser:
                    pattern._cooldown = 20;
                    location = new Point(0,0);
                    velocity = new Point(0, 5);
                    pattern._pattern.Add(new Tuple<Point, Point>(location,velocity));
                    location = new Point(0, 5);
                    pattern._pattern.Add(new Tuple<Point, Point>(location,velocity));
                    location = new Point(0, 10);
                    pattern._pattern.Add(new Tuple<Point, Point>(location,velocity));
                    location = new Point(0, 15);
                    pattern._pattern.Add(new Tuple<Point, Point>(location,velocity));
                    location = new Point(0, 20);
                    pattern._pattern.Add(new Tuple<Point, Point>(location,velocity));
                    break;
                case patternName.Flak:
                    pattern._cooldown = 70;
                    int numFlak = rand.Next(2,7);
                    for (int i = 1; i <= numFlak; i++){
                        pattern._pattern.Add(GetFlak());
                    }
                    break;
                case patternName.V:
                    pattern._cooldown = 80;
                    location = new Point(0,0);
                    velocity = new Point(2,5);
                    pattern._pattern.Add(new Tuple<Point, Point>(location, velocity));
                    velocity = new Point(-2, 5);
                    pattern._pattern.Add(new Tuple<Point, Point>(location, velocity));
                    break;
            }
            return pattern;
        }

        public static Tuple<Point, Point> GetFlak(){
            Random rand = new Random();
            Point location = new Point(rand.Next(-10, 10), 0);
            Point velocity = new Point(rand.Next(-5,5), rand.Next(5, 20));
            return new Tuple<Point, Point>(location, velocity);
        }
    }
    public struct AttackPattern{
        public List<Tuple<Point,Point>> _pattern;
        public string _name;
        public int _cooldown;
    }
}