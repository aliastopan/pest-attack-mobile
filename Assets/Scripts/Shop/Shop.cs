using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public void UpgradeAirSabun()
    {
        if(GameData.Rank_AirSabun < 3)
            GameData.Rank_AirSabun++;
    }

    public void UpgradeJaring()
    {
        if(GameData.Rank_Jaring < 3)
            GameData.Rank_AirSabun++;
    }

    public void UpgradePlastik()
    {
        if(GameData.Rank_Jaring < 3)
            GameData.Rank_AirSabun++;
    }



}
