using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Space;

namespace Space.Game {
    public class GameManager : MonoBehaviour, IManager {
        public event Action onGameStart;

        public GameObject player;

        private void Start() {
            onGameStart?.Invoke();
        }

        private void Update() {
            //test pause
            if (Input.GetKeyDown(KeyCode.Alpha1)) {
                Time.timeScale = 0;
            } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
                Time.timeScale = 1;
            }
        }

        private void OnEnable() {
            onGameStart += InitPlayer;
        }
        private void OnDisable() {
            onGameStart -= InitPlayer;
        }

        private void InitPlayer() {
            player = Instantiate(player) ;
        }
    }
}