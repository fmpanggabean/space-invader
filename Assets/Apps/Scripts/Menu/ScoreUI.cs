using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Space.Menu {
    public class ScoreUI : BaseMenu {
        public TMP_Text score1;
        public TMP_Text score2;
        public TMP_Text highscore;

        public void SetScore(int _score1, int _score2, int _highscore) {
            score1.text = _score1.ToString();
            score2.text = _score2.ToString();
            highscore.text = _highscore.ToString();
        }
    } 
}
