using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DispatchDateDetails : MonoBehaviour
{
    [SerializeField] public TMP_Text dateText;
    [SerializeField] public string[] daysOfTheWeek;

    public DispatchInfoSet dispatchPage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CorrectDate()
    {
        dateText.text = daysOfTheWeek[CurrentDateUpdater.currentDay];
        dispatchPage.dateCorrect = true;
    }

    public void IncorrectDate()
    {
        int randomDay = Random.Range(0, daysOfTheWeek.Length);
        if (randomDay == CurrentDateUpdater.currentDay)
        {
            IncorrectDate();
        }
        else
        {
            dateText.text = daysOfTheWeek[randomDay];
        }
    }
}
