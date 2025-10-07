using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameTagPanelSwitchScript : MonoBehaviour
{
    public GameObject nameTagPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnOnPanel()
    {
        nameTagPanel.SetActive(true);
    }

    public void TurnOffPanel() 
    {
        nameTagPanel.SetActive(false);
    }
}
