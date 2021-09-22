using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debugger : MonoBehaviour
{
    private void Update()
    {
       //Debug.Log($"Available Grid: {PlayerData.AvailableGrids}");
        Debug.Log($"Rank {GameData.TrapRank[0]}, {GameData.TrapRank[1]}, {GameData.TrapRank[2]}");
    }

}
