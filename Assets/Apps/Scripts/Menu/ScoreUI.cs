using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SpaceInvader.Menu {
    public class ScoreUI : BaseMenu {
        public TMP_Text score1;
        public TMP_Text score2;
        public TMP_Text highscore;

        public void SetHighScore(int _highscore) {
            highscore.text = _highscore.ToString("0000");
        }
        public void SetScore1(int _score1) {
            score1.text = _score1.ToString("0000");
        }
    } 
}
