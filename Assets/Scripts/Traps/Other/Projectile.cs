using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float TravelSpeed = 3f;
    public float AttackPoint;

    private void Start() 
    {
  
    }

    private void Update() 
    {
        transform.Translate(Vector3.right * TravelSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        bool isWalangSangit = collision.gameObject.GetComponent<Enemy>() is WalangSangit;
        bool isUlat = collision.gameObject.GetComponent<Enemy>() is Ulat; 
        bool isTarget = isWalangSangit || isUlat;

        if(collision.gameObject.tag == "Enemy" && isTarget)
        {
            //WDebug.LogWarning($"Hit {AttackPoint}");
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();

            Debug.Log($"HP: {enemy.HealthPoint}");
            enemy.HealthPoint -= AttackPoint;
            enemy.BeingDamaged();
            Debug.Log($"hit HP: {enemy.GetType()} {enemy.HealthPoint}");

      
        }
    }



}
