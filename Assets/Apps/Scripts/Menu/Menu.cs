using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace SpaceInvader.Menu {
    public class Menu : MonoBehaviour {
        private DataController dataManager;

        private void Awake() {
            dataManager = FindObjectOfType<DataController>();
        }

        private void Start() {
            dataManager.Load();
        }
    }
}