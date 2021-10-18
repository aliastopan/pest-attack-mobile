using UnityEngine;

public class BungaMatahari : Trap
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        bool isBurungPipit = collision.gameObject.GetComponent<Enemy>() is BurungPipit;
        bool isTarget = isBurungPipit;

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
