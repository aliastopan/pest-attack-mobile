using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float TravelSpeed = 3f;
    public TrapStats TrapStats;
    public float AttackPoint;

    private void Start() 
    {
        int rank = GameData.TrapRank[(int) CardType.AirSabun];
        
        if(TrapStats != null && TrapStats.StatsByRank.Count > 0)
        {
            
        }
        /*
        if(TrapStats != null && TrapStats.StatsByRank.Count > 0)
        {
            Cost = TrapStats.StatsByRank[rank-1].Cost;
            HealthPoint = TrapStats.StatsByRank[rank-1].HealthPoint;
            AttackPoint = TrapStats.StatsByRank[rank-1].AttackPoint;
            AttackCooldown = TrapStats.StatsByRank[rank-1].AttackCooldown;
            DebuffSpeed = TrapStats.StatsByRank[rank-1].DebuffSpeed;
        }
        */
    }

    private void Update() 
    {
        transform.Translate(Vector3.right * TravelSpeed * Time.deltaTime);
    }



}
