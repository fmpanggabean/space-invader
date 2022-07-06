using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Space;

namespace Space.Menu {
    public class ScoreTableUI : BaseMenu {
        public Transform grid;
        public GameObject rowScoreData;

        public void GenerateList(List<EnemyData> enemies) {
            foreach(EnemyData enemy in enemies) {
                RowScoreDataUI rsd = Instantiate(rowScoreData, grid).GetComponent<RowScoreDataUI>();
                rsd.SetData(enemy);
            }
        }
    }
}