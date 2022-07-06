using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Space.Game {
    [RequireComponent(typeof(Entity))]
    public class Movement : MonoBehaviour {
        private Entity entity;

        private Vector3 direction;
        private float speed;

        private void Awake() {
            entity = GetComponent<Entity>();
        }

        private void Start() {
            speed = entity.speed;
        }

        protected void Update() {
            transform.position = GetNextPosition();
        }

        private void OnEnable() {
            entity.onSetDirection += SetDirection;
        }

        private void OnDisable() {
            entity.onSetDirection -= SetDirection;
        }

        private Vector3 GetNextPosition() {
            return transform.position + PositionOffset();
        }

        public Vector3 PositionOffset() {
            return direction * Time.deltaTime * speed;
        }

        public void SetDirection(Vector3 _direction) {
            direction = _direction;
        }
    } 
}
