using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Text StarPointText;
    public List<Text> TrapRank = new List<Text>();
    public List<TrapStats> TrapStats = new List<TrapStats>();
    
    private void Update() 
    {
        StarPointText.text = PlayerData.CurrentStarPoint.ToString();
        if(TrapRank.Count > 0)
        {
            for(int i = 0; i < TrapRank.Count; i++)
            {
                int currentRank = GameData.TrapRank[i+1] - 1;
                int upgradeCost = TrapStats[i].StatsByRank[currentRank].UpgradeCost;
                string cost =   upgradeCost == 0 ? $"MAX" : $"{upgradeCost}";
                string display = $"Rank: {GameData.TrapRank[i].ToString()} / ";
                TrapRank[i].text = display + cost;
            }
        }
    }

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
