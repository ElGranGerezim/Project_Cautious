using System.Collections.Generic;
using System.Numerics;
using Project_Cautious.Cast.Basics;
using Project_Cautious.Cast;
using Project_Cautious.Services;
using Raylib_cs;

namespace Project_Cautious.Script{
    public class SpawnEnemiesAction : Action {
        private int _waveNumber = 0;
        public SpawnEnemiesAction(){}
        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            int enemyCount = cast["enemies"].Count;
            if (enemyCount == 0){
                foreach (Enemy next in GetNextWave()){
                    cast["enemies"].Add(next);
                }
            }
        }

        private List<Enemy> GetNextWave(){
            List<Enemy> wave = new List<Enemy>();
            switch (_waveNumber){
                case 0:
                wave = wave1();
                break;
                case 1:
                wave = wave2();
                break;
                case 2:
                wave = wave3();
                break;
                case 3:
                wave = wave4();
                break;
                case 4:
                wave = wave5();
                break;
                case 5:
                wave = wave6();
                break;
            }
            _waveNumber++;
            return wave;
        }

        private List<Enemy> wave1(){
            List<Enemy> wave = new List<Enemy>();
            Enemy next = new Enemy();
            wave.Add(next);
            return wave;
        }

        private List<Enemy> wave2(){
            List<Enemy> wave = new List<Enemy>();
            Enemy next = new Enemy();
            wave.Add(next);
            return wave;
        } 

        private List<Enemy> wave3(){
            List<Enemy> wave = new List<Enemy>();
            return wave;
        }
        private List<Enemy> wave4(){
            List<Enemy> wave = new List<Enemy>();
            return wave;
        }
        private List<Enemy> wave5(){
            List<Enemy> wave = new List<Enemy>();
            return wave;
        }
        private List<Enemy> wave6(){
            List<Enemy> wave = new List<Enemy>();
            return wave;
        }
    }
}