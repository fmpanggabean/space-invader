using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace SpaceInvader.Game.UI {
    public class ScoreUI : BaseUI {
        public TMP_Text scoreText;
        public TMP_Text highscoreText;

        private void Start() {

        }

        internal void SetScore1(int _score) {
            scoreText.text = _score.ToString("0000");
        }

        internal void SetHighScore(int _highscore) {
            highscoreText.text = _highscore.ToString("0000");
        }
    } 
}
