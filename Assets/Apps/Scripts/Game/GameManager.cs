using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using SpaceInvader;

namespace SpaceInvader.Game {
    public class GameManager : MonoBehaviour, IManager {
        private DataController dataManager;

        public event Action OnGameManagerStart;
        public event Action<Life> OnLifeReduced;
        public event Action OnGameOver;

        public GameObject playerPrefab;
        public Player player;

        public Score score;
        public Life life;
        public bool isPlaying;



        private void Awake() {
            dataManager = FindObjectOfType<DataController>();

            score = new Score(this);
            life = new Life(3);
        }

        internal void Win() {
            SceneManager.LoadScene(1);
        }

        private void Start() {
            OnGameManagerStart?.Invoke();
        }

        private void OnEnable() {
            OnGameManagerStart += StartGame;
            dataManager.OnDataLoaded += score.SetHighscore;
            OnGameOver += SaveHighscore;
        }

        private void OnDisable() {
            OnGameManagerStart -= StartGame;
            dataManager.OnDataLoaded -= score.SetHighscore;
            OnGameOver += SaveHighscore;
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

            OnLifeReduced?.Invoke(life);

            if (!life.HasLife()) {
                GameOver();
            }
        }

        private void GameOver() {
            OnGameOver?.Invoke();
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