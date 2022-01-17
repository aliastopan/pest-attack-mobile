using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


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
    private bool isRewarded = false;



    [Header("Shop Element")]
    public Text RankAirSabunText;
    public Text RankBungaMatahariText;
    public Text RankBebekText;
    public Text RankBurungHantuText;
    public Text RankUlarText;


    // Start is called before the first frame update
    private void Start()
    {
        isRewarded = false;
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

        //RankAirSabunText.text = $"Rank {GameData.TrapRank[(int)ObjectMaster.Instance.DeckSlot[(int)CardType.AirSabun]]}";
        //RankBungaMatahariText.text = $"Rank {GameData.TrapRank[(int)ObjectMaster.Instance.DeckSlot[(int)CardType.BungaMatahari]]}";   
        //RankBebekText.text = $"Rank {GameData.TrapRank[(int)ObjectMaster.Instance.DeckSlot[(int)CardType.Bebek]]}";   
        //RankBurungHantuText.text = $"Rank {GameData.TrapRank[(int)ObjectMaster.Instance.DeckSlot[(int)CardType.BurungHantu]]}";   
        //RankUlarText.text = $"Rank {GameData.TrapRank[(int)ObjectMaster.Instance.DeckSlot[(int)CardType.Ular]]}";   


        // Debug.LogWarning($"Enemy Killed: {PlayerData.CurrentEnemyKilled}/{GameData.MAX_ENEMY_SPAWN[GameData.SELECTED_STAGE]}");
        if(PlayerData.CurrentEnemyKilled == GameData.MAX_ENEMY_SPAWN[GameData.SELECTED_STAGE])
        {
            //Debug.Log($"WIN");
            GameWin();
        }

        if(PlayerData.LifePoint <= 0)
        {
            GameOver();
        }

    }

    // MAX_ENEMY_SPAWN
    // ENEMY_KILLED
    public void GameWin()
    {
        int maxEnemy = GameData.MAX_ENEMY_SPAWN[GameData.SELECTED_STAGE];
        int enemyKilled = GameData.ENEMY_KILLED;
       
        Debug.LogWarning($"IS WIN: {!isRewarded}");

        if(!isRewarded)
        {
            isRewarded = true;
            int reward = GameData.WIN_REWARD[GameData.SELECTED_STAGE];
            
            Debug.LogWarning($"CURRENT: {PlayerData.CurrentStarPoint}");
            Debug.LogWarning($"REWARD: {reward}");
            PlayerData.CurrentStarPoint += GameData.WIN_REWARD[GameData.SELECTED_STAGE];        
            Debug.LogWarning($"ADDED REWARD: {PlayerData.CurrentStarPoint}");
        }


        
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
        PauseSceen.SetActive(false);
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
        // Debug.Log("PAUSE CALLED");
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void Retry()
	{
        GameOverScreen.SetActive(false);
        Time.timeScale = 1;
        PlayerData.UponRestart(); 
        SceneManager.LoadScene("Gameplay");
	}

    public void ProperRestart()
	{
        GameOverScreen.SetActive(false);
        Time.timeScale = 1;
        PlayerData.UponRestart();
        GameData.UponRestart();
		SceneManager.UnloadSceneAsync("Gameplay");
        // SceneManager.LoadScene("Gameplay", LoadSceneMode.Additive);

	}

    public void OnBackToMenu()
	{
        GameData.IsPlaying = false;
		GameData.UponRestart();
        Time.timeScale = 1;
        PlayerData.UponRestart();
		GameData.MainMenuCanvas.gameObject.SetActive(true);
    	SceneManager.UnloadSceneAsync("Gameplay");
		// Debug.Log("... Restart");
	}

    

}
