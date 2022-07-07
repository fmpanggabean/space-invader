using System;
using System.Collections.Generic;
using UnityEngine;

namespace Space.Game {
    [Serializable]
    internal class EnemyPackController {
        private EnemyManager enemyManager;
        private GameManager gameManager;

        public List<EnemyData> enemiesData;
        public List<Enemy> enemies;

        public int enemyPerRow;

        public EnemyPackController() {
            enemies = new List<Enemy>();
        }

        public void Init(EnemyManager _enemyManager, GameManager _gameManager) {
            enemyManager = _enemyManager;
            gameManager = _gameManager;
        }

        public void GenerateEnemies(Transform _anchor) {
            Vector3 rowAnchor = _anchor.position - new Vector3((float)(enemyPerRow - 1) / 2, 0, 0);

            foreach (EnemyData enemyData in enemiesData) {
                for (int row = 0; row < enemyData.rowCount; row++) {
                    for (int col = 0; col < enemyPerRow; col++) {
                        Vector3 enemyPosition = rowAnchor;
                        enemyPosition.x += col;

                        Enemy e = enemyManager.CreateEnemy(enemyData, enemyPosition);

                        e.SetEnemyData(enemyData);
                        e.onDead += RemoveEnemyFromList;
                        e.onDead += GetScore;
                        enemies.Add(e);
                    }
                    rowAnchor.y -= 1;
                }
            }
        }

        private void GetScore(Entity obj) {
            gameManager.score.GainScore(((Enemy)obj).GetEnemyScore());
        }

        public List<Enemy> GetEnemies() {
            return enemies;
        }

        internal void RemoveEnemyFromList(Entity _e) {
            //Debug.Log("enemy removed");
            enemies.Remove((Enemy)_e);
        }

        public void MovePack(Vector3 _direction) {
            foreach (Enemy enemy in GetEnemies()) {
                enemy.onSetDirection?.Invoke(_direction);
            }
        }

        internal void Stop() {
            foreach (Enemy enemy in GetEnemies()) {
                enemy.onSetDirection?.Invoke(Vector3.zero);
            }
        }

        internal float GetTravelDistance() {
            return GetOneEnemy().deltaPosition.magnitude;
        }

        private Enemy GetOneEnemy() {
            foreach (Enemy e in GetEnemies()) {
                return e;
            }
            return null;
        }
    }
}