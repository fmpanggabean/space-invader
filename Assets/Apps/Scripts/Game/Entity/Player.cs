using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Space.Game {
    
    public class Player : Entity {
        private Vector3 inputDirection;

        private void Awake() {
            inputDirection = new Vector3();
        }

        private void Update() {
            InputHandler();
        }

        private void InputHandler() {
            //if (Input.GetKeyDown(KeyCode.Space)) {
            //    onShoot?.Invoke();
            //}

            inputDirection.x = Input.GetAxisRaw("Horizontal");
            onSetDirection?.Invoke(inputDirection);
        }
    }
}