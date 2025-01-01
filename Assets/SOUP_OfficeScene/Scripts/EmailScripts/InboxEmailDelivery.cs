using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InboxEmailDelivery : MonoBehaviour
{

    [SerializeField]
    public Transform inboxContent;
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
        Debug.Log($"Added {InboxFiller.inboxPile.Peek()} to actual inbox");
        Instantiate (InboxFiller.inboxPile.Pop(), inboxContent);
        }
        Debug.Log("All emails already in inbox");
    }
}
