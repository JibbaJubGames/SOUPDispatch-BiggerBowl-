using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomLocationScript : MonoBehaviour
{
    [SerializeField] Image chosenLocation;
    [SerializeField] private GameObject[] columns; 
    [SerializeField] private int columnCount = 10;
    [SerializeField] private int rowCount = 6;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RandomDispatchChoice()
    {
        if (chosenLocation != null)
        {
            chosenLocation.color = Color.white;
        }
        int columnChoice = Random.Range(0, columnCount);
        int rowChoice = Random.Range(0, rowCount);
        chosenLocation = columns[columnChoice].transform.GetChild(rowChoice).GetComponent<Image>();
        chosenLocation.color = Color.red;
    }
}
