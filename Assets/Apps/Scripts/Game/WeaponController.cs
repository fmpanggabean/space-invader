using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

namespace Space.Game {
    public class WeaponController : MonoBehaviour {
        private Entity entity;
        private List<Weapon> weapons;

        private void Awake() {
            entity = GetComponent<Entity>();
            weapons = GetComponentsInChildren<Weapon>().ToList<Weapon>();
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Space)) {
                Shoot();
            }
        }

        private void Shoot() {
            foreach(Weapon w in weapons) {
                w.Shoot(entity.GetType());
            }
        }
    } 
}
