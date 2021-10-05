using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionPanel : MonoBehaviour
{
    public GameObject CollectionSprite;
    public Text CollectionText; 
    public List<Help> Collections = new List<Help>();
    public int CollectionIndex = 0;

    private void Update() 
    {
        CollectionSprite.GetComponent<Image>().sprite = Collections[CollectionIndex].Illustration;
        CollectionText.text = Collections[CollectionIndex].Description;

        //Debug.LogWarning($"Help Index: {HelpIndex}");
        if(CollectionIndex < 0)
            CollectionIndex = 0;
    }

    public void NextHelp()
    {
        if(CollectionIndex < Collections.Count - 1)
        {
            CollectionIndex++;
        }
        else
            CollectionIndex = 0;
    }

    public void PrevHelp()
    {
        if(CollectionIndex > 1)
        {
            CollectionIndex--;
        }
        else
        {
            CollectionIndex = Collections.Count - 1;
        }
    }



}
