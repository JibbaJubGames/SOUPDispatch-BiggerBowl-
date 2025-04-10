using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateBackgroundScript : MonoBehaviour
{
    public Image background;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetBackground(int onOrOff)
    {
        if (onOrOff == 0) background.gameObject.SetActive(false);

        if (onOrOff == 1) background.gameObject.SetActive(true);
    }
}
