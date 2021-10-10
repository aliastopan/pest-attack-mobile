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
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.LogWarning($"Hit");
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.HealthPoint -= AttackPoint;
        }
    }



}
