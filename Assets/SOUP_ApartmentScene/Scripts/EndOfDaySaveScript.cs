using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfDaySaveScript : MonoBehaviour
{
    public GameManager GameManager;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndOfDaySave()
    {
        GameManager.NextDay();
    }
}
