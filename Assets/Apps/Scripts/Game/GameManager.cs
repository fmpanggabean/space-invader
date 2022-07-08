using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using SpaceInvader;

namespace SpaceInvader.Game {
    public class GameManager : MonoBehaviour, IManager {
        private DataManager dataManager;

        public event Action onGameManagerStart;
        public event Action<Life> onLifeReduced;
        public event Action onGameOver;

        public GameObject playerPrefab;
        public Player player;

        public Score score;
        public Life life;
        public bool isPlaying;



        private void Awake() {
            dataManager = FindObjectOfType<DataManager>();

            score = new Score(this);
            life = new Life(3);
        }

        internal void Win() {
            SceneManager.LoadScene(1);
        }

        private void Start() {
            onGameManagerStart?.Invoke();
        }

        private void OnEnable() {
            onGameManagerStart += StartGame;
            dataManager.onDataLoaded += score.SetHighscore;
            onGameOver += SaveHighscore;
        }

        private void OnDisable() {
            onGameManagerStart -= StartGame;
            dataManager.onDataLoaded -= score.SetHighscore;
            onGameOver += SaveHighscore;
        }

        private void SaveHighscore() {
            Debug.Log("Saving highscore ... ");
            Debug.Log("highscore : " + score.highscore);
            dataManager.data.SetHighScore(score.score1);
            dataManager.Save();
        }

        private void StartGame() {
            SpawnPlayer(player);
            isPlaying = true;
        }

        private void SpawnPlayer (Entity _entity) {
            player = Instantiate(playerPrefab).GetComponent<Player>();

            player.onDead += ReduceLife;
            player.onDead += PauseGame;
        }

        private void PauseGame (Entity _entity) {
            if (_entity.GetType() == typeof(Player)) {
                StartCoroutine(Continue());
            }
        }

        private IEnumerator Continue() {
            isPlaying = false;
            yield return new WaitForSeconds(2);

            if (life.HasLife())
                StartGame();
        }

        public void ReduceLife (Entity _entity) {
            life.Reduce(1);

            onLifeReduced?.Invoke(life);

            if (!life.HasLife()) {
                GameOver();
            }
        }

        private void GameOver() {
            onGameOver?.Invoke();
        }

        public void Retry() {
            //Init();
            //onGameManagerStart?.Invoke();
            SceneManager.LoadScene(1);
        }

        public void Quit() {
            Application.Quit();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
}