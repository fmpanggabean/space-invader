using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

namespace SpaceInvader.Game {
    public class WeaponController : MonoBehaviour {
        private Entity entity;
        private List<Weapon> weapons;

        protected void Awake() {
            entity = GetComponent<Entity>();
            weapons = GetComponentsInChildren<Weapon>().ToList<Weapon>();
        }

        public void ShootAllWeapon() {
            foreach(Weapon w in weapons) {
                w.Shoot(entity);
            }
        }
    } 
}
