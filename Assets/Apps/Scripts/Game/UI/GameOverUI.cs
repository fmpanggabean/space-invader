using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

namespace Space.Game.UI {
    public class GameOverUI : BaseUI {
        public Button buttonQuit;
        public Button buttonRetry;


        private void Start() {


            Hide();
        }

        internal void SetRetryButton(Action retry) {
            buttonRetry.onClick.AddListener(retry.Invoke);
        }

        internal void SetQuitButton(Action quit) {
            buttonQuit.onClick.AddListener(quit.Invoke);
        }
    }
}