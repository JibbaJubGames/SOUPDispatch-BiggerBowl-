using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class HeroProfileMovement : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IEndDragHandler
{
    [Header("Desk and Drawer Switch")]
    [SerializeField] private Animator animToUse;
    [SerializeField] private bool onDesk;
    [SerializeField] private bool inDrawer;
    [SerializeField] private string switchToDesk;
    [SerializeField] private string openDrawer;
    [SerializeField] private string closeDrawer;

    [Header("Desk Info")]
    [SerializeField] private Vector3 deskScale;
    [SerializeField] private Quaternion deskRotation;
    [SerializeField] private Transform deskParent;
    [SerializeField] private UsableSpaceScript spaceLock;


    public void OnPointerEnter(PointerEventData eventData)
    {
        if (onDesk)
        {
            this.transform.localScale = deskScale;
        }
        else
        {
            this.transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        this.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!onDesk && !inDrawer)
        {
            Destroy(this.gameObject);
        }
        else if (!spaceLock.withinValidSpace)
        {
            this.transform.position = spaceLock.draggingPosition;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!onDesk)
        {
            this.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            return;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SwitchDrag"))
        {
            if (!onDesk)
            {
                onDesk = true;
                string desiredTrigger = switchToDesk;
                animToUse.SetTrigger(desiredTrigger);
                this.transform.rotation = deskRotation;
                this.transform.localScale = deskScale;
                this.transform.SetParent(deskParent, true);
                inDrawer = false;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("RightDrawer"))
        {
            if (onDesk)
            {
                onDesk = false;
                if (!animToUse.GetCurrentAnimatorStateInfo(0).IsName("RightDrawerHover"))
                {
                    string desiredTrigger = openDrawer;
                    animToUse.SetTrigger(desiredTrigger);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("RightDrawer"))
        {
            if (animToUse.GetCurrentAnimatorStateInfo(0).IsName("RightDrawerHover") && !inDrawer)
            {
                string desiredTrigger = closeDrawer;
                animToUse.SetTrigger(desiredTrigger);
                onDesk = true;
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
