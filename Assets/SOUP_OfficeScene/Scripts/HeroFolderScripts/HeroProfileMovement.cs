using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class HeroProfileMovement : MonoBehaviour,IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    [Header("Desk and Drawer Switch")]
    [SerializeField] private Animator usableDrawers;
    [SerializeField] private Animator hoverDrawers;
    [SerializeField] private bool onDesk;
    [SerializeField] private bool inDrawer;
    [SerializeField] private string switchToDesk;
    [SerializeField] private string openDrawer;
    [SerializeField] private string closeDrawer;
    [SerializeField] private GameObject folderCover;
    [SerializeField] private GameObject folderOpen;

    [Header("Desk Info")]
    [SerializeField] private Vector3 deskScale;
    [SerializeField] private Quaternion deskRotation;
    [SerializeField] private Transform deskParent;
    [SerializeField] private UsableSpaceScript spaceLock;
    [SerializeField] private bool inTube;
    [SerializeField] private Transform offScreenHolder;

    [Header("ProfileReset")]
    [SerializeField] private Transform heroFolders;

    [Header("Focused Info")]
    [SerializeField] private Transform focusedSpaceOne;
    [SerializeField] private Transform focusedSpaceTwo;
    [SerializeField] private bool dragging;
    [SerializeField] private bool focused;

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
            this.transform.SetParent(deskParent);
            this.transform.localScale = deskScale;
            folderOpen.SetActive(false);
            folderCover.SetActive(true);
        }
        dragging = true;
        focused = false;
        if (!onDesk)
        {
            onDesk = true;
            //string desiredTrigger = switchToDesk;
           // usableDrawers.SetTrigger(desiredTrigger);
            this.transform.rotation = deskRotation;
            this.transform.localScale = deskScale;
            this.transform.SetParent(deskParent, true);
            inDrawer = false;
            for (int i = 0; i < heroFolders.childCount; i++)
            {
                heroFolders.GetChild(i).GetComponent<HeroFolderHoverScript>().heroProfileShowing = false;
            }
            HeroHolderLockScript.heroLocked = false;
            Destroy(HeroHolderLockScript.lockedHero);
            HeroHolderLockScript.lockedHero = null;
            folderCover.SetActive(true);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        dragging = true;
        this.transform.position = Input.mousePosition;
        this.transform.SetAsLastSibling();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!onDesk && !inDrawer && !inTube)
        {
            this.transform.GetChild(1).GetComponent<ReplaceHeroFolderToDrawer>().ReplaceInDrawer(heroFolders);
            Debug.Log(this.transform.GetChild(1).name);
            Destroy(this.gameObject);
        }
        else if (inTube)
        {
            DispatchTubeContentsChecker.profileGiven = true;
            this.gameObject.transform.position = offScreenHolder.position;
            this.transform.SetParent(offScreenHolder.gameObject.transform.parent, true);
        }
        else if (!spaceLock.withinValidSpace)
        {
            this.transform.position = spaceLock.draggingPosition;
        }
        dragging = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
     //  if (collision.CompareTag("SwitchDrag"))
     //  {
     //      if (!onDesk)
     //      {
     //          onDesk = true;
     //          string desiredTrigger = switchToDesk;
     //          usableDrawers.SetTrigger(desiredTrigger);
     //          this.transform.rotation = deskRotation;
     //          this.transform.localScale = deskScale;
     //          this.transform.SetParent(deskParent, true);
     //          inDrawer = false;
     //          for (int i = 0;  i < heroFolders.childCount; i++) 
     //          {
     //              heroFolders.GetChild(i).GetComponent<HeroFolderHoverScript>().heroProfileShowing = false;
     //          }
     //          HeroHolderLockScript.heroLocked = false;
     //          folderCover.SetActive(true);
     //      }
     //  }
        if (collision.CompareTag("DispatchTube") && onDesk)
        {
            Debug.Log("Trying to dispatch a hero");
            onDesk = false;
            inTube = true;
            collision.gameObject.GetComponent<CompareHeroToSheet>().heroSheet = this.gameObject;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("RightDrawer"))
        {
            if (onDesk)
            {
                onDesk = false;
                if (!hoverDrawers.GetCurrentAnimatorStateInfo(0).IsName("RightDrawerHover"))
                {
                    string desiredTrigger = openDrawer;
                    hoverDrawers.SetTrigger(desiredTrigger);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("RightDrawer"))
        {
            if (hoverDrawers.GetCurrentAnimatorStateInfo(0).IsName("RightDrawerHover") && !inDrawer)
            {
                string desiredTrigger = closeDrawer;
                hoverDrawers.SetTrigger(desiredTrigger);
                onDesk = true;
            }
        }
        else if (collision.CompareTag("DispatchTube") && this.transform.parent != offScreenHolder.gameObject.transform.parent)
        {
            Debug.Log("Changed mind about dispatching hero");
            onDesk = true;
            inTube = false;
            collision.gameObject.GetComponent<CompareHeroToSheet>().heroSheet = null;
            this.transform.SetParent(deskParent, true);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
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
                    folderOpen.SetActive(true);
                    folderCover.SetActive(false);
                    focused = true;
                    this.transform.SetAsLastSibling();
                    this.transform.localScale = new Vector3(1.25f, 2.5f, 1f);
                    this.transform.localPosition = new Vector3(0, 0, 0);
                }
                else if (eventData.button == PointerEventData.InputButton.Left && !FocusHolders.focusSpaceOneFull)
                {
                    FocusHolders.focusSpaceOneFull = true;
                    spaceLock.withinValidSpace = false;
                    this.transform.SetParent(focusedSpaceOne);
                    folderOpen.SetActive(true);
                    folderCover.SetActive(false);
                    focused = true;
                    this.transform.SetAsLastSibling();
                    this.transform.localScale = new Vector3(1.25f, 2.5f, 1f);
                    this.transform.localPosition = new Vector3(0, 0, 0);
                }
                else if (eventData.button == PointerEventData.InputButton.Right && FocusHolders.focusSpaceTwoFull && !FocusHolders.focusSpaceOneFull)
                {
                    FocusHolders.focusSpaceOneFull = true;
                    spaceLock.withinValidSpace = false;
                    this.transform.SetParent(focusedSpaceOne);
                    folderOpen.SetActive(true);
                    folderCover.SetActive(false);
                    focused = true;
                    this.transform.SetAsLastSibling();
                    this.transform.localScale = new Vector3(1.25f, 2.5f, 1f);
                    this.transform.localPosition = new Vector3(0, 0, 0);
                }
                else if (eventData.button == PointerEventData.InputButton.Left && FocusHolders.focusSpaceOneFull && !FocusHolders.focusSpaceTwoFull)
                {
                    FocusHolders.focusSpaceTwoFull = true;
                    spaceLock.withinValidSpace = false;
                    this.transform.SetParent(focusedSpaceTwo);
                    folderOpen.SetActive(true);
                    folderCover.SetActive(false);
                    focused = true;
                    this.transform.SetAsLastSibling();
                    this.transform.localScale = new Vector3(1.25f, 2.5f, 1f);
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
                this.transform.SetParent(deskParent);
                folderOpen.SetActive(false);
                folderCover.SetActive(true);
                focused = false;
                this.transform.localScale = deskScale;
                this.transform.position = spaceLock.draggingPosition;
                spaceLock.withinValidSpace = true;
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
