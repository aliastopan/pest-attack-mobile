using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TrapStats", menuName = "pest-attack-mobile/TrapStats", order = 0)]
public class TrapStats : ScriptableObject 
{
    [System.Serializable]
    public class Stats
    {
        public float Cost = 50f;
        public float HealthPoint = 100f;
        public float AttackPoint = 100f;
        public float AttackCooldown = 2f;
        public float DebuffSpeed = 0.25f;
        public int UpgradeCost = 35;
    }
    public List<Stats> StatsByRank = new List<Stats>();
}