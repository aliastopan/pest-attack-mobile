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
    public CardType CardType;
    public float Cost; // = 50f;
    public float HealthPoint; // = 100f;
    public float AttackPoint; // = 100f;
    public float AttackCooldown; // = 2f;
    public float DebuffSpeed; // = 0.25f;
    public List<GameObject> Targets = new List<GameObject>(); 
    private InternalClock clock;

    [Header("Debug")]
    public float TimeDebug;

    public virtual void Start() 
    {
        int rank = GameData.TrapRank[(int) CardType];

        if(TrapStats != null && TrapStats.StatsByRank.Count > 0)
        {
            Cost = TrapStats.StatsByRank[rank-1].Cost;
            HealthPoint = TrapStats.StatsByRank[rank-1].HealthPoint;
            AttackPoint = TrapStats.StatsByRank[rank-1].AttackPoint;
            AttackCooldown = TrapStats.StatsByRank[rank-1].AttackCooldown;
            DebuffSpeed = TrapStats.StatsByRank[rank-1].DebuffSpeed;
        }
    }

    public virtual void Update()
    {
        Battle();
        OnDead();
    }

    public virtual void OnDead()
    {
        if (HealthPoint <= 0)
        {
            Debug.Log($"{this.gameObject.name} is DEAD.");
            this.gameObject.GetComponent<Collider2D>().enabled = false;
            Destroy(this.gameObject);
        }
    }

    public virtual void Battle()
    {
        if(Targets.Count == 0)
            clock = null;

        if(clock != null)
        {
            clock.tLapseRepeat();
            TimeDebug = (float) System.Math.Round(clock.t, 2);
            if (clock.t == 0)
            {
                foreach (GameObject target in Targets)
                {
                    try
                    {
                        Enemy targetEnemy = target.GetComponent<Enemy>();
                        targetEnemy.HealthPoint -= AttackPoint;
                    }
                    catch (System.Exception log)
                    {
                        Debug.Log($"{log}");                        
                    }
                }
            }
        }
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
        }
    }



}
