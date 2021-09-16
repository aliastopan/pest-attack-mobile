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
       // Debug.Log($"Input: {ObjectMaster.Instance.Camera.ScreenToWorldPoint(Input.mousePosition)}");
    }


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

    }
}
