using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMaster : MonoBehaviour
{
    public static ObjectMaster Instance;

    public Canvas Canvas;
    public Camera Camera;

    public void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

}
