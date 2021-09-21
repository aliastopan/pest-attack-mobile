using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public void UpgradeAirSabun()
    {
        if(GameData.TrapRank[(int)ObjectMaster.Instance.DeckSlot[0]] < 3 )
            GameData.TrapRank[(int)ObjectMaster.Instance.DeckSlot[0]]++;
    }

    public void UpgradeJaring()
    {
        if(GameData.TrapRank[(int)ObjectMaster.Instance.DeckSlot[1]] < 3 )
            GameData.TrapRank[(int)ObjectMaster.Instance.DeckSlot[1]]++;
    }

    public void UpgradePlastik()
    {
        if(GameData.TrapRank[(int)ObjectMaster.Instance.DeckSlot[2]] < 3 )
            GameData.TrapRank[(int)ObjectMaster.Instance.DeckSlot[2]]++;
    }



}
