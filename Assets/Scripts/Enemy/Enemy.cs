using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
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

    public virtual void Start() 
    {
      
    }

    public virtual void Update() 
    {
      if(HealthPoint <= 0)
      {
        Debug.Log($"{this.gameObject.name} is DEAD.");
        this.gameObject.GetComponent<Collider2D>().enabled = false;
        Destroy(this.gameObject);
      }  
    }

    public void EnemyBehaviour()
    {
      if(Target != null)
      {
          Target.GetComponent<Trap>().OnDamaged(AttackPoint);
          duration += Time.deltaTime;
      }
    }

    public virtual void Move()
    {
        if (Target == null)
        {
          transform.Translate(Vector3.left * MovementSpeed * Time.deltaTime);
        }
      else
      {
        try{
          trap = Target.GetComponent<Trap>();
          transform.Translate(Vector3.left * (MovementSpeed - (MovementSpeed * trap.TrapStats.StatsByRank[0].DebuffSpeed)) * Time.deltaTime);

          //Debug.Log($"Speed: {MovementSpeed - (MovementSpeed * trap.DebuffSpeed)}");
          if (trap == null)
            return;

        }catch(System.Exception e){
          Debug.LogWarning(e);
        }
      }
    } 

  public void Battle()
  {
    trap = Target.GetComponent<Trap>();
    int trapType = (int) trap.TrapType; 
    float speed = MovementSpeed - (MovementSpeed * trap.TrapStats.StatsByRank[trapType].DebuffSpeed);
    transform.Translate(Vector3.left * speed * Time.deltaTime);

    Debug.Log($"Speed: {MovementSpeed - (MovementSpeed * trap.DebuffSpeed)}");
    if (trap == null)
      return;

  }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      bool isTarget = collision.gameObject.CompareTag("Padi") || collision.gameObject.CompareTag("Trap");
      if(isTarget)
      {
        Target = collision.gameObject;
        clock = new InternalClock(Target.GetComponent<Trap>().AttackCooldown);
      }
    }

    private void OnTriggerStay2D(Collider2D collider) 
    {
      if(Target != null)
      try{
          //StartCoroutine(Attack(collider));  
      }
      catch (System.Exception log){
          Debug.LogWarning(log);
      }
      
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
      bool isTarget = collision.gameObject.CompareTag("Padi") || collision.gameObject.CompareTag("Trap");
      if(isTarget)
      {
        Target = null;
        trap = null;
        duration = 0f;
        //Debug.Log($"Exit");
      }
    }

  float duration = 0f;

  IEnumerator Attack(Collider2D collision)
  {
    if(collision.gameObject.CompareTag("Padi") && Target != null)
    {
      if(collision != null)
      {
        Target = collision.gameObject;
        yield return new WaitForSeconds(AttackCooldown);
        try{
          Target.GetComponent<Rice>().OnDamaged(AttackPoint);
          duration += Time.deltaTime;
        }
        catch (System.Exception log){
          Debug.Log($"Target Destroyed: {log}");
        }
      }
  
    }

    
    if(collision.gameObject.CompareTag("Trap") && Target != null)
    {
      Target = collision.gameObject;
      yield return new WaitForSeconds(AttackCooldown);
      try{
        Target.GetComponent<Trap>().OnDamaged(AttackPoint);
        duration += Time.deltaTime;
      }
      catch (System.Exception log){
        Debug.Log($"Target Destroyed: {log}");
      }
    }
    

  }


}
