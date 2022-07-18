using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

namespace SpaceInvader.Game.UI {
    public class GameOverUI : BaseUI {
        public Button buttonQuit;
        public Button buttonRetry;


        private void Start() {
            gameManager.OnGameOver += Show;

            buttonRetry.onClick.AddListener(gameManager.Retry);
            buttonQuit.onClick.AddListener(gameManager.Quit);

            Hide();
        }
    }
}