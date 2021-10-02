using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
	public void OnLoadStage()
	{
		SceneManager.LoadScene("Gameplay", LoadSceneMode.Additive);
		//PlayerData.UponRestart();
	}

	public void OnBackToMenu()
	{
		SceneManager.UnloadSceneAsync("Gameplay");
		Debug.Log("... Restart");
	}
}
