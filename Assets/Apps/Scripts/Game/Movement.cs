using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvader.Game {
    [RequireComponent(typeof(Entity))]
    public class Movement : MonoBehaviour {
        private Entity entity;

        private Vector3 direction;
        private float speed;
        private Vector3 newPosition;

        public event Action<Vector3> onPositionUpdate;

        private void Awake() {
            entity = GetComponent<Entity>();
        }

        private void Start() {
            speed = entity.speed;
            newPosition = transform.position;
        }

        protected void Update() {
            onPositionUpdate?.Invoke(GetNextPosition());
        }

        private void PositionUpdate(Vector3 _newPosition) {
            transform.position = _newPosition;
        }

        private void OnEnable() {
            entity.onSetDirection += SetDirection;
            onPositionUpdate += entity.SetDeltaPosition;
            onPositionUpdate += PositionUpdate;
        }

        private void OnDisable() {
            entity.onSetDirection -= SetDirection;
            onPositionUpdate -= entity.SetDeltaPosition;
            onPositionUpdate -= PositionUpdate;
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
