using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Vector3 itemHome;
    public Vector3 originalHome;
    public DraggableSlot slot;

    private void Start()
    {
        
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!ChosenHeroInfoHolder.holdingHero)
        {
            itemHome = this.transform.position;
            originalHome = this.transform.position;
            if (this.GetComponent<Image>() != null)
            {
                Image img = this.GetComponent<Image>();
                img.raycastTarget = false;
            }
            ChosenHeroInfoHolder.holdingHero = true;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = itemHome;

        if (this.GetComponent<Image>() != null)
        {
            
        }
        if (slot != null && !slot.occupiedSpot) 
            {
                slot.occupiedSpot = true;
                this.transform.SetParent(slot.transform, false);
                itemHome = slot.transform.position;
                this.transform.position = itemHome;
                this.GetComponent<Button>().interactable = false;
                this.GetComponent<DraggableItem>().enabled = false;
                Image img = this.GetComponent<Image>();
                img.raycastTarget = false;
            slot.gameObject.GetComponent<RandomCallerDispatchLocationCheck>().autoscribe.EndedDispatch();
            }
        this.GetComponent<Animator>().SetTrigger("Normal");
        ChosenHeroInfoHolder.holdingHero = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DraggableSlot")
        {
            slot = collision.GetComponent<DraggableSlot>();
        }
        else if (collision.gameObject.tag == "DraggableReset")
        {
            slot = null;
            itemHome = originalHome;
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
