using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float SpawnTimeFactor = 3f;
    public GameObject RootSpawn;
    public List<GameObject> Enemies = new List<GameObject>();
    private int spawnCounter = 0;


    // Start is called before the first frame update
    void Start()
    {
        spawnCounter = GameData.MAX_ENEMY_SPAWN[GameData.SELECTED_STAGE];
        StartCoroutine(EnemySpawn());
        //Debug.Log($"Total Enemy: {spawnCounter}");
        
    }

    IEnumerator EnemySpawn()
    {
      while(spawnCounter < GameData.MAX_ENEMY_SPAWN[GameData.SELECTED_STAGE])
      {
        yield return new WaitForSeconds(SpawnTimeFactor);

          int rngEnemies = new System.Random().Next(0, GameData.SELECTED_STAGE);
          int rngSpawnPoint = new System.Random().Next(0, 4);

          //Debug.Log($"Spawn: {rngSpawn}, Enemy Number: {spawnCounter + 1}");
          GameObject enemyInstance = Instantiate(Enemies[rngEnemies], RootSpawn.transform.GetChild(rngSpawnPoint).transform);

          spawnCounter++;
      }
    }

}
