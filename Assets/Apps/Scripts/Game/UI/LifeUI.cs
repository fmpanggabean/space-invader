using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace SpaceInvader.Game.UI {
    public class LifeUI : BaseUI {
        public TMP_Text lifeText;
        public List<Image> images;


        public void ShowLife(int _life) {
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
