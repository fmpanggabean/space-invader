using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Space.Game {
    public class EnemyToChanged : MonoBehaviour {
        private Movement movement;

        public event Action<EnemyToChanged> onDestroyed;

        private void Awake() {
            movement = GetComponent<Movement>();
        }

        private void OnDestroy() {
            onDestroyed?.Invoke(this);
        }

        internal void SetDirection(Vector3 _direction) {
            //Debug.Log(_direction);
            movement.SetDirection(_direction);
        }

        internal bool IsTouchingBoundary(Vector3 _boundary) {
            if (Range(_boundary.x, transform.position.x) < 0.1f) {
                return true;
            }
            return false;
        }
        public Movement GetMovement() {
            return movement;
        }
        private float Range(float x1, float x2) {
            return Mathf.Abs(x1 - x2);
        }
    } 
}
