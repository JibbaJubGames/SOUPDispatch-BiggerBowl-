using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentDateUpdater : MonoBehaviour
{
    [SerializeField] public string[] daysOfWeek;
    public static int currentDay;
    // Start is called before the first frame update
    void Start()
    {
        int i = GameManager.DayCounter;
        currentDay = i;
        if (i > 28) currentDay = i - 28;
        else if (i > 21) currentDay = i - 21;
        else if (i > 14) currentDay = i - 14;
        else if (i > 7) currentDay = i - 7;
        Debug.Log("called every morning; the day today is " + daysOfWeek[currentDay]);
        Debug.Log("The day today is " + currentDay);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Awake()
    {
    }
}
