using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Screen")]
    public GameObject ShopScreen;
    public GameObject PauseSceen;
    public GameObject GameOverScreen;
    public GameObject WinScreen;

    [Header("Gameplay Element")]
	public Text collectableText;
    public Text lifePointText;
	public static int collectable;
    public static int lifePoint;


    [Header("Shop Element")]
    public Text RankAirSabunText;
    public Text RankJaringText;
    public Text RankPlastikText;

    public Text RankBebekText;
    public Text RankBurungHantuText;
    public Text RankUlarText;



    
    

    // Start is called before the first frame update
    private void Start()
    {
        collectable = 0;
        lifePoint = 0;

        PauseSceen.SetActive(false);
        ShopScreen.SetActive(false);
        GameOverScreen.SetActive(false);
        WinScreen.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        collectableText.text = $"{PlayerData.CurrentTaelPoint}";
        lifePointText.text = $"{PlayerData.LifePoint}";     

        RankAirSabunText.text = $"Rank {GameData.TrapRank[(int)ObjectMaster.Instance.DeckSlot[(int)CardType.AirSabun]]}";
        RankJaringText.text = $"Rank {GameData.TrapRank[(int)ObjectMaster.Instance.DeckSlot[(int)CardType.Jaring]]}";   
        RankPlastikText.text = $"Rank {GameData.TrapRank[(int)ObjectMaster.Instance.DeckSlot[(int)CardType.Plastik]]}";   
        RankBebekText.text = $"Rank {GameData.TrapRank[(int)ObjectMaster.Instance.DeckSlot[(int)CardType.Bebek]]}";   
        RankBurungHantuText.text = $"Rank {GameData.TrapRank[(int)ObjectMaster.Instance.DeckSlot[(int)CardType.BurungHantu]]}";   
        RankUlarText.text = $"Rank {GameData.TrapRank[(int)ObjectMaster.Instance.DeckSlot[(int)CardType.Ular]]}";   


        Debug.LogWarning($"Enemy Killed: {PlayerData.CurrentEnemyKilled}/{GameData.MAX_ENEMY_SPAWN[GameData.SELECTED_STAGE]}");
        if(PlayerData.CurrentEnemyKilled == GameData.MAX_ENEMY_SPAWN[GameData.SELECTED_STAGE])
        {
            //Debug.Log($"WIN");
            GameWin();
        }

    }

    public void GameWin()
    {
        PauseGame();
        WinScreen.SetActive(true);

    }

    public void GameOver()
    {
        PauseGame();
        GameOverScreen.SetActive(true);

    }

    public void OpenPauseScreen()
    {
        PauseSceen.SetActive(true);
        PauseGame();
    }

    public void ClosePauseScreen()
    {
        ShopScreen.SetActive(false);
        ResumeGame();
    }

    public void OpenShop()
    {
        Time.timeScale = 0;
        ShopScreen.SetActive(true);
    }

    public void CloseShop()
    {
        Time.timeScale = 1;
        ShopScreen.SetActive(false);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }



}
