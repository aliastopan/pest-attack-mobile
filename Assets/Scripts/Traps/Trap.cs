using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [HideInInspector] public int Cost; // = 50f;
    [HideInInspector] public float HealthPoint; // = 100f;
    [HideInInspector] public float AttackPoint; // = 100f;
    [HideInInspector] public float AttackCooldown; // = 2f;
    [HideInInspector] public float DebuffSpeed; // = 0.25f;
    public List<GameObject> Targets = new List<GameObject>(); 
    protected InternalClock clock;

    private Image baseImage;
    private Color defaultColor;
    private Color hitColor = Color.yellow;
    private Sequencer hitSequence;
    private AnimationCurve curve;



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

        baseImage = this.gameObject.GetComponent<Image>();
        defaultColor =  baseImage.color;;    
        hitSequence = new Sequencer(0.5f);
        curve = ObjectMaster.Instance.BounceCurve;
    }

    public virtual void Update()
    {
        Battle();
        OnDead();

        hitSequence.tLapseOnce();
        //Debug.Log($"HitSeq: {hitSequence.tValue()}");

        Color lerpColor = Color.Lerp(
            defaultColor,
            hitColor,
            curve.Evaluate(hitSequence.tValue())
        );

        baseImage.color = lerpColor;
    }

    public void BeingDamaged()
    {
        Debug.LogWarning($"Damage Sequence.");
        hitSequence.tReset();
        hitSequence.Start();
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
                        targetEnemy.BeingDamaged();
                    }
                    catch (System.Exception log)
                    {
                        Debug.Log($"{log}");                        
                    }
                }
            }
        }
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
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

    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
       if(collision.gameObject.tag == "Enemy")
        {
            Targets.Remove(collision.gameObject);
        }
    }



}
