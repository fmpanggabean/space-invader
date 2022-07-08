using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

namespace SpaceInvader.Game.UI {
    public class UIManager : MonoBehaviour, IManager {
        private GameManager gameManager;
        private DataManager dataManager;

        public List<BaseUI> uiCollection;

        private void Awake() {
            gameManager = FindObjectOfType<GameManager>();
            dataManager = FindObjectOfType<DataManager>();

            uiCollection = FindObjectsOfType<BaseUI>().ToList<BaseUI>();
        }

        private void Start() {
            GetUI<ScoreUI>().SetHighScore(dataManager.data.highscore);
        }

        private void OnEnable() {
            gameManager.score.onGainScore += UpdateScore;
            gameManager.onLifeReduced += UpdateLife;
            gameManager.onGameOver += ShowGameOver;
            dataManager.onDataLoaded += ShowScore;

            GetUI<GameOverUI>().SetRetryButton(gameManager.Retry);
            GetUI<GameOverUI>().SetQuitButton(gameManager.Quit);
        }

        private void OnDisable() {
            gameManager.score.onGainScore -= UpdateScore;
            gameManager.onLifeReduced -= UpdateLife;
            gameManager.onGameOver -= ShowGameOver;
            dataManager.onDataLoaded += ShowScore;
        }

        private void ShowScore(GameData _data) {
            GetUI<ScoreUI>().SetHighScore(_data.highscore);
        }

        private T GetUI<T>() where T : BaseUI {
            foreach(BaseUI ui in uiCollection) {
                if (ui.GetType() == typeof(T)) {
                    return (T)ui;
                }
            }
            return null;
        }

        private void UpdateScore(int score) {
            GetUI<ScoreUI>().SetScore1(score);
        }

        private void UpdateLife (Life _life) {
            GetUI<LifeUI>().ShowLife(_life.value);
        }

        private void ShowGameOver() {
            GetUI<GameOverUI>().Show();
        }
    }
}