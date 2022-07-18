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
        private List<EntityType> targetTypes;

        public override EntityType EntityType { get; }

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
            
            if (IsTypeInTargetList(collidedObject.EntityType)) {
                collidedObject.Damaged(damage);
                Hide();
            }
        }

        private bool IsTypeInTargetList(EntityType entityType) {
            if (targetTypes.Contains(entityType)) {
                return true;
            }
            return false;
        }

        public void Activate(Transform _transform, float _maxTravelDistance, Entity _entity) {
            Show();

            targetTypes = _entity.targets;
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
