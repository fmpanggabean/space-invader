using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace SpaceInvader.Game.UI {
    public class ScoreUI : BaseUI {
        private DataController dataManager;

        public TMP_Text scoreText;
        public TMP_Text highscoreText;

        private new void Awake() {
            base.Awake();
            dataManager = FindObjectOfType<DataController>();
        }
        private void Start() {
            gameManager.score.OnGainScore += SetScore1;
            dataManager.OnDataLoaded += SetHighScore;

            SetHighScore(dataManager.data);
        }

        internal void SetScore1(int _score) {
            scoreText.text = _score.ToString("0000");
        }

        internal void SetHighScore(GameData gameData) {
            int _highscore = gameData.highscore;
            highscoreText.text = _highscore.ToString("0000");
        }
    } 
}
