using System.Collections.Generic;
using Project_Cautious.Cast.Basics;
using Project_Cautious.Cast.Enemies;
using Project_Cautious.UI;
using System;

namespace Project_Cautious.Script{
    public class SpawnEnemiesAction : Action {
        private int _waveNumber = 0;
        private List<Point> spawnPositions = new List<Point>();
        public SpawnEnemiesAction(){}
        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            int enemyCount = cast["enemies"].Count;
            if (enemyCount == 0){
                foreach (Enemy next in GetNextWave()){
                    cast["enemies"].Add(next);
                }
                foreach(Counter counter in cast["counters"]){
                    if (counter.GetText() == "Wave"){
                        counter.CountUp();
                    }
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

        private void SetNewSpawnPositions(int numPositions){
            Random rand = new Random();
            spawnPositions.Clear();
            for (int i = 0; i < numPositions; i++){
                int spacing = (Constants.MAX_X / (numPositions + 1));
                int baseX = spacing * (i+1);
                int x = baseX + rand.Next(-(spacing / 2), spacing / 2);
                int maxY = Constants.MAX_Y / 3;
                int y = rand.Next(20, maxY);
                spawnPositions.Add(new Point(x,y));
            }
        }

        private List<Enemy> wave1(){
            SetNewSpawnPositions(2);
            List<Enemy> wave = new List<Enemy>();
            foreach(Point position in spawnPositions){
                Enemy next = new Mob(position);
                wave.Add(next);
            }
            return wave;
        }

        private List<Enemy> wave2(){
            SetNewSpawnPositions(4);
            List<Enemy> wave = new List<Enemy>();
            foreach(Point position in spawnPositions){
                Enemy next = new Mob(position);
                wave.Add(next);
            }
            return wave;
        } 

        private List<Enemy> wave3(){
            List<Enemy> wave = new List<Enemy>();
            SetNewSpawnPositions(5);
            for (int i = 0; i < spawnPositions.Count; i++){
                Enemy next;
                if (i % 2 == 0){
                    next = new Mob(spawnPositions[i]);
                } else {
                    next = new Bomber(spawnPositions[i]);
                }
                wave.Add(next);
            }
            return wave;
        }
        private List<Enemy> wave4(){
            List<Enemy> wave = new List<Enemy>();
            SetNewSpawnPositions(6);
            for (int i = 0; i < spawnPositions.Count; i++){
                Enemy next = new Alien(spawnPositions[i]);
                wave.Add(next);
            }
            return wave;
        }
        private List<Enemy> wave5(){
            List<Enemy> wave = new List<Enemy>();
            SetNewSpawnPositions(5);
            Enemy next = new Alien(spawnPositions[0]);
            wave.Add(next);
            next = new Bomber(spawnPositions[1]);
            wave.Add(next);
            next = new Alien(spawnPositions[2]);
            wave.Add(next);
            next = new Bomber(spawnPositions[3]);
            wave.Add(next);
            next = new Alien(spawnPositions[4]);
            wave.Add(next);
            return wave;
        }
        private List<Enemy> wave6(){
            List<Enemy> wave = new List<Enemy>();
            return wave;
        }
    }
}