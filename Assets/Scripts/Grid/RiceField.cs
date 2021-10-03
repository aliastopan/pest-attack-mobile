using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiceField : MonoBehaviour
{
    public int EnemyCounter;

    private void Update() 
    {
        Debug.LogWarning($"Enemy {EnemyCounter}/{GameData.MAX_ENEMY_SPAWN[GameData.SELECTED_STAGE]}");    
    }
    private void OnTriggerEnter(Collider collision) 
    {
        if(collision.gameObject.tag == "Enemy")
            EnemyCounter++;
    }
}
