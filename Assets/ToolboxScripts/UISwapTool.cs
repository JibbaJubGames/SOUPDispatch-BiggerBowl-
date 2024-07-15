using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISwapTool : MonoBehaviour
{
    [Header ("UI Pieces")]
    [SerializeField] private GameObject UIToClose;
    [SerializeField] private GameObject UIToOpen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UISwap()
    {
        UIToClose.SetActive (false);
        UIToOpen.SetActive (true);
    }

    public void UIOpen()
    {
        UIToOpen.SetActive (true);
    }

    public void UIClose()
    {
        UIToOpen.SetActive (false);
    }
}
