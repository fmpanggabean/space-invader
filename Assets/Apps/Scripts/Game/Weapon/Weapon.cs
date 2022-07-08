using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace SpaceInvader.Game {
    public class Weapon : MonoBehaviour {
        private BulletManager bulletManager;
        private WeaponController weaponController;

        //public float delay;
        public float bulletDistance;

        private void Awake() {
            bulletManager = FindObjectOfType<BulletManager>() as BulletManager;
            weaponController = GetComponentInParent<WeaponController>();
        }

        public void Shoot(Type _type) {
            bulletManager.Request(transform, bulletDistance, _type);
            //Debug.Log(transform.rotation.eulerAngles);
        }
    } 
}
