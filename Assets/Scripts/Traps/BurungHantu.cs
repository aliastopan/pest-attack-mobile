using UnityEngine;

public class BurungHantu : Trap
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        bool isTikus = collision.gameObject.GetComponent<Enemy>() is Tikus;
        bool isTarget = isTikus;

        if(collision.gameObject.tag == "Enemy" && isTarget)
        {
            Targets.Add(collision.gameObject);
            if(Targets.Count == 1)
            {
                clock = new InternalClock(AttackCooldown);
                clock.CanBegin = true;
            }

        }
    }
}
