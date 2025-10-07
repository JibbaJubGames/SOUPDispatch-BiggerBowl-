using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreAlphaOnly_DiscordLink : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SendToDiscord(string url)
    {
        Application.OpenURL(url);
        Debug.Log("Player sent to" + url);
    }
}
