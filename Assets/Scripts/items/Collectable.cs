using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Collectable : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData pointerEventData)
    {
		OnCoinClicked();
    }

	public void OnCoinClicked()
    {
        PlayerData.CurrencyPoint += 50;
        Destroy(this.gameObject);
    }





}
