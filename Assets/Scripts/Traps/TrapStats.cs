using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TrapStats", menuName = "pest-attack-mobile/TrapStats", order = 0)]
public class TrapStats : ScriptableObject 
{
    [System.Serializable]
    public class Stats
    {
        public int Cost;
        public float HealthPoint;
        public float AttackPoint;
        public float AttackCooldown;
        public float DebuffSpeed;
        public int UpgradeCost;
    }
    public List<Stats> StatsByRank = new List<Stats>();
}