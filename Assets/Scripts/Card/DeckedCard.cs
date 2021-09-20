using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DeckedCard : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private ObjectMaster objectMaster;
    private GameObject draggableInstance;
    public GameObject DraggableCard;

    private void Start()
    {
        objectMaster = ObjectMaster.Instance;
    }
    
    private void Update()
    {
        if(PlayerData.AvailableGrids < 0)
            PlayerData.AvailableGrids = 0;    }


    public void OnDrag(PointerEventData eventData)
    {
        Vector3 pointerPosition = ObjectMaster.Instance.Camera.ScreenToWorldPoint(Input.mousePosition);
        pointerPosition.z = 0f;
        draggableInstance.transform.position = pointerPosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        draggableInstance = Instantiate(DraggableCard, this.transform);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if(draggableInstance.GetComponent<DraggableCard>().AvailableGrid != null && 
            PlayerData.AvailableGrids == 1)
        {
            Debug.Log($"Drop Available.");
            Instantiate(draggableInstance.GetComponent<DraggableCard>().TrapCard, 
                draggableInstance.GetComponent<DraggableCard>().AvailableGrid.transform);

        }
        else
        {
            Debug.Log($"Unable to Drop.");
        }


        Destroy(draggableInstance);
    }
}
