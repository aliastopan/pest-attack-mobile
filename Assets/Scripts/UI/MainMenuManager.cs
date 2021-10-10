using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [Header("Panel")]
    public GameObject LevelPanel;
    public Image Level;


    public Text LevelRewardText;
    [Header("Level")]
    public List<Sprite> Levels = new List<Sprite>();

    [Header("Inner Panel")]
    public GameObject ShopPanel;
    public GameObject BantuanPanel;
    public GameObject KoleksiPanel;

    private void Awake() 
    {
        LevelPanel.SetActive(false);   
        Level.sprite = Levels[0];

        ShopPanel.SetActive(false);
        BantuanPanel.SetActive(false);   
        KoleksiPanel.SetActive(false);   
    }


    private void Update() 
    {
        Level.sprite = Levels[GameData.SELECTED_STAGE];
        Debug.Log($"Stage Lv: {GameData.SELECTED_STAGE + 1}");
        LevelRewardText.text = $"{GameData.WIN_REWARD[GameData.SELECTED_STAGE]}";

    }

    public void OpenLevelPanel()
        => LevelPanel.SetActive(true);   
        
    public void CloseLevelPanel()
        => LevelPanel.SetActive(false);   

    public void PrevLevel()
    {
        if(GameData.SELECTED_STAGE >= 1)
            GameData.SELECTED_STAGE--;
        else
            GameData.SELECTED_STAGE = 4;
    }

    public void NextLevel()
    {
        if(GameData.SELECTED_STAGE <= 3)
            GameData.SELECTED_STAGE++;
        else
            GameData.SELECTED_STAGE = 0;
    }
        // BANTUAN
    public void OpenBantuanPanel()
    {
        BantuanPanel.SetActive(true);

    }

    public void CloseBantuanPanel()
    {
        BantuanPanel.SetActive(false);
        
    }

    // KOLEKSI
    public void OpenKoleksiPanel()
    {
        KoleksiPanel.SetActive(true);
    }

    public void CloseKoleksiPanel()
    {
        KoleksiPanel.SetActive(false);
    }

    // SHOP
    public void OpenShopPanel()
    {
        ShopPanel.SetActive(true);
    }

    public void CloseShopPanel()
    {
        ShopPanel.SetActive(false);
    }
    

}
