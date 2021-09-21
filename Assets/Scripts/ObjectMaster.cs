using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMaster : MonoBehaviour
{
    public Color DefaultColor;
    public Color ToDropColor;

    public static ObjectMaster Instance;

    public Canvas Canvas;
    public Camera Camera;

    public void Awake()
    {
        if(Instance == null)
            Instance = this;

        //DefaultColor = ObjectMaster.Instance.DefaultColor;
        //ToDropColor = ObjectMaster.Instance.ToDropColor;  
    }

    private void Update() 
    {
        //DefaultColor = ObjectMaster.Instance.DefaultColor;
        //ToDropColor = ObjectMaster.Instance.ToDropColor;    
    }

}
