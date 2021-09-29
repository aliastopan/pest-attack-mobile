using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TaelCoin : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData pointerEventData)
    {
		OnCoinClicked();
    }

	public void OnCoinClicked()
    {
        PlayerData.CurrentTaelPoint += 50;
        Destroy(this.gameObject);
    }





}
