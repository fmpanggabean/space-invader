using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace SpaceInvader.Game {
    public enum MovementDirection {
        Right, Down, Left
    }

    public class EnemyManager : MonoBehaviour, IManager {
        private GameManager gameManager;

        private List<MovementDirection> movementDirection;
        private int currentIndex;
        private Vector3 direction;
        private float travelDistance;

        [SerializeField]
        private EnemyPackController enemyPackController;

        public Transform leftBoundary;
        public Transform rightBoundary;

        private void Awake() {
            gameManager = FindObjectOfType<GameManager>() as GameManager;

            movementDirection = new List<MovementDirection>();
            enemyPackController.Init(this, gameManager);
        }

        private void OnEnable() {
            gameManager.onGameManagerStart += Init;
        }

        private void Init() {
            direction = Vector3.right;
            travelDistance = 0;
            currentIndex = 0;

            movementDirection.Add(MovementDirection.Right);
            movementDirection.Add(MovementDirection.Down);
            movementDirection.Add(MovementDirection.Left);
            movementDirection.Add(MovementDirection.Down);

            enemyPackController.GenerateEnemies(transform);
        }

        private void Update() {
            //Debug.Log("isPlaying " + isPlaying);
            if (gameManager.isPlaying) {
                BoundaryCheck();
                DownTravelCheck();
                DirectionUpdate();
                enemyPackController.MovePack(direction);
            } else {
                enemyPackController.Stop();
            }
        }

        private void DirectionUpdate() {
            switch(movementDirection[currentIndex]) {
                case MovementDirection.Right:
                    direction = Vector3.right;
                    break;
                case MovementDirection.Left:
                    direction = Vector3.left;
                    break;
                case MovementDirection.Down:
                    direction = Vector3.down;
                    break;
            }
        }

        private void DownTravelCheck() {
            if (movementDirection[currentIndex] == MovementDirection.Down) {
                travelDistance += enemyPackController.GetTravelDistance();
                //Debug.Log(travelDistance);
                if (travelDistance >= 1f) {
                    ChangeDirection();
                    travelDistance = 0;
                }
            }
        }

        private void ChangeDirection() {
            currentIndex++;
            if (currentIndex >= movementDirection.Count) {
                currentIndex = 0;
            }
        }

        private void BoundaryCheck() {
            foreach(Enemy enemy in enemyPackController.GetEnemies()) {
                if (movementDirection[currentIndex] == MovementDirection.Right && enemy.IsTouchingPoint(rightBoundary.position)) {
                    ChangeDirection();
                } else if (movementDirection[currentIndex] == MovementDirection.Left && enemy.IsTouchingPoint(leftBoundary.position)) {
                    ChangeDirection();
                }
            }
        }

        public Enemy CreateEnemy(EnemyData _enemy, Vector3 _position) {
            return Instantiate(_enemy.prefab, _position, transform.rotation).GetComponent<Enemy>();
        }
    } 
}
