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
                // string cost =   upgradeCost == 0 ? $"MAX" : $"{upgradeCost}";
                string cost = GameData.TrapRank[i+1] >= 3 ? $"MAX" : $"{upgradeCost}";
                string display = $"Rank: {GameData.TrapRank[i+1].ToString()} / ";
                TrapRank[i].text = display + cost;
            }
        }
    }

    public void UpgradeAirSabun()
    {   
        int index = 1;
        int currentRank = GameData.TrapRank[index];
        if(currentRank == 3)
            return;
        
        int upgradeCost = TrapStats[index-1].StatsByRank[currentRank].UpgradeCost;
        Debug.Log($"rank: {currentRank}, cost: {upgradeCost}");

        if(currentRank < 3 && PlayerData.CurrentStarPoint >= upgradeCost)
        {
            GameData.TrapRank[index]++;
            PlayerData.CurrentStarPoint -= upgradeCost;
        } 
    }

    public void UpgradeBungaMatahari()
    {
        int index = 2;
        int currentRank = GameData.TrapRank[index];
        if(currentRank == 3)
            return;
        
        int upgradeCost = TrapStats[index-1].StatsByRank[currentRank].UpgradeCost;
        Debug.Log($"rank: {currentRank}, cost: {upgradeCost}");

        if(currentRank < 3 && PlayerData.CurrentStarPoint >= upgradeCost)
        {
            GameData.TrapRank[index]++;
            PlayerData.CurrentStarPoint -= upgradeCost;
        } 
    }

    public void UpgradeBebek()
    {
        int index = 3;
        int currentRank = GameData.TrapRank[index];
        if(currentRank == 3)
            return;
        
        int upgradeCost = TrapStats[index-1].StatsByRank[currentRank].UpgradeCost;
        Debug.Log($"rank: {currentRank}, cost: {upgradeCost}");

        if(currentRank < 3 && PlayerData.CurrentStarPoint >= upgradeCost)
        {
            GameData.TrapRank[index]++;
            PlayerData.CurrentStarPoint -= upgradeCost;
        } 

    }

    public void UpgradeBurungHantu()
    {
        int index = 4;
        int currentRank = GameData.TrapRank[index];
        if(currentRank == 3)
            return;
        
        int upgradeCost = TrapStats[index-1].StatsByRank[currentRank].UpgradeCost;
        Debug.Log($"rank: {currentRank}, cost: {upgradeCost}");

        if(currentRank < 3 && PlayerData.CurrentStarPoint >= upgradeCost)
        {
            GameData.TrapRank[index]++;
            PlayerData.CurrentStarPoint -= upgradeCost;
        } 

    }
    public void UpgradeUlar()
    {
        int index = 5;
        int currentRank = GameData.TrapRank[index];
        if(currentRank == 3)
            return;
        
        int upgradeCost = TrapStats[index-1].StatsByRank[currentRank].UpgradeCost;
        Debug.Log($"rank: {currentRank}, cost: {upgradeCost}");

        if(currentRank < 3 && PlayerData.CurrentStarPoint >= upgradeCost)
        {
            GameData.TrapRank[index]++;
            PlayerData.CurrentStarPoint -= upgradeCost;
        } 

    }
}
