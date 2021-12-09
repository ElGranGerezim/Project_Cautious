using System.Collections.Generic;
using System;
using System.Numerics;
using Project_Cautious.Cast.Basics;
using Project_Cautious.Cast;
using Project_Cautious.Services;
using Raylib_cs;

namespace Project_Cautious.Script{
    public class AttackAction : Action{
        InputService _inputService;
        public AttackAction(InputService inputService){
            _inputService = inputService;
        }
        
        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            foreach (List<Actor> group in cast.Values){
                foreach (Gunner attacker in cast["enemies"]){
                    if (attacker.CanFire()){
                        AttackPattern attack = attacker.Attack();
                        foreach (Tuple<Point,Point> template in attack._pattern){
                            Point location = attacker.GetCenterFire().Add(template.Item1);
                            Point velocity = template.Item2;
                            Bullet next = new Bullet(location, velocity);
                            cast["bullets"].Add(next);
                        }
                    }
                    else {
                        attacker.UpdateLastFire();
                    }
                }

                foreach(Actor actor in cast["player"]){
                    if (actor is Player){
                        Player player = (Player) actor;
                        if (_inputService.IsFireKeyPressed() && player.CanFire()){
                            AttackPattern attack = player.Attack();
                            foreach (Tuple<Point,Point> template in attack._pattern){
                                Point location = player.GetCenterFire().Add(template.Item1);
                                Point velocity = new Point(template.Item2.GetX(), template.Item2.GetY() * 2);
                                velocity.invertY();
                                Bullet next = new Bullet(location, velocity, true);
                                cast["bullets"].Add(next);
                            }
                        } else {
                            player.UpdateLastFire();
                        }
                    }
                }
            }
        }
    }
}