using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvader.Game {
    public class EnemyWeaponController : WeaponController {
        [Range(0, 1)]
        public float chance;

        private GameManager gameManager;

        private void Start() {
            gameManager = FindObjectOfType<GameManager>();
            StartCoroutine(AutoShoot());
        }

        private IEnumerator AutoShoot() {
            while (true) {
                yield return new WaitForSeconds(1);
                if (GetChanceToShoot() && gameManager.isPlaying) {
                    ShootAllWeapon();
                }
            }
        }

        private bool GetChanceToShoot() {
            float value = UnityEngine.Random.Range(0f, 1f);
            if (value <= chance) {
                return true;
            }
            return false;
        }
    }
}