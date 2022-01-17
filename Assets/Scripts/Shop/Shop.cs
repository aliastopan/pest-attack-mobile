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
                string display = $"Rank: {GameData.TrapRank[i+1].ToString()} / ";
                TrapRank[i].text = display + cost;
            }
        }
    }

    public void UpgradeAirSabun()
    {   
        int currentRank = GameData.TrapRank[1];
        int upgradeCost = TrapStats[0].StatsByRank[currentRank].UpgradeCost;

        if(GameData.TrapRank[1] < 3 && PlayerData.CurrentStarPoint >= upgradeCost)
        {
            GameData.TrapRank[1]++;
            PlayerData.CurrentStarPoint -= upgradeCost;
        } 

        //if(GameData.TrapRank[(int)ObjectMaster.Instance.DeckSlot[(int)CardType.AirSabun]] < 3)
        //    GameData.TrapRank[(int)ObjectMaster.Instance.DeckSlot[(int)CardType.AirSabun]]++;
    }

    public void UpgradeBungaMatahari()
    {
        int currentRank = GameData.TrapRank[2];
        int upgradeCost = TrapStats[1].StatsByRank[currentRank].UpgradeCost;

        if(GameData.TrapRank[2] < 3 && PlayerData.CurrentStarPoint >= upgradeCost)
        {
            GameData.TrapRank[2]++;
            PlayerData.CurrentStarPoint -= upgradeCost;
        } 

        // if(GameData.TrapRank[(int)ObjectMaster.Instance.DeckSlot[(int)CardType.BungaMatahari]] < 3)
        //     GameData.TrapRank[(int)ObjectMaster.Instance.DeckSlot[(int)CardType.BungaMatahari]]++;
    }

    public void UpgradeBebek()
    {
        int currentRank = GameData.TrapRank[3];
        int upgradeCost = TrapStats[2].StatsByRank[currentRank].UpgradeCost;

        if(GameData.TrapRank[3] < 3 && PlayerData.CurrentStarPoint >= upgradeCost)
        {
            GameData.TrapRank[3]++;
            PlayerData.CurrentStarPoint -= upgradeCost;
        } 

        // if(GameData.TrapRank[(int)ObjectMaster.Instance.DeckSlot[(int)CardType.Bebek]] < 3)
        //     GameData.TrapRank[(int)ObjectMaster.Instance.DeckSlot[(int)CardType.Bebek]]++;
    }

    public void UpgradeBurungHantu()
    {
        int currentRank = GameData.TrapRank[4];
        int upgradeCost = TrapStats[3].StatsByRank[currentRank].UpgradeCost;

        if(GameData.TrapRank[4] < 3 && PlayerData.CurrentStarPoint >= upgradeCost)
        {
            GameData.TrapRank[4]++;
            PlayerData.CurrentStarPoint -= upgradeCost;
        } 

        // if(GameData.TrapRank[(int)ObjectMaster.Instance.DeckSlot[(int)CardType.BurungHantu]] < 3)
        //     GameData.TrapRank[(int)ObjectMaster.Instance.DeckSlot[(int)CardType.BurungHantu]]++;
    }
    public void UpgradeUlar()
    {
                int currentRank = GameData.TrapRank[5];
        int upgradeCost = TrapStats[4].StatsByRank[currentRank].UpgradeCost;

        if(GameData.TrapRank[5] < 3 && PlayerData.CurrentStarPoint >= upgradeCost)
        {
            GameData.TrapRank[5]++;
            PlayerData.CurrentStarPoint -= upgradeCost;
        } 

        // if(GameData.TrapRank[(int)ObjectMaster.Instance.DeckSlot[(int)CardType.Ular]] < 3)
        //     GameData.TrapRank[(int)ObjectMaster.Instance.DeckSlot[(int)CardType.Ular]]++;
    }
}
