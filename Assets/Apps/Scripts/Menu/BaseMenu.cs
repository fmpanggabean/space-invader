using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvader.Menu {
    public abstract class BaseMenu : MonoBehaviour {

        public void Hide() {
            gameObject.SetActive(false);
        }

        public void Show() {
            gameObject.SetActive(true);
        }
    } 
}
