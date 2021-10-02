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
    public List<GameObject> Targets = new List<GameObject>(); 

    private InternalClock clock;

    [Header("Debug")]
    public float TimeDebug;

    private void Start() 
    {
        int rank = GameData.TrapRank[(int) TrapType];

        if(TrapStats != null && TrapStats.StatsByRank.Count > 0)
        {
            Cost = TrapStats.StatsByRank[rank-1].Cost;
            HealthPoint = TrapStats.StatsByRank[rank-1].HealthPoint;
            AttackPoint = TrapStats.StatsByRank[rank-1].AttackPoint;
            AttackCooldown = TrapStats.StatsByRank[rank-1].AttackCooldown;
            DebuffSpeed = TrapStats.StatsByRank[rank-1].DebuffSpeed;
        }

        Debug.Log($"{this.gameObject.name} rank: {rank}, available rank: {TrapStats.StatsByRank.Count}");
        Debug.Log($"COST: {Cost}");
        Debug.Log($"ATK: {AttackPoint}");
        Debug.Log($"HP: {HealthPoint}");
        Debug.Log($"CD: {AttackCooldown}");
        Debug.Log($"DEBUFF: {DebuffSpeed}");



    }

    private void Update() 
    {
        
    
        if(Targets.Count == 0)
            clock = null;
        
        if(clock != null)
        {
            clock.tLapseRepeat();
            TimeDebug = clock.t;
            if(clock.t == 0)
            {
                Debug.LogWarning($"[{this.gameObject.name}] Attacking {clock.t}");
                foreach (GameObject target in Targets)
                {
                    Enemy targetEnemy = target.GetComponent<Enemy>();
                    targetEnemy.HealthPoint -= AttackPoint;
                }
            }
        }

        //Targets.Remove( gameObject.GetComponent<Enemy>().HealthPoint <= 0);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Targets.Add(collision.gameObject);
            if(Targets.Count == 1)
            {
                clock = new InternalClock(AttackCooldown);
                clock.CanBegin = true;
                //Debug.Log("Create Clock");
            }

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       if(collision.gameObject.tag == "Enemy")
        {
            Targets.Remove(collision.gameObject);
            Debug.Log("Exit");
        }
    }









    IEnumerator Defense(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            // Debug.Log("Under Attack....");
            yield return new WaitForSeconds(AttackCooldown);
        }   
    }

    public void OnDamaged(float damagePoint)
    {
        if(HealthPoint - damagePoint <= 0)
            Destroy(this.gameObject);
        else
        HealthPoint -= damagePoint;
    }
}
