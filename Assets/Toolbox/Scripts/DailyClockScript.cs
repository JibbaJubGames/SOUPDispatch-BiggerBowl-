using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DailyClockScript : MonoBehaviour
{
    public static bool clockedIn = false;

    public bool timerStarted;
    public RectTransform sunCircle;
    public float degreesFromStartToFinish;
    public int dayLengthInSeconds;
    public float timeRemaining;

    public GameObject endShiftButton;
    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = dayLengthInSeconds;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerStarted && timeRemaining > 0)
        {
            ClockIn();
            timeRemaining -= Time.deltaTime;
            float degreesToMove = degreesFromStartToFinish / dayLengthInSeconds;
            sunCircle.Rotate(0, 0, -degreesToMove * Time.deltaTime);
        }
        else if (timerStarted && timeRemaining <= 0)
        {
            clockedIn = false;
            endShiftButton.gameObject.SetActive(true);
        }
    }
    public void StartTimer()
    {
        timerStarted = true;
    }

    static void ClockIn()
    {
        clockedIn = true;
    }

}
