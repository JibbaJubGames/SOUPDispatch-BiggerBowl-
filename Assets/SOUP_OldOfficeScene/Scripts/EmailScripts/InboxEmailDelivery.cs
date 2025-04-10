using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InboxEmailDelivery : MonoBehaviour
{

    [SerializeField]
    public Transform inboxContent;

    public GameObject topEmail;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        while (InboxFiller.inboxPile.Count > 0) 
        {
        topEmail=InboxFiller.inboxPile.Peek();
        Debug.Log($"Added {InboxFiller.inboxPile.Peek()} to actual inbox");
        Instantiate (InboxFiller.inboxPile.Pop(), inboxContent);
            //topEmail.transform.position = new Vector3(inboxContent.position.x, inboxContent.position.y, inboxContent.position.z);
            inboxContent.GetComponent<RectTransform>().sizeDelta += new Vector2(0, topEmail.GetComponent<RectTransform>().rect.height);
        }
        Debug.Log("All emails already in inbox");
    }
}
