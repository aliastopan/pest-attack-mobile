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

    private bool isDragging;

    private void Start()
    {
        objectMaster = ObjectMaster.Instance;
        OnUpgrade();            

    }
    
    private void Update()
    {
        if(PlayerData.AvailableGrids < 0)
            PlayerData.AvailableGrids = 0;    

       OnUpgrade();            
    }

    public void OnUpgrade()
    {
        // GameData.TrapRank[0]
        int cardType = (int) CardType;
        int cardRank = (int) GameData.TrapRank[cardType];
        //Debug.Log($"Card Type: {CardType} [{cardType}], Rank: {cardRank}");
        //Debug.Log($"Upgrade. {GameData.TrapRank[cardRank]}");
        this.gameObject.GetComponent<Image>().sprite = CardRank[cardRank-1];
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(PlayerData.CurrentTaelPoint >= (int) DraggableCard.GetComponent<DraggableCard>().TrapCard.GetComponent<Trap>().Cost)
        {
            Vector3 pointerPosition = ObjectMaster.Instance.Camera.ScreenToWorldPoint(Input.mousePosition);
            pointerPosition.z = 0f;
            draggableInstance.transform.position = pointerPosition;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(PlayerData.CurrentTaelPoint >= DraggableCard.GetComponent<DraggableCard>().TrapCard.GetComponent<Trap>().Cost)
        {
            draggableInstance = Instantiate(DraggableCard, this.transform);
            isDragging = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        int cost = (int) DraggableCard.GetComponent<DraggableCard>().TrapCard.GetComponent<Trap>().Cost;
        
        try{
            //draggableInstance.GetComponent<DraggableCard>().AvailableGrid != null && 
            bool isGridOpen = PlayerData.AvailableGrids == 1;
            bool isGridEmpty = draggableInstance.GetComponent<DraggableCard>().AvailableGrid.transform.childCount == 0; 

            if(isGridOpen && isGridEmpty && isDragging)
            {
                GameObject instance = draggableInstance.GetComponent<DraggableCard>().TrapCard;
                Transform location = draggableInstance.GetComponent<DraggableCard>().AvailableGrid.transform;
                GameObject trap = Instantiate(instance, location);
                PlayerData.CurrentTaelPoint -= DraggableCard.GetComponent<DraggableCard>().TrapCard.GetComponent<Trap>().Cost;
                isDragging = false;

            }
            else
            {
                PlayerData.AvailableGrids = 0;
                //Debug.Log($"Unable to Drop.");
            }
        }catch(System.Exception e){
            Debug.LogWarning($"{e}");
        }



        Destroy(draggableInstance);
    }
}
