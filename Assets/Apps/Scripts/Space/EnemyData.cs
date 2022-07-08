using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvader {
    public enum EnemyType {
        Normal, Mistery
    }
    [CreateAssetMenu(fileName = "New Enemy", menuName = "Scriptable Object/Enemy")]
    public class EnemyData : ScriptableObject {
        public Sprite sprite;
        public GameObject prefab;
        public int rowCount;
        public int point;
        public EnemyType type;
    } 
}
