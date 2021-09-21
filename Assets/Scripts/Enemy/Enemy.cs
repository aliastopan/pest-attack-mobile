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
    private Trap trap;
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
        transform.Translate(Vector3.left * (MovementSpeed - (MovementSpeed * trap.DebuffSpeed)) * Time.deltaTime);

        Debug.Log($"Speed: {MovementSpeed - (MovementSpeed * trap.DebuffSpeed)}");

      }catch(System.Exception e){
        Debug.LogWarning(e);
      }
    }
  }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(Attack(collision));
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        Target = null;
        trap = null;
    }

  IEnumerator Attack(Collider2D collision)
  {
    if(collision.gameObject.CompareTag("Padi"))
    {
      //Debug.Log("Attacking Padi....");

      Target = collision.gameObject;
      yield return new WaitForSeconds(AttackCooldown);
      collision.gameObject.GetComponent<Rice>().OnDamaged(AttackPoint);
    }

    if(collision.gameObject.CompareTag("Trap"))
    {
      Debug.Log("Attacking Trap....");

      Target = collision.gameObject;
      yield return new WaitForSeconds(AttackCooldown);
    }

  }


}
