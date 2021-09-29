using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TrapType
{
  Shooter,
  Offense,
  Defense
}

public class Trap : MonoBehaviour
{
    public TrapStats TrapStats;
    public TrapType TrapType;
    

    public float Cost; // = 50f;
    public float HealthPoint; // = 100f;
    public float AttackPoint; // = 100f;
    public float AttackCooldown; // = 2f;
    public float DebuffSpeed; // = 0.25f;

    private void Start() 
    {
        int rank = GameData.TrapRank[(int) TrapType];
        Debug.Log($"{this.gameObject.name} rank: {rank}, available rank: {TrapStats.StatsByRank.Count}");

        if(TrapStats != null && TrapStats.StatsByRank.Count > 0)
        {
            HealthPoint = TrapStats.StatsByRank[rank-1].HealthPoint;
        } 


        /*
        if(this.gameObject.tag == "Trap")
        {
            Debug.Log($"TRAP LOGGED");
        }
        
        if(TrapStats.StatsByRank.Count > 0)
        {
            Cost = TrapStats.StatsByRank[rank].Cost;
            HealthPoint = TrapStats.StatsByRank[rank].HealthPoint;
            AttackPoint = TrapStats.StatsByRank[rank].AttackCooldown;
            AttackCooldown = TrapStats.StatsByRank[rank].AttackCooldown;
            DebuffSpeed = TrapStats.StatsByRank[rank].DebuffSpeed;
        } 
        
        */

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(Defense(collision));
    }

    IEnumerator Defense(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Under Attack....");
            yield return new WaitForSeconds(AttackCooldown);
        }   
    }
}
