using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardContainer : MonoBehaviour
{
    public Color DefaultColor;
    public Color ToDropColor;
	public void OnTriggerEnter2D(Collider2D collision)
	{
        if(collision.gameObject.tag == "Card" && this.transform.childCount == 0)
        {
            this.GetComponent<Image>().color = ToDropColor;
            PlayerData.AvailableGrids++;
            collision.gameObject.GetComponent<DraggableCard>().AvailableGrid = this.gameObject;
        }

	}
    public void OnTriggerExit2D(Collider2D collision)
	{
        if(collision.gameObject.tag == "Card")
        {
            this.GetComponent<Image>().color = DefaultColor;
            PlayerData.AvailableGrids--; 
            collision.gameObject.GetComponent<DraggableCard>().AvailableGrid = null;
            
        }
	}
        public void OnTriggerStay2D(Collider2D collision)
	{
        if(collision.gameObject.tag == "Card")
        {
            collision.gameObject.GetComponent<DraggableCard>().AvailableGrid = this.gameObject;
        }
	}

}
