using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmailManager : MonoBehaviour
{
    public static Dictionary <int, GameObject> emailInbox = new Dictionary <int, GameObject> ();
    public static Dictionary <int, GameObject> junkInbox = new Dictionary <int, GameObject> ();
    public static int storyEmails;
    public static int junkEmails;

    public GameObject[] storyEmailPrefabs;
    public GameObject[] junkEmailPrefabs;

    public static EmailManager EmailManagerInstance;

    // Start is called before the first frame update
    void Awake()
    {
        if (EmailManagerInstance != null && EmailManagerInstance != this)
        {
            Destroy(this);
        }
        else
        {
            EmailManagerInstance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void SetEmailInbox()
    {
        storyEmails = GameManager.emailCount;
        Debug.Log($"We currently have {storyEmails} emails in our inbox");
        for (int i = 0; i < storyEmails;  i++)
        {
            if (emailInbox.ContainsKey(i))
            {
                Debug.Log("Our inbox already contains Email " +  i);
                InboxFiller.AddToInboxPile(EmailManagerInstance.storyEmailPrefabs[i]);
                return;
            }
            else
            {
            emailInbox.Add (i, EmailManagerInstance.storyEmailPrefabs[i]);
            Debug.Log($"This would add story email '{EmailManagerInstance.storyEmailPrefabs[i]}' to the inbox");
            InboxFiller.AddToInboxPile(EmailManagerInstance.storyEmailPrefabs[i]);
            }
        }
    }  
    public void SetJunkInbox()
    {
        for (int i = 0; i < junkEmails;  i++)
        {
            junkInbox.Add (i, junkEmailPrefabs[i]);
            Debug.Log($"This would add junk email '{junkEmailPrefabs[i]}' to the junk mail inbox");
        }
    }

    public void sendStoryEmail()
    {
        emailInbox.Add(storyEmails, storyEmailPrefabs[storyEmails]);
        storyEmails++;
        GameManager.emailCount++;
        Debug.Log("Story email count is now" + storyEmails);
        SaveAndLoad.SaveToJson();
    }
}
