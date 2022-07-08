using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace SpaceInvader.Game {
    public class BulletManager : MonoBehaviour {
        public GameObject prefab;

        private List<Bullet> collection;

        private void Awake() {
            collection = new List<Bullet>();
        }

        private void Start() {
            for (int i=0; i<100; i++) {
                collection.Add(Instantiate(prefab, transform).GetComponent<Bullet>());
                collection[i].Hide();
            }
        }

        public void Request(Transform _transform, float _maxTravelDistance, Type _type) {
            foreach (Bullet b in collection) {
                if (!b.IsActive()) {
                    b.Activate(_transform, _maxTravelDistance, _type);
                    return;
                }
            }
        }
    } 
}
