using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DraggableCard : MonoBehaviour
{
    public GameObject AvailableGrid;
    public GameObject TrapCard;
    public Color DefaultColor;
    public Color ToDropColor;


	public void OnTriggerEnter2D(Collider2D collision)
	{
        if(AvailableGrid == null && collision.gameObject.tag == "Grid")
        {
        //     AvailableGrid = collision.gameObject;
        //     collision.gameObject.GetComponent<Image>().color = ToDropColor;
        }

	}
    public void OnTriggerExit2D(Collider2D collision)
	{
        if(collision.gameObject.tag == "Grid")
        {
        //    AvailableGrid = null;
        //    collision.gameObject.GetComponent<Image>().color = DefaultColor;
        }

	}

}
