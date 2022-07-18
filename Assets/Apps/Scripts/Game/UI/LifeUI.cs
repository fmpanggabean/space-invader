using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace SpaceInvader.Game.UI {
    public class LifeUI : BaseUI {
        public TMP_Text lifeText;
        public List<Image> images;


        private void Start() {
            gameManager.OnLifeReduced += ShowLife;
        }
        public void ShowLife(Life life) {
            int _life = life.value;
            lifeText.text = _life.ToString();
            
            for (int i=0; i<3; i++) {
                if (i < _life)
                    images[i].gameObject.SetActive(true);
                else
                    images[i].gameObject.SetActive(false);
            }
        }
    } 
}
