using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float HealthPoint = 100f;
    public float AttackPoint = 100f;
    public float AttackCooldown = 2f;
    //public int SpawnStageFactor = 1;
    public float MovementSpeed = 25f;
    public float SpeedFactor = 1f;
    public bool IsBattle = false;
    //public List<GameObject> Targets = new List<GameObject>();
    
    public GameObject Target;
    protected Trap trap;
    protected InternalClock clock;

    [Header("Debug")]
    public float TimeDebug;
    private AnimationCurve curve;


    private Image baseImage;
    private Color defaultColor;
    private Color hitColor = Color.red;
    private Sequencer hitSequence;


    public virtual void Start() 
    {
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

        Color lerpColor = Color.Lerp(
            defaultColor,
            hitColor,
            curve.Evaluate(hitSequence.tValue())
        );

        baseImage.color = lerpColor;
        //Debug.LogWarning($"t Value = {hitSequence.tValue()}");
    }

    public void BeingDamaged()
    {
       //Debug.LogWarning($"Damage Sequence.");
       // hitSequence.tReset();
        hitSequence.Start();
    }

    private void OnDead()
    {
        if(HealthPoint <= 0)
        {
            Debug.Log($"{this.gameObject.name} is DEAD.");
            PlayerData.CurrentEnemyKilled++;
            this.gameObject.GetComponent<Collider2D>().enabled = false;
            Destroy(this.gameObject);
        }
    }

    private void Battle()
    {
        if(Target == null)
            clock = null;

        if(clock != null)
        {
            clock.tLapseRepeat();
            TimeDebug = (float) System.Math.Round(clock.t, 2);
            if (clock.t == 0)
            {
                //if(Target != null)
                //{
                    Trap targetTrap = Target.GetComponent<Trap>();
                    targetTrap.HealthPoint -= AttackPoint;
                    targetTrap.BeingDamaged();
                    Debug.LogWarning($"Battle");
                //}
            }
        }
    }

    public virtual void Move()
    {
        if (Target == null)
            transform.Translate(Vector3.left * MovementSpeed * Time.deltaTime);
        else
        {
            try{
                trap = Target.GetComponent<Trap>();
                transform.Translate(Vector3.left * (MovementSpeed - (MovementSpeed * trap.TrapStats.StatsByRank[0].DebuffSpeed)) * Time.deltaTime);

                if(trap == null)
                    return;

            }catch(System.Exception e){
                Debug.LogWarning(e);
            }
        }
    } 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Padi") || collision.gameObject.CompareTag("Trap"))
        {
            Target = collision.gameObject;
            if(Target != null)
            {
                clock = new InternalClock(AttackCooldown);
                clock.CanBegin = true;
            }

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Padi") || collision.gameObject.CompareTag("Trap"))
        {
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       if(collision.gameObject.CompareTag("Padi") || collision.gameObject.CompareTag("Trap"))
        {

        }
    }
}