using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvader.Game {
    public class Bullet : Entity {
        public int damage = 1;
        
        private Movement movement;

        private float maxTravelDistance;
        private float travelDistance;
        private Type type;

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
            Entity collidedObject = collision.GetComponent<Entity>();

            if (!IsSameType(collidedObject.GetType())) {
                collidedObject.Damaged(damage);
                Hide();
            }
        }

        private bool IsSameType(Type _type) {
            if (type == _type) {
                return true;
            }
            return false;
        }

        public void Activate(Transform _transform, float _maxTravelDistance, Type _type) {
            Show();

            type = _type;
            transform.position = _transform.position;
            transform.rotation = _transform.rotation;
            maxTravelDistance = _maxTravelDistance;
            travelDistance = 0;
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
