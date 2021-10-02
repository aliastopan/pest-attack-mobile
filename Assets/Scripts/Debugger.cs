using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debugger : MonoBehaviour
{
    private void Start() 
    {
        //SlotCheck();
    }

    private void SlotCheck()
    {
        for(int i = 0; i < ObjectMaster.Instance.DeckSlot.Length; i++)
            Debug.Log($"Slot {i}: {ObjectMaster.Instance.DeckSlot[i]}");

    }

    private void RankCheck()
    {
        //Debug.Log($"Rank {GameData.TrapRank[0]}, {GameData.TrapRank[1]}, {GameData.TrapRank[2]}, " +
        //    $"{GameData.TrapRank[3]}, {GameData.TrapRank[4]}, {GameData.TrapRank[5]}, {GameData.TrapRank[6]}");
    }

    private void Update()
    {
        RankCheck();
    

    }

}
