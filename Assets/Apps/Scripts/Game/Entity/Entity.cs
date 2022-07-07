using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Space.Game {
    public abstract class Entity : MonoBehaviour {
        public int hp;
        public float speed;
        public Vector3 deltaPosition;

        public event Action<int> onDamaged;
        public event Action<Entity> onDead;
        public Action<Vector3> onSetDirection;


        private void LifeCheck() {
            if (hp == 0) {
                onDead?.Invoke(this);
            }
        }

        public void Damaged(int _damage) {
            hp = hp < _damage ? 0 : hp - _damage;
            onDamaged?.Invoke(_damage);

            LifeCheck();
        }

        public void SetDeltaPosition (Vector3 _newPosition) {
            deltaPosition = _newPosition - transform.position;
        }
    } 
}
