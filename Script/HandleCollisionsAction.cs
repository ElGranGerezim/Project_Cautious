using System.Collections.Generic;
using Raylib_cs;
using Project_Cautious.Services;
using Project_Cautious.Cast.Basics;
using Project_Cautious.Cast;
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
                foreach (Player player in cast["player"]){
                    if (_physicsService.IsCollision(player, bullet)){
                        player.TakeDamage();
                        bulletsToRemove.Add(bullet);
                    }
                }
            }

            foreach (Bullet bye in bulletsToRemove){
                cast["bullets"].Remove(bye);
            }
        }

    }
}