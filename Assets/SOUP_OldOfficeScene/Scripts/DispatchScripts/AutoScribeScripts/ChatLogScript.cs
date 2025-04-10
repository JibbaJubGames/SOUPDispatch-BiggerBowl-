using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatLogScript : MonoBehaviour
{
    public RectTransform ChatLog;

    public int messagesSent = 0;

    public AutoscribeConvoScript convoScript;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseChatSize(float growthSize)
    {
        messagesSent++;
        ChatLog.sizeDelta += new Vector2(0, growthSize);
    }

    public void ResetChatSize()
    {
        ChatLog.sizeDelta = new Vector2(0, 0);
        messagesSent = 0;
    }
}
