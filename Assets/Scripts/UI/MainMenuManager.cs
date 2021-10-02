using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public GameObject LevelPanel;

    private void Awake() 
    {
        LevelPanel.SetActive(false);   
    }

    public void OpenLevelPanel()
        => LevelPanel.SetActive(true);   
        
    public void CloseLevelPanel()
        => LevelPanel.SetActive(false);   

    

}
