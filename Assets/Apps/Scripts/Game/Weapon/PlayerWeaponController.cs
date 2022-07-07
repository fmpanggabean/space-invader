using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Space.Game {
    public class PlayerWeaponController : WeaponController {


        private void Update() {
            if (Input.GetKeyDown(KeyCode.Space)) {
                ShootAllWeapon();
            }
        }
    }

}