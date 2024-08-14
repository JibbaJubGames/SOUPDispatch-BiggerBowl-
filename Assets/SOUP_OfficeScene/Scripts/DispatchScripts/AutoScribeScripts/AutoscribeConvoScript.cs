using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AutoscribeConvoScript : MonoBehaviour
{
    [Header("Set Up Info")]
    public List<GameObject> messageList;

    public Transform chatLogTransform;

    public GameObject npcMessage;
    public GameObject playerMessage;
    public GameObject messageToSend;

    public ChatLogScript chatLogScript;

    public bool playerMessageTime;

    

    //In call script have a string holder called textforconvo or something of the like,
    //set message contents in SendMessageMethod to callscript.textforconvo

    public TMP_Text messageContents;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SendAutoscribeMessage(string messageText)
    {
        if (!playerMessageTime)
        {
            messageToSend = npcMessage;
            Invoke("GrowChatBox", 0.1f);
            messageToSend = Instantiate(npcMessage, chatLogTransform);
            messageContents = messageToSend.GetComponentInChildren<TMP_Text>();
            messageContents.text = (messageText);
            messageList.Add(messageToSend);
        }
        else if (playerMessageTime)
        {
            messageToSend = playerMessage;
            Invoke("GrowChatBox", 0.1f);
            messageToSend = Instantiate(playerMessage, chatLogTransform);
            messageContents = messageToSend.GetComponentInChildren<TMP_Text>();
            messageContents.text = (messageText);
            messageList.Add(messageToSend);
        }


    }

    private void GrowChatBox()
    {
        Debug.Log("Easy to find " + messageToSend.GetComponent<RectTransform>().rect.height);
        chatLogScript.IncreaseChatSize (messageToSend.GetComponent<RectTransform>().rect.height + 30);
    }

    public void ResetConvo()
    {
        for (int i = 0; i < messageList.Count; i++)
        {
            Debug.Log("Destroying " + messageList[i]);
            Destroy(messageList[i].gameObject);
        }
        messageList.Clear();
        chatLogScript.ResetChatSize();
        messageToSend = null;
    }
}
