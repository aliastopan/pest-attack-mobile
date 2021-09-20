using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rice : MonoBehaviour
{

  public float HealthPoint = 50f;
  public float AttackPoint = 25f;

  public void OnDamaged(float damagePoint)
  {
    if(HealthPoint - damagePoint <= 0)
      Destroy(this.gameObject);
    else
      HealthPoint -= damagePoint;
      //Debug.Log($"Rice Defense was Hit!!!");

  }

  public void OnDestroy()
  {
    Destroy(this.gameObject);
  }
}
