using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DispatchMovementScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    [SerializeField] private Sprite deskSprite;
    [SerializeField] private Sprite focusedSprite;
    [SerializeField] private UsableSpaceScript spaceLock;
    [SerializeField] private Transform deskSpace;
    [SerializeField] private Transform focusedSpaceOne;
    [SerializeField] private Transform focusedSpaceTwo;

    [SerializeField] private bool inTube;
    [SerializeField] private bool focused;
    [SerializeField] private bool dragging;
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (this.transform.parent.name == "FocusSpaceOne")
        {
            FocusHolders.focusSpaceOneFull = false;
        }
        if (this.transform.parent.name == "FocusSpaceTwo")
        {
            FocusHolders.focusSpaceTwoFull = false;
        }
        dragging = true;
        focused = false;
        this.GetComponent<Image>().sprite = deskSprite;
        this.transform.SetParent(deskSpace);
        this.transform.localScale = Vector3.one;
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = Input.mousePosition;
        this.transform.SetAsLastSibling();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (inTube)
        {
            DispatchTubeContentsChecker.dispatchSheetGiven = true;
            Destroy (this.gameObject);
        }
        else if (!spaceLock.withinValidSpace)
        {
            this.transform.position = spaceLock.draggingPosition;
        }
        dragging = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!dragging)
        {
            if (!focused)
            {
                if (FocusHolders.focusSpaceOneFull && FocusHolders.focusSpaceTwoFull)
                {
                    return;
                }
                else if (FocusHolders.focusSpaceOneFull && !FocusHolders.focusSpaceTwoFull)
                {
                    FocusHolders.focusSpaceTwoFull = true;
                    spaceLock.withinValidSpace = false;
                    this.transform.SetParent(focusedSpaceTwo);
                    this.GetComponent<Image>().sprite = focusedSprite;
                    focused = true;
                    this.transform.SetAsLastSibling();
                    this.transform.localScale = new Vector3(3f, 5f, 1f);
                    this.transform.localPosition = new Vector3(0, 0, 0);
                }
                else if (!FocusHolders.focusSpaceOneFull)
                {
                    FocusHolders.focusSpaceOneFull = true;
                    spaceLock.withinValidSpace = false;
                    this.transform.SetParent(focusedSpaceOne);
                    this.GetComponent<Image>().sprite = focusedSprite;
                    focused = true;
                    this.transform.SetAsLastSibling();
                    this.transform.localScale = new Vector3(3f, 5f, 1f);
                    this.transform.localPosition = new Vector3(0, 0, 0);
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
                this.transform.SetParent(deskSpace);
                this.GetComponent<Image>().sprite = deskSprite;
                focused = false;
                this.transform.localScale = Vector3.one;
                this.transform.position = spaceLock.draggingPosition;
                spaceLock.withinValidSpace = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DispatchTube"))
        {
            inTube = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("DispatchTube"))
        {
            inTube = false;
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
