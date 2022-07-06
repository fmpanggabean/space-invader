using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Space.Game {
    public class AutoShootWeapon : Weapon {
        private void Start() {
            //StartCoroutine(AutoShoot());
        }

        //private IEnumerator AutoShoot() {
        //    while (true) {
        //        yield return new WaitForSeconds(GetRandomDelay());
        //        //Shoot();
        //    }
        //}

        //private float GetRandomDelay() {
        //    return UnityEngine.Random.Range(delay - 20, delay + 20);
        //}
    }
}