using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpPanel : MonoBehaviour
{
    public GameObject HelpSprite;
    public Text HelpText; 
    public List<Help> Helps = new List<Help>();
    public int HelpIndex = 0;

    private void Update() 
    {
        HelpSprite.GetComponent<Image>().sprite = Helps[HelpIndex].Illustration;
        HelpText.text = Helps[HelpIndex].Description;

        Debug.LogWarning($"Help Index: {HelpIndex}");

    }

    public void NextHelp()
    {
        if(HelpIndex < Helps.Count - 1)
            HelpIndex++;
        else
            HelpIndex = 0;
    }

    public void PrevHelp()
    {
        if(HelpIndex < 1)
            HelpIndex--;
        else
            HelpIndex = Helps.Count;
    }



}
