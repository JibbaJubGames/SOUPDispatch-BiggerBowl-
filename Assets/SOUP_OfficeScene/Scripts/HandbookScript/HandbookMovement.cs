using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HandbookMovement : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IEndDragHandler
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
    [SerializeField] private Sprite deskImage;

    [Header("")]
    public TMP_Text handbookTitle;
    public TMP_Text handbookDescription;

    [Header("Drawer Info")]
    [SerializeField] private Vector3 drawerScale;
    [SerializeField] private Quaternion drawerRotation;
    [SerializeField] private Transform drawerParent;
    [SerializeField] private int drawerXMin;
    [SerializeField] private int drawerXMax;
    [SerializeField] private int drawerYMin;
    [SerializeField] private int drawerYMax;


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

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = Input.mousePosition;
        this.transform.SetAsLastSibling();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!onDesk && !inDrawer)
        {
                this.transform.rotation = drawerRotation;
                this.transform.localScale = drawerScale;
                this.transform.SetParent(drawerParent, false);
                int placementX = Random.Range(drawerXMin, drawerXMax);
                int placementY = Random.Range(drawerYMin, drawerYMax);
                this.transform.localPosition = new Vector3 (placementX, placementY, 0);
                this.GetComponent<Image>().sprite = null;
                //Temp Functions below
                this.GetComponent<Image>().color = Color.yellow;
                handbookTitle.color = Color.black;
                handbookDescription.color = Color.black;
                inDrawer = true;
        }
        else if (inDrawer)
        {
            this.transform.position = Input.mousePosition;
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
                animToUse.SetTrigger (desiredTrigger);
                this.transform.rotation = deskRotation;
                this.transform.localScale = deskScale;
                this.transform.SetParent(deskParent, true);
                this.GetComponent<Image>().sprite = deskImage;
                //Temp Functions below
                this.GetComponent<Image>().color = Color.white;
                handbookTitle.color = Color.clear;
                handbookDescription.color = Color.clear;
                inDrawer = false;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("LeftDrawer"))
        {
            if (onDesk)
            {
                onDesk = false;
                if (!animToUse.GetCurrentAnimatorStateInfo(0).IsName("LeftDrawerHover"))
                {
                string desiredTrigger = openDrawer;
                animToUse.SetTrigger(desiredTrigger);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("LeftDrawer"))
        {
            if (animToUse.GetCurrentAnimatorStateInfo(0).IsName("LeftDrawerHover") && !inDrawer)
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
