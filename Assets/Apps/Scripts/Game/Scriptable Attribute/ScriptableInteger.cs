using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvader {
    [CreateAssetMenu(fileName = "New Scriptable Integer", menuName = "Scriptable Attribute/Integer")]
    public class ScriptableInteger : ScriptableObject {
        public int value;
    } 
}
