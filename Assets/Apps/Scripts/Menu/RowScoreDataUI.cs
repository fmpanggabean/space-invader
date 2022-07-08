using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceInvader.Menu {
    public class RowScoreDataUI : MonoBehaviour {
        public Image sprite;
        public Text pointText;

        public void SetData(EnemyData enemy) {
            sprite.sprite = enemy.sprite;

            if (enemy.type == EnemyType.Normal) {
                pointText.text = "= " + enemy.point.ToString() + " points";
            } else if (enemy.type == EnemyType.Mistery) {
                pointText.text = "= ? Mistery";
            }
        }
    } 
}
