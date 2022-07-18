using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace SpaceInvader.Game {
    public class Barrier : Entity {
        public override EntityType EntityType => EntityType.Barrier;

        private void Awake() {
            targets = new List<EntityType>();
        }
        private void Start() {
            health.value = 3;
        }
        private void OnEnable() {
            onDead += Destroy;
        }
        private void OnDisable() {
            onDead -= Destroy;
        }

        private void Destroy(Entity _entity) {
            Destroy(gameObject);
        }

    }
}