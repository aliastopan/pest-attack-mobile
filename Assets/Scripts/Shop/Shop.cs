using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public void UpgradeAirSabun()
    {
        //Debug.Log($"{ObjectMaster.Instance.DeckSlot[0]}");
        int slot = (int)ObjectMaster.Instance.DeckSlot[0] - 1;
       // Debug.Log($"Slot: {slot}, Rank: {GameData.TrapRank[slot]}");
        if(GameData.TrapRank[slot] < 3 ){
            GameData.TrapRank[slot]++;
        }
    }

    public void UpgradeJaring()
    {
        if(GameData.TrapRank[(int)ObjectMaster.Instance.DeckSlot[1] - 1] < 3 )
            GameData.TrapRank[(int)ObjectMaster.Instance.DeckSlot[1]- 1]++;
    }

    public void UpgradePlastik()
    {
        if(GameData.TrapRank[(int)ObjectMaster.Instance.DeckSlot[2] - 1] < 3 )
            GameData.TrapRank[(int)ObjectMaster.Instance.DeckSlot[2] - 1]++;
    }



}
