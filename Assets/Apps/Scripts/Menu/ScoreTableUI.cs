using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceInvader;

namespace SpaceInvader.Menu {
    public class ScoreTableUI : BaseMenu {
        public Transform grid;
        public GameObject rowScoreData;

        public List<EnemyData> enemies;

        private void Start() {
            GenerateList(enemies);
        }
        public void GenerateList(List<EnemyData> enemies) {
            foreach(EnemyData enemy in enemies) {
                RowScoreDataUI rsd = Instantiate(rowScoreData, grid).GetComponent<RowScoreDataUI>();
                rsd.SetData(enemy);
            }
        }
    }
}