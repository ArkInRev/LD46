using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Difficulty", menuName = "ScriptableObjects/Difficulty", order =1)]
public class DifficultySettings : ScriptableObject
{

        public string diffName; //name for the difficulty
        public float pHealthMult; //player health multiplier
        public float tHealthMult; //turret health multiplier
        public float eHealthMult; //enemy health multiplier
        public float lHealthMult; //larva health multiplier
        public float pDamageMult; //player damage multiplier
        public float eDamageMult; //enemy damage multiplier
        public float lStartSeqMult; // larva starting sequence multiplier
        public float lDecaySeqMult; // larva sequencing decay multiplier
        public float eGainMult; // energy gain multiplier
        public float hGainMult; // health gain multiplier
        public float sGainMult; //sequencing gain Multiplier
        public float eShootFreqMult; //enemy shooting frequency Multiplier (higher is less frequent shots)

}
