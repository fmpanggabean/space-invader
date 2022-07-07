using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Space.Game.UI {
    public abstract class BaseUI : MonoBehaviour {
        
        public void Hide() {
            gameObject.SetActive(false);
        }

        public void Show() {
            gameObject.SetActive(true);
        }
    } 
}
