using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class NameTagScript : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerClickHandler
{
    public GameObject textInput;
    public TMP_InputField nameTagInputField;
    public bool onDesk;
    public bool droppedTag;
    public float spinAmount;
    public float shrinkAmount;
    private bool dragging;
    public Transform notDesk;
    public Transform comicPanel;
    public bool blank;
    public GameObject hand;

    public Animator playerBubbles;
    public Animator bozmunBubble;

    [Header("Only for blank tag")]
    public NameTagResponsesScript nameResponse;
    public void OnBeginDrag(PointerEventData eventData)
    {
        dragging = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
        if (blank)
        {
        nameTagInputField.enabled = true;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        dragging = false;
        if (!onDesk)
        {
            Debug.Log("Dropped name tag");
            spinAmount = Random.Range(-2f, 2f);
            droppedTag = true;
            this.transform.SetParent(notDesk, true);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Desk")
        {
            onDesk = false;
            if (!dragging)
            {
            spinAmount = Random.Range(-2f, 2f);
            droppedTag = true;
            this.transform.SetParent(notDesk, true);
            }
            
        }
        else if (collision.name == "NotDesk")
        {
            onDesk = true;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (droppedTag)
        {
            transform.Rotate(0, 0, spinAmount);
            this.transform.localScale -= new Vector3(shrinkAmount, shrinkAmount, shrinkAmount);
        }
        if (this.transform.localScale == new Vector3(0.6f, 0.6f, 0.6f))
        {
            this.GetComponent<BoxCollider2D>().enabled = false;
            droppedTag = false;
            this.gameObject.GetComponent<NameTagScript>().enabled = false;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (onDesk && blank && !NameTagSelectedScript.choseName && !dragging)
        {
            NameTagSelectedScript.choseName = true;
            NameTagSelectedScript.chosenNameTag = this.gameObject;
            nameTagInputField.enabled = true;
            nameTagInputField.Select();
            this.GetComponent<BoxCollider2D>().isTrigger = true;
            this.transform.localScale = Vector3.one * 3;
            this.transform.SetSiblingIndex(this.transform.parent.childCount - 3);
            hand.SetActive(false);
        }
        else if (!blank && !NameTagSelectedScript.choseName && !dragging)
        {
            NameTagSelectedScript.choseName = true;
            NameTagSelectedScript.chosenNameTag = this.gameObject;
            nameTagInputField.enabled = true;
            this.GetComponent<BoxCollider2D>().isTrigger = true;
            this.transform.localScale = Vector3.one * 3;
            this.transform.SetSiblingIndex(this.transform.parent.childCount - 3);
            hand.SetActive(false);
            nameResponse.IdentityTheft(nameTagInputField.text);
            bozmunBubble.SetTrigger("BozmunIn");
            playerBubbles.SetTrigger("PlayerBubblesCall");
        }
    }

    public void UpdatePlayerName()
    {
        GameManager.PlayerName = nameTagInputField.text;
        nameResponse.specialResponse = false;
        nameResponse.NameTagBackForth(nameTagInputField.text.ToString());
        bozmunBubble.SetTrigger("BozmunIn");
        playerBubbles.SetTrigger("PlayerBubblesCall");
    }
}
