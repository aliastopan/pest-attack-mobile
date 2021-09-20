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
        StartCoroutine(EnemySpawn());
        
    }

    IEnumerator EnemySpawn()
    {
      while(spawnCounter < GameData.MAX_ENEMY[PlayerData.SelectedStage - 1])
      {
        yield return new WaitForSeconds(SpawnTimeFactor);

          int rngEnemies = new System.Random().Next(1, PlayerData.SelectedStage);
          int rngSpawnPoint = new System.Random().Next(0, 4);

          //Debug.Log($"Spawn: {rngSpawn}, Enemy Number: {spawnCounter + 1}");
          GameObject enemyInstance = Instantiate(Enemies[rngEnemies-1], RootSpawn.transform.GetChild(rngSpawnPoint).transform);

          spawnCounter++;
      }
    }

}
