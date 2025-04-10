using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomLocationScript : MonoBehaviour
{
    [SerializeField] private GameObject dispatchInfoTop;
    [SerializeField] private GameObject dispatchInfoBottom;
    [SerializeField] Image chosenLocation;
    [SerializeField] private GameObject[] columns; 
    [SerializeField] private int columnCount = 10;
    [SerializeField] private int rowCount = 6;
    [SerializeField] private int rowChoice;
    [SerializeField] private int columnChoice;
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
        columnChoice = Random.Range(0, columnCount);
        rowChoice = Random.Range(0, rowCount);
        chosenLocation = columns[columnChoice].transform.GetChild(rowChoice).GetComponent<Image>();
        chosenLocation.color = Color.red;
        chosenLocation.GetComponent<RandomCallerDispatchLocationCheck>().dispatchCallerHere = true;
    }

    public void AnsweredCall()
    {
        if (rowChoice < 3)
        {
            Instantiate(dispatchInfoTop, chosenLocation.transform);
        }
        else if (rowChoice >= 3)
        {
            Instantiate(dispatchInfoBottom, chosenLocation.transform);
        }
    }

    public void DispatchOver()
    {
        Destroy(chosenLocation.transform.GetChild(0).gameObject);
        chosenLocation.GetComponent<RandomCallerDispatchLocationCheck>().dispatchCallerHere = false;
    }
}
