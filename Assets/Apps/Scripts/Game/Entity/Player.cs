using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace SpaceInvader.Game {
    
    public class Player : Entity {
        private Vector3 inputDirection;

        public override EntityType EntityType => EntityType.Player;

        //private GameManager gameManager;

        private void Awake() {
            inputDirection = new Vector3();
            targets = new List<EntityType>();

            targets.Add(EntityType.Enemy);
        }

        private void Update() {
            InputHandler();
        }

        private void OnEnable() {
            onDead += DestroyPlayer;
        }

        private void OnDisable() {
            onDead -= DestroyPlayer;
        }

        //public void SetGameManager(GameManager _gameManager) {
        //    gameManager = _gameManager;
        //}

        private void DestroyPlayer(Entity _entity) {
            Destroy(gameObject);            
        }

        private void InputHandler() {
            inputDirection.x = Input.GetAxisRaw("Horizontal");
            onSetDirection?.Invoke(inputDirection);
        }
    }
}