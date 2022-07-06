using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Space.Game {
    public class Weapon : MonoBehaviour {
        private BulletManager bulletManager;

        public float delay;
        public float bulletDistance;

        private void Awake() {
            bulletManager = FindObjectOfType<BulletManager>() as BulletManager;
        }

        public void Shoot(Type _type) {
            bulletManager.Request(transform, bulletDistance, _type);
        }
    } 
}
