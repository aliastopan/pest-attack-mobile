using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
	public Canvas MainMenuCavas;
	public AudioSource BGMSource;

	private void Awake() 
	{
		GameData.MainMenuCanvas = MainMenuCavas;	
	}
	private void Update() 
	{
		BGMSource.mute = GameData.IsMute;	
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

	public void Retry()
	{
		//Scene currentScene = SceneManager.GetActiveScene();
		//SceneManager.LoadScene("Gameplay", LoadSceneMode.Additive);
		//SceneManager.UnloadSceneAsync(currentScene);
		SceneManager.LoadScene("Gameplay");

		
	}

	public void UponRestart()
	{
		GameData.UponRestart();
		PlayerData.UponRestart();
	}
}
