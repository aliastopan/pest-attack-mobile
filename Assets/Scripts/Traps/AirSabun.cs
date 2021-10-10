using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirSabun : Trap
{
    public GameObject Projectile;
    public float ProjectileDamage;

    public override void Start() 
    {
        base.Start();
        ProjectileDamage = AttackPoint;
        AttackPoint = 0;

        clock = new InternalClock(AttackCooldown);
        clock.CanBegin = true;
    }

    public override void Update()
    {
        //base.Update();
        Battle();
        base.OnDead();
    }

    public override void Battle()
    {
        clock.tLapseRepeat();
        if (clock.t == 0)
        {
            GameObject projectile = Instantiate(Projectile, this.gameObject.transform);
            projectile.GetComponent<Projectile>().AttackPoint = ProjectileDamage;
            
        }

    }
}
