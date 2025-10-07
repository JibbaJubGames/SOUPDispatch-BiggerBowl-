using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HandbookMovement : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    [Header("Desk and Drawer Switch")]
    [SerializeField] private Animator usableDrawers;
    [SerializeField] private Animator hoverDrawers;
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

    [Header("Drawer Info")]
    [SerializeField] private Vector3 drawerScale;
    [SerializeField] private Quaternion drawerRotation;
    [SerializeField] private Transform drawerParent;
    [SerializeField] private Sprite drawerImage;
    [SerializeField] private int drawerXMin;
    [SerializeField] private int drawerXMax;
    [SerializeField] private int drawerYMin;
    [SerializeField] private int drawerYMax;
    [SerializeField] private int rotateZMin;
    [SerializeField] private int rotateZMax;

    [Header("Focused Info")]
    [SerializeField] private Sprite focusedSprite;
    [SerializeField] private Transform focusedSpaceOne;
    [SerializeField] private Transform focusedSpaceTwo;
    [SerializeField] private bool dragging;
    [SerializeField] private bool focused;
    [SerializeField] private HandbookPages bookContents;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (focused)
        {
            if (this.transform.parent.name == "FocusSpaceOne")
            {
                FocusHolders.focusSpaceOneFull = false;
            }
            if (this.transform.parent.name == "FocusSpaceTwo")
            {
                FocusHolders.focusSpaceTwoFull = false;
            }
            if (usableDrawers.GetCurrentAnimatorStateInfo(0).IsName("LeftDrawerOpen"))
            {
                onDesk = false;
                inDrawer = true;
                this.GetComponent<Image>().sprite = drawerImage;
                this.transform.SetParent(drawerParent, false);
                this.transform.localScale = drawerScale;
                this.transform.rotation = drawerRotation;
            }
            else
            {
                this.GetComponent<Image>().sprite = deskImage;
                this.transform.SetParent(deskParent);
                this.transform.localScale = deskScale;
            }
        }
        dragging = true;
        focused = false;
        bookContents.CloseBook();
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
                int rotationZ = Random.Range(rotateZMin, rotateZMax);
                this.transform.localPosition = new Vector3 (placementX, placementY, 0);
                drawerRotation = new Quaternion (0, 0, -rotationZ, 180);
                this.transform.rotation = drawerRotation;
                this.GetComponent<Image>().sprite = drawerImage;
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
        dragging = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SwitchDrag"))
        {
            if (dragging)
            {
                if (!onDesk)
                {
                    onDesk = true;
                   // string desiredTrigger = switchToDesk;
                   // usableDrawers.SetTrigger(desiredTrigger);
                    this.transform.rotation = deskRotation;
                    this.transform.localScale = deskScale;
                    this.transform.SetParent(deskParent, true);
                    this.GetComponent<Image>().sprite = deskImage;
                    inDrawer = false;
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("LeftDrawer"))
        {
            Debug.Log("Putting book in left drawer");
            if (onDesk)
            {
                onDesk = false;
                if (!hoverDrawers.GetCurrentAnimatorStateInfo(0).IsName("LeftDrawerHover"))
                {
                string desiredTrigger = openDrawer;
                hoverDrawers.SetTrigger(desiredTrigger);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("LeftDrawer"))
        {
            if (hoverDrawers.GetCurrentAnimatorStateInfo(0).IsName("LeftDrawerHover") && !inDrawer)
            {
                string desiredTrigger = closeDrawer;
                hoverDrawers.SetTrigger(desiredTrigger);
                onDesk = true;
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Debug.Log("Right clicked this item");
        }
        if (!dragging && onDesk)
        {
            if (!focused)
            {
                if (FocusHolders.focusSpaceOneFull && FocusHolders.focusSpaceTwoFull)
                {
                    return;
                }
                else if (eventData.button == PointerEventData.InputButton.Right && !FocusHolders.focusSpaceTwoFull)
                {
                    FocusHolders.focusSpaceTwoFull = true;
                    spaceLock.withinValidSpace = false;
                    this.transform.SetParent(focusedSpaceTwo);
                    this.GetComponent<Image>().sprite = focusedSprite;
                    focused = true;
                    this.transform.SetAsLastSibling();
                    this.transform.localScale = new Vector3(3f, 5f, 1f);
                    this.transform.localPosition = new Vector3(0, 0, 0);
                    bookContents.OpenBook();
                }
                else if (eventData.button == PointerEventData.InputButton.Right && FocusHolders.focusSpaceTwoFull && !FocusHolders.focusSpaceOneFull)
                {
                    FocusHolders.focusSpaceOneFull = true;
                    spaceLock.withinValidSpace = false;
                    this.transform.SetParent(focusedSpaceOne);
                    this.GetComponent<Image>().sprite = focusedSprite;
                    focused = true;
                    this.transform.SetAsLastSibling();
                    this.transform.localScale = new Vector3(3f, 5f, 1f);
                    this.transform.localPosition = new Vector3(0, 0, 0);
                    bookContents.OpenBook();

                }
                else if (eventData.button == PointerEventData.InputButton.Left && !FocusHolders.focusSpaceOneFull)
                {
                    FocusHolders.focusSpaceOneFull = true;
                    spaceLock.withinValidSpace = false;
                    this.transform.SetParent(focusedSpaceOne);
                    this.GetComponent<Image>().sprite = focusedSprite;
                    focused = true;
                    this.transform.SetAsLastSibling();
                    this.transform.localScale = new Vector3(3f, 5f, 1f);
                    this.transform.localPosition = new Vector3(0, 0, 0);
                    bookContents.OpenBook();
                }
                else if (eventData.button == PointerEventData.InputButton.Left && FocusHolders.focusSpaceOneFull && !FocusHolders.focusSpaceTwoFull)
                {
                    FocusHolders.focusSpaceTwoFull = true;
                    spaceLock.withinValidSpace = false;
                    this.transform.SetParent(focusedSpaceTwo);
                    this.GetComponent<Image>().sprite = focusedSprite;
                    focused = true;
                    this.transform.SetAsLastSibling();
                    this.transform.localScale = new Vector3(3f, 5f, 1f);
                    this.transform.localPosition = new Vector3(0, 0, 0);
                    bookContents.OpenBook();
                }
            }
            else if (focused)
            {
                if (this.transform.parent.name == "FocusSpaceOne")
                {
                    FocusHolders.focusSpaceOneFull = false;
                }
                if (this.transform.parent.name == "FocusSpaceTwo")
                {
                    FocusHolders.focusSpaceTwoFull = false;
                }
                this.transform.SetParent(deskParent);
                this.GetComponent<Image>().sprite = deskImage;
                focused = false;
                this.transform.localScale = deskScale;
                    this.transform.localPosition = new Vector3(-30, -200, 0);
                
                spaceLock.withinValidSpace = true;
                bookContents.CloseBook();
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
