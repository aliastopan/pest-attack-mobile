using UnityEngine;

public class Hostile : MonoBehaviour 
{
    public float HealthPoint = 100f;
    public float AttackPoint = 100f;
    public float AttackCooldown = 2f;
    //public int SpawnStageFactor = 1;
    public float MovementSpeed = 25f;
    public float SpeedFactor = 1f;
    public bool IsBattle = false;
    public GameObject Target;
    protected Trap trap;
    protected InternalClock clock;

    [Header("Debug")]
    public float TimeDebug;
    public virtual void Update()
    {
        Battle();
        OnDead();
    }

    private void OnDead()
    {
        if (HealthPoint <= 0)
        {
            Debug.Log($"{this.gameObject.name} is DEAD.");
            this.gameObject.GetComponent<Collider2D>().enabled = false;
            Destroy(this.gameObject);
        }
    }

    private void Battle()
    {
        if (Target == null)
        {
            clock = null;
            Target = null;
        }

        if (clock != null)
        {
            clock.tLapseRepeat();
            TimeDebug = clock.t;
            if (clock.t == 0)
            {
                try
                {
                    Trap targetTrap = Target.GetComponent<Trap>();
                    targetTrap.HealthPoint -= AttackPoint;
                }
                catch (System.Exception log)
                {
                    Debug.Log($"{log}");                        
                }
                
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
            //Targets.Remove(collision.gameObject);
            //Debug.Log("Exit");
        }
    }
}