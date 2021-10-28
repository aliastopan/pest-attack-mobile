using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject PrefabsAirSabun;
    public GameObject PrefabsJaring;
    public GameObject PrefabsPlastik;
    public GameObject PrefabsBebek;
    public GameObject PrefabBurung;
    public GameObject PrefabUlar;

    /*
    public void UpgradeAirSabun()
    {
        if(GameData.TrapRank[(int)ObjectMaster.Instance.DeckSlot[(int)CardType.AirSabun]] < 
            PrefabsAirSabun.GetComponent<DeckedCard>().CardRank.Length )
            GameData.TrapRank[(int)ObjectMaster.Instance.DeckSlot[(int)CardType.AirSabun]]++;
    }
    */

    public void UpgradeAirSabun()
    {
        if(GameData.TrapRank[(int)ObjectMaster.Instance.DeckSlot[(int)CardType.AirSabun]] < 3)
            GameData.TrapRank[(int)ObjectMaster.Instance.DeckSlot[(int)CardType.AirSabun]]++;
    }

    public void UpgradeBungaMatahari()
    {
        if(GameData.TrapRank[(int)ObjectMaster.Instance.DeckSlot[(int)CardType.BungaMatahari]] < 3)
            GameData.TrapRank[(int)ObjectMaster.Instance.DeckSlot[(int)CardType.BungaMatahari]]++;
    }

    public void UpgradeBebek()
    {
        if(GameData.TrapRank[(int)ObjectMaster.Instance.DeckSlot[(int)CardType.Bebek]] < 3)
            GameData.TrapRank[(int)ObjectMaster.Instance.DeckSlot[(int)CardType.Bebek]]++;
    }

    public void UpgradeBurungHantu()
    {
        if(GameData.TrapRank[(int)ObjectMaster.Instance.DeckSlot[(int)CardType.BurungHantu]] < 3)
            GameData.TrapRank[(int)ObjectMaster.Instance.DeckSlot[(int)CardType.BurungHantu]]++;
    }
    public void UpgradeUlar()
    {
        if(GameData.TrapRank[(int)ObjectMaster.Instance.DeckSlot[(int)CardType.Ular]] < 3)
            GameData.TrapRank[(int)ObjectMaster.Instance.DeckSlot[(int)CardType.Ular]]++;
    }
}
