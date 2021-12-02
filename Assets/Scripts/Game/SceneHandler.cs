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
		ForceRestart();

		if(!GameData.IsPlaying){
			// set canvas back to true
		}
	}

	private void ForceRestart()
	{
		if(GameData.IsPlaying && SceneManager.sceneCount == 1)
		{
			Debug.Log("Force Restart");
			SceneManager.LoadScene("Gameplay", LoadSceneMode.Additive);
			GameData.MainMenuCanvas.gameObject.SetActive(false);
			UponRestart();
		}
	}

	public void OnLoadStage()
	{
		GameData.IsPlaying = true;
		SceneManager.LoadScene("Gameplay", LoadSceneMode.Additive);

		GameData.MainMenuCanvas.gameObject.SetActive(false);
		UponRestart();
	}

	public void OnBackToMenu()
	{
		SceneManager.UnloadSceneAsync("Gameplay");
		GameData.MainMenuCanvas.gameObject.SetActive(true);
		UponRestart();
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
