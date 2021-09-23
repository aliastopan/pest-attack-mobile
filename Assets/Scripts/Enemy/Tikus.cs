using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tikus : Enemy
{
  private void Update()
  {
    Move();
  }

  public override void Move()
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



}
