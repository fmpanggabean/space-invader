using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Space.Game {
    public enum MovementDirection {
        Right, Down, Left
    }

    public class EnemyManager : MonoBehaviour, IManager {
        private GameManager gameManager;

        private bool isPlaying;
        private List<MovementDirection> movementDirection;
        private int currentIndex;
        private Vector3 direction;
        private float travelDistance;

        [SerializeField]
        private EnemyPackController enemyPackController;

        public Transform leftBoundary;
        public Transform rightBoundary;

        public event Action onEnemyGenerated;

        private void Awake() {
            gameManager = FindObjectOfType<GameManager>() as GameManager;

            movementDirection = new List<MovementDirection>();
            enemyPackController = new EnemyPackController();
        }

        private void Start() {
            isPlaying = false;
            direction = Vector3.right;
            travelDistance = 0;
        }

        private void OnEnable() {
            gameManager.onGameStart += StartGame;
        }

        private void Init() {
            movementDirection.Add(MovementDirection.Right);
            movementDirection.Add(MovementDirection.Down);
            movementDirection.Add(MovementDirection.Left);
            movementDirection.Add(MovementDirection.Down);
            currentIndex = 0;

            GenerateEnemies();
        }

        private void Update() {
            if (isPlaying) {
                BoundaryCheck();
                DownTravelCheck();
                DirectionUpdate();
                MoveEnemy();
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
                travelDistance += GetOneEnemy().GetMovement().PositionOffset().magnitude;

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

        private Enemy GetOneEnemy() {
            foreach(Enemy e in enemies) {
                return e;
            }
            return null;
        }

        private void BoundaryCheck() {
            foreach(Enemy entity in enemies) {
                if (movementDirection[currentIndex] == MovementDirection.Right && entity.IsTouchingBoundary(rightBoundary.position)) {
                    ChangeDirection();
                } else if (movementDirection[currentIndex] == MovementDirection.Left && entity.IsTouchingBoundary(leftBoundary.position)) {
                    ChangeDirection();
                }
            }
        }

        public void StartGame() {
            Init();

            isPlaying = true;
        }

        private void MoveEnemy() {
            foreach(Enemy entity in enemies) {
                entity.SetDirection(direction);
            }
        }

        private void GenerateEnemies() {
            Vector3 anchor = transform.position - new Vector3((float)(enemyPerRow-1) / 2, 0, 0);

            foreach(EnemyData enemy in enemyPrefab) {
                for (int row=0; row<enemy.rowCount; row++) {
                    for (int col=0; col<enemyPerRow; col++) {
                        Vector3 position = anchor;
                        position.x += col;

                        Enemy e = Instantiate(enemy.prefab, position, transform.rotation).GetComponent<Enemy>();
                        //e.onDestroyed += RemoveFromList;
                        enemies.Add(e);

                        //go.GetComponent<Weapon>().SetBulletManager(bulletManager);
                    }
                    anchor.y -= 1;
                }
            }

            onEnemyGenerated?.Invoke();
        }

        private void RemoveFromList(EnemyToChanged e) {
            enemies.Remove(e);
        }
    } 
}
