using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	public Text collectableText;
    public Text lifePointText;
	public static int collectable;
    public static int lifePoint;

    public Image ShopScreen;

    public Text RankAirSabunText;
    public Text RankJaringText;
    public Text RankPlastikText;
    
    

    // Start is called before the first frame update
    private void Start()
    {
        collectable = 0;
        lifePoint = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        collectableText.text = $"{PlayerData.CurrencyPoint}";
        lifePointText.text = $"{PlayerData.LifePoint}";     

        RankAirSabunText.text = $"Rank {GameData.TrapRank[(int)ObjectMaster.Instance.DeckSlot[0]-1]}";
        RankJaringText.text = $"Rank {GameData.TrapRank[(int)ObjectMaster.Instance.DeckSlot[1]-1]}";   
        RankPlastikText.text = $"Rank {GameData.TrapRank[(int)ObjectMaster.Instance.DeckSlot[2]-1]}";   

    }


    public void OpenShop()
    {
        Time.timeScale = 0;
        ShopScreen.gameObject.SetActive(true);
    }

    public void CloseShop()
    {
        Time.timeScale = 1;
        ShopScreen.gameObject.SetActive(false);
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
