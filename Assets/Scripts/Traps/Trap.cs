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
    public TrapType TrapType;
    public float Cost = 50f;
    public float HealthPoint = 100f;
    public float AttackPoint = 100f;
    public float AttackCooldown = 2f;
    public float DebuffSpeed = 0.25f;

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
