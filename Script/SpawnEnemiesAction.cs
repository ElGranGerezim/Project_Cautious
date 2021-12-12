using System.Collections.Generic;
using Project_Cautious.Cast.Basics;
using Project_Cautious.Cast.Enemies;
using Project_Cautious.Cast;
using Project_Cautious.UI;
using System;

namespace Project_Cautious.Script{
    public class SpawnEnemiesAction : Action {
        private int _waveNumber = 0;
        Random rand = new Random();
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
                default:
                wave = newRandomWave();
                break;
            }
            _waveNumber++;
            return wave;
        }

        private void SetNewSpawnPositions(int numPositions){
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
                    next = new Turret(spawnPositions[i]);
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
            next = new Turret(spawnPositions[1]);
            wave.Add(next);
            next = new Alien(spawnPositions[2]);
            wave.Add(next);
            next = new Turret(spawnPositions[3]);
            wave.Add(next);
            next = new Alien(spawnPositions[4]);
            wave.Add(next);
            return wave;
        }
        private List<Enemy> newRandomWave(){
            List<Enemy> wave = new List<Enemy>();
            int limit = 5 + (_waveNumber / 6);
            SetNewSpawnPositions(limit);
            for(int i = 0; i < limit; i++){
                wave.Add(getRandomEnemy(i));
            }
            return wave;
        }

        private Enemy getRandomEnemy(int i){
            switch(rand.Next(0,4)){
                case 0:
                if (_waveNumber < 6){
                    return new Mob(spawnPositions[i]);    
                } else if (_waveNumber < 12){
                    return new FastMob(spawnPositions[i]);
                } else {
                    return getRandomEnemy(i);
                }
                case 1:
                if (_waveNumber < 10){
                    return new Turret(spawnPositions[i]);
                } else {
                    return new Bomber(spawnPositions[i]);
                }
                case 2:
                if (_waveNumber < 12){
                    return new Alien(spawnPositions[i]);
                } else {
                    return new AlienFast(spawnPositions[i]);
                }
                case 3:
                if (_waveNumber < 10){
                    return getRandomEnemy(i);
                } else if (_waveNumber < 18){
                    return new TurretFast(spawnPositions[i]);
                } else {
                    return new FastBomber(spawnPositions[i]);
                }
                default:
                return getRandomEnemy(i);
            }
        }
    }
}