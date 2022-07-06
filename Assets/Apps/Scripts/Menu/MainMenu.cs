using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Space.Menu {
    public class MainMenu : BaseMenu {
        public Button playButton;

        private void Awake() {
            playButton.onClick.AddListener(StartGame);
        }

        public void StartGame() {
            SceneManager.LoadSceneAsync(1);
        }
    }
}