using System;
using System.Collections.Generic;
using UnityEngine;

namespace Space.Game {
    [Serializable]
    internal class EnemyPackController {
        public List<GameObject> enemiesPrefab;

        public int enemyPerRow;

        private List<Enemy> enemies;
    }
}