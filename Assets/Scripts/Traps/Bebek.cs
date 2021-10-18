using UnityEngine;

public class Bebek : Trap
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        bool isKeongMas = collision.gameObject.GetComponent<Enemy>() is KeongMas;
        bool isTarget = isKeongMas;

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
