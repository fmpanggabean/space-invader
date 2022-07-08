using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvader.Game {
    public class Enemy : Entity {
        private EnemyData enemyData;


        private void Awake() {
            targets = new List<Type>();
            targets.Add(typeof(Player));
            targets.Add(typeof(Barrier));
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

        public void SetEnemyData(EnemyData _enemyData) {
            enemyData = _enemyData;
        }

        public bool IsTouchingPoint (Vector3 _point) {
            //Debug.Log(transform.position.x - _point.x);
            if (GetRange(transform.position.x, _point.x) < 0.1f) {
                return true;
            }
            return false;
        }

        private float GetRange(float x1, float x2) {
            return Mathf.Abs(x1 - x2);
        }

        internal int GetEnemyScore() {
            return enemyData.point;
        }
    }
}