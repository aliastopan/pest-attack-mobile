using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
	public Canvas MainMenuCavas;

	private void Awake() 
	{
		GameData.MainMenuCanvas = MainMenuCavas;	
	}

	public void OnLoadStage()
	{
		SceneManager.LoadScene("Gameplay", LoadSceneMode.Additive);
		GameData.MainMenuCanvas.gameObject.SetActive(false);
		//PlayerData.UponRestart();
	}

	public void OnBackToMenu()
	{
		SceneManager.UnloadSceneAsync("Gameplay");
		GameData.MainMenuCanvas.gameObject.SetActive(true);
		Debug.Log("... Restart");
	}
}
