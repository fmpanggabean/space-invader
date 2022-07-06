using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Space.Menu {
    public class MenuManager : MonoBehaviour, IManager {
        public List<BaseMenu> menus;
        public List<EnemyData> enemies;

        private void Start() {
            menus = FindObjectsOfType<BaseMenu>().ToList<BaseMenu>();

            GetMenu<ScoreTableUI>().GenerateList(enemies);
        }

        public T GetMenu<T> () where T : BaseMenu {
            foreach(BaseMenu menu in menus) {
                if (menu.GetType() == typeof(T)) {
                    return (T)menu;
                }
            }
            return null;
        }
    }
}