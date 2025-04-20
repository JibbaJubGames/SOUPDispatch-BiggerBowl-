using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DispatchMovementScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Sprite deskSprite;
    [SerializeField] private UsableSpaceScript spaceLock;
    [SerializeField] private Transform deskSpace;
    public void OnBeginDrag(PointerEventData eventData)
    {
        this.GetComponent<Image>().sprite = deskSprite;
        this.transform.SetParent(deskSpace.transform, true);
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = Input.mousePosition;
        this.transform.SetAsLastSibling();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!spaceLock.withinValidSpace)
        {
            this.transform.position = spaceLock.draggingPosition;
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
