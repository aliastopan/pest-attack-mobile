using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DeckedCard : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public CardType CardType;
    public Sprite[] CardRank = new Sprite[3];

    private ObjectMaster objectMaster;
    private GameObject draggableInstance;
    public GameObject DraggableCard;

    private void Start()
    {
        objectMaster = ObjectMaster.Instance;
        int cardType = (int) CardType;
        int cardRank = (int) GameData.TrapRank[cardType] - 1;
        
        //ObjectMaster.Instance.DeckSlot[cardType] - 1; //GameData.TrapRank[cardType];
        //Debug.Log($"This: {(int) ObjectMaster.Instance.DeckSlot[cardType]}");

       // Debug.Log($"card type: {cardType}, card rank: {CardRank}");
        //Debug.Log($"{CardRank[0].name}");
        //Debug.Log($"{CardRank[1].name}");        
        //Debug.Log($"{CardRank[2].name}");        
        //Debug.Log($"{cardRank}");
        this.gameObject.GetComponent<Image>().sprite = CardRank[cardRank];
            //GameData.TrapRank[(int)ObjectMaster.Instance.DeckSlot[0]]

    }
    
    private void Update()
    {
        if(PlayerData.AvailableGrids < 0)
            PlayerData.AvailableGrids = 0;    }


    public void OnDrag(PointerEventData eventData)
    {
        if(PlayerData.CurrencyPoint >= (int) DraggableCard.GetComponent<DraggableCard>().TrapCard.GetComponent<Trap>().Cost)
        {
            Vector3 pointerPosition = ObjectMaster.Instance.Camera.ScreenToWorldPoint(Input.mousePosition);
            pointerPosition.z = 0f;
            draggableInstance.transform.position = pointerPosition;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(PlayerData.CurrencyPoint >= (int) DraggableCard.GetComponent<DraggableCard>().TrapCard.GetComponent<Trap>().Cost)
            draggableInstance = Instantiate(DraggableCard, this.transform);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        int cost = (int) DraggableCard.GetComponent<DraggableCard>().TrapCard.GetComponent<Trap>().Cost;
        
        //draggableInstance.GetComponent<DraggableCard>().AvailableGrid != null && 
        if(PlayerData.AvailableGrids == 1 && PlayerData.CurrencyPoint >= cost)
        {
            Debug.Log($"Drop Available.");
            Instantiate(draggableInstance.GetComponent<DraggableCard>().TrapCard, 
                draggableInstance.GetComponent<DraggableCard>().AvailableGrid.transform);

            PlayerData.CurrencyPoint -= cost;
            Destroy(draggableInstance);

        }
        else
        {
            Debug.Log($"Unable to Drop.");
        }


    }
}
