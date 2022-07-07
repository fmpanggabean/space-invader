using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

namespace Space {
    public class DataManager : MonoBehaviour, IManager {
        public GameData data;
        private string path;

        public event Action<GameData> onDataLoaded;

        private void Awake() {
            path = Application.persistentDataPath + "/space-shooter.save";
        }

        private void Start() {
            Load();
        }

        public void Save() {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = new FileStream(path, FileMode.Create);

            bf.Serialize(file, data);

            file.Close();

            Debug.Log("Data Saved!");
            Debug.Log("highscore: " + data.highscore);
        }
        public void Load() {
            if (File.Exists(path)) {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = new FileStream(path, FileMode.Open);

                data = (GameData)bf.Deserialize(file);
                file.Close();

                onDataLoaded?.Invoke(data);

                Debug.Log("Data Loaded!");
                Debug.Log("highscore: " + data.highscore);
            }
        }
    }

}