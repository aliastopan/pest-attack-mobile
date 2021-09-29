using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public void UpgradeTrap(int trapIndex)
    {
        if(GameData.TrapRank[(int)ObjectMaster.Instance.DeckSlot[trapIndex]] < 3 )
            GameData.TrapRank[(int)ObjectMaster.Instance.DeckSlot[trapIndex]]++;
    }

    public void UpgradeAirSabun()
    {
        if(GameData.TrapRank[(int)ObjectMaster.Instance.DeckSlot[(int)CardType.AirSabun]] < 3 )
            GameData.TrapRank[(int)ObjectMaster.Instance.DeckSlot[(int)CardType.AirSabun]]++;
    }

    public void UpgradeJaring()
    {
        if(GameData.TrapRank[(int)ObjectMaster.Instance.DeckSlot[(int)CardType.Jaring]] < 3 )
            GameData.TrapRank[(int)ObjectMaster.Instance.DeckSlot[(int)CardType.Jaring]]++;
    }

    public void UpgradePlastik()
    {
        if(GameData.TrapRank[(int)ObjectMaster.Instance.DeckSlot[(int)CardType.Plastik]] < 3 )
            GameData.TrapRank[(int)ObjectMaster.Instance.DeckSlot[(int)CardType.Plastik]]++;
    }

    public void UpgradeBebek()
    {
        if(GameData.TrapRank[(int)ObjectMaster.Instance.DeckSlot[(int)CardType.Bebek]] < 3 )
            GameData.TrapRank[(int)ObjectMaster.Instance.DeckSlot[(int)CardType.Bebek]]++;
    }

    public void UpgradeBurungHantu()
    {
        if(GameData.TrapRank[(int)ObjectMaster.Instance.DeckSlot[(int)CardType.BurungHantu]] < 3 )
            GameData.TrapRank[(int)ObjectMaster.Instance.DeckSlot[(int)CardType.BurungHantu]]++;
    }
    public void UpgradeUlar()
    {
        if(GameData.TrapRank[(int)ObjectMaster.Instance.DeckSlot[(int)CardType.Ular]] < 3 )
            GameData.TrapRank[(int)ObjectMaster.Instance.DeckSlot[(int)CardType.Ular]]++;
    }
}
