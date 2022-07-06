using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Space.Game {
    public abstract class Entity : MonoBehaviour {
        public int hp;
        public float speed;

        public event Action<int> onDamaged;
        public event Action onDestroyed;
        public Action<Vector3> onSetDirection;

        private void OnDestroy() {
            onDestroyed?.Invoke();
        }

        public void Damaged(int _damage) {
            hp = hp < _damage ? 0 : hp - _damage;
            onDamaged?.Invoke(_damage);
        }
    } 
}
