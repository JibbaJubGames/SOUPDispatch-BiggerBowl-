using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InboxFiller : MonoBehaviour
{
    public static Stack <GameObject> inboxPile = new Stack<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void AddToInboxPile(GameObject emailPrefabToAdd)
    {
        Debug.Log("We make it here in the inbox filler script");
        inboxPile.Push(emailPrefabToAdd);
        Debug.Log(inboxPile.Peek());
    }
}
