using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DayBlockOffCheck : MonoBehaviour
{
    public int activeDay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        if (GameManager.DayCounter < activeDay)
        {
            this.gameObject.SetActive(false);
        }
    }
}
