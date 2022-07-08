using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace SpaceInvader.Menu {
    public class MenuManager : MonoBehaviour, IManager {
        private DataManager dataManager;

        public List<BaseMenu> menus;
        public List<EnemyData> enemies;

        private void Awake() {
            dataManager = FindObjectOfType<DataManager>();
        }

        private void Start() {
            menus = FindObjectsOfType<BaseMenu>().ToList<BaseMenu>();
            dataManager.Load();

            GetMenu<ScoreUI>().SetHighScore(dataManager.data.highscore);
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