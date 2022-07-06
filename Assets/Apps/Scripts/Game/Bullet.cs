using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Space.Game {
    public class Bullet : Entity {
        private Movement movement;

        private float maxTravelDistance;
        private float travelDistance;

        private void Awake() {
            movement = GetComponent<Movement>();
        }

        private void Update() {
            travelDistance += movement.PositionOffset().magnitude;

            if (travelDistance >= maxTravelDistance) {
                Hide();
            }
        }

        private void OnTriggerEnter2D(Collider2D collision) {
            Destroy(collision.gameObject);
            Hide();
        }

        public void Activate(Transform _transform, float _maxTravelDistance, Type _type) {
            Show();
            travelDistance = 0;
            transform.position = _transform.position;
            transform.rotation = _transform.rotation;
            maxTravelDistance = _maxTravelDistance;
            Debug.Log("Activate");
            movement.SetDirection(transform.up);
        }

        internal void Hide() {
            gameObject.SetActive(false);
        }
        internal void Show() {
            gameObject.SetActive(true);
        }

        internal bool IsActive() {
            return gameObject.activeSelf;
        }
    }
}
