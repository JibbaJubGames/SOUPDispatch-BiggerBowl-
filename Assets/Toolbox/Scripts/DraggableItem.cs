using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Vector3 itemHome;
    public DraggableSlot slot;

    private void Start()
    {
        
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        itemHome = this.transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = itemHome;
        if (slot != null && !slot.occupiedSpot) 
            {
                slot.occupiedSpot = true;
                this.transform.SetParent(slot.transform, false);
                itemHome = slot.transform.position;
                this.transform.position = itemHome;
                this.GetComponent<Button>().interactable = false;
                this.GetComponent<DraggableItem>().enabled = false;
            }
        Debug.Log("Stopped Drag");
        this.GetComponent<Animator>().SetTrigger("Normal");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DraggableSlot")
        {
            slot = collision.GetComponent<DraggableSlot>();
            Debug.Log("Hit a draggable spot");
        }
    }

//    private void OnTriggerExit2D(Collider2D collision)
//    {
//        if (collision.gameObject.tag == "DraggableSlot")
//        {
//            slot.occupiedSpot = false;
//        }
//    }

}
