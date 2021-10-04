using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiceField : MonoBehaviour
{
    public int EnemyCounter;

    private void Update() 
    {
        Debug.LogWarning($"Enemy {EnemyCounter}/{GameData.MAX_ENEMY_SPAWN[GameData.SELECTED_STAGE]}");  
        if(EnemyCounter == GameData.MAX_ENEMY_SPAWN[GameData.SELECTED_STAGE])
        {
            Debug.LogWarning($"GAME OVER");
        }  
    }
    private void OnTriggerEnter2D(Collider2D collision) 
    {    
        Debug.LogWarning($"Hit");
        if(collision.gameObject.tag == "Enemy")
            EnemyCounter++;
    }

}
