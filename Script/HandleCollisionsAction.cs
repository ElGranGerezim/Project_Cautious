using System.Collections.Generic;
using Raylib_cs;
using Project_Cautious.Services;
using Project_Cautious.Cast.Basics;
using Project_Cautious.Cast;
using Project_Cautious.UI;
namespace Project_Cautious.Script{
    public class HandleCollisionsAction : Action{
        /// <summary>
        /// Action to determine collisions between actors.
        /// </summary>
        PhysicsService _physicsService;
        AudioService _audioService;

        public HandleCollisionsAction(PhysicsService physicsService, AudioService audioService){
            _physicsService = physicsService;
            _audioService = audioService;
        }

        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            List<Actor> bulletsToRemove = new List<Actor>();
            foreach (Bullet bullet in cast["bullets"]){
                if (bullet.GetPlayerFriendly()){
                    foreach(Enemy enemy in cast["enemies"]){
                        if (_physicsService.IsCollision(enemy, bullet)){
                            enemy.TakeDamage();
                            bulletsToRemove.Add(bullet);
                        }
                    }
                } else{
                    foreach (Actor actor in cast["player"]){
                        if (actor is Player){
                            Player player = (Player) actor;
                            if (_physicsService.IsCollision(player, bullet)){
                                player.TakeDamage();
                                _audioService.PlaySound(Constants.SOUND_PLAYER_HIT);
                                foreach (Counter counter in cast["counters"]){
                                    if (counter.GetText() == "Health"){
                                        counter.CountDown();
                                    }
                                }
                                bulletsToRemove.Add(bullet);
                            }   
                        }
                    }
                }
            }

            foreach (Bullet bye in bulletsToRemove){
                cast["bullets"].Remove(bye);
            }
        }

    }
}