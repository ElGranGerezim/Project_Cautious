using System.Collections.Generic;
using System.Numerics;
using Project_Cautious.Cast.Basics;
using Project_Cautious.Cast;
using Project_Cautious.Services;
using Raylib_cs;

namespace Project_Cautious.Script{
    public class RemoveDeadAction : Action{
        AudioService _audioService;
        public RemoveDeadAction(AudioService audioService){
            _audioService = audioService;
        }
        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            List<Actor> playerToRemove = new List<Actor>();
            List<Actor> enemyToRemove = new List<Actor>();

            foreach (Actor actor in cast["player"]){
                if (actor is Player){
                    Player player = (Player) actor;
                    if (player.GetHealth() <= 0){
                        playerToRemove.Add(player);
                        _audioService.PlaySound(Constants.SOUND_PLAYER_DIE);
                    }
                }
            }

            foreach (Enemy enemy in cast["enemies"]){
                if (enemy.GetHealth() <= 0){
                    enemyToRemove.Add(enemy);
                    _audioService.PlaySound(Constants.SOUND_ENEMY_DIE);
                }
            }
            
            foreach (Actor bye in playerToRemove){
                cast["player"].Remove(bye);
            }

            foreach (Actor bye in enemyToRemove){
                cast["enemies"].Remove(bye);
            }
        }
    }
}