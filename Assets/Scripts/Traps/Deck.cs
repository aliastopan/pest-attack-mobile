using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<GameObject> LockableTraps = new List<GameObject>();

    private void Start() 
    {
        foreach (GameObject trap in LockableTraps)
        {
            trap.GetComponent<DeckedCard>().enabled = false;

        }    
    }
    private void Update() 
    {
        for (int i = 0; i <= GameData.SELECTED_STAGE; i++)
        {
            Debug.LogWarning($"Unlocked: {i}");
            UnlockTrap(i);
        }
    }

    private void UnlockTrap(int index)
    {
        GameObject trap = LockableTraps[index];
        trap.GetComponent<DeckedCard>().enabled = true;
        trap.transform.GetChild(0).gameObject.SetActive(false);

    }

}
