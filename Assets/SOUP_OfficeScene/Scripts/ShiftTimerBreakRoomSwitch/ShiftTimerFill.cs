using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShiftTimerFill : MonoBehaviour
{
    [SerializeField] private Image fillBar;
    [SerializeField] public static bool clockedIn;
    [SerializeField] private bool hadBreak;
    [SerializeField] private int fillSpeed;
    [SerializeField] private Animator breakroomSwitch;
    [SerializeField] private Animator drawerCheck;
    public TMP_Text date;
    public TMP_Text dayCount;
    public CurrentDateUpdater currentDateUpdater;

    public Image lunchIcon;
    public Image homeIcon;
    public Sprite activeLunchBreak;
    public Sprite activeHomeIcon;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SetDate", .1f);
    }

    private void SetDate()
    {
        dayCount.text = $"{CurrentDateUpdater.currentDay.ToString()}";
        date.text = $"{currentDateUpdater.daysOfWeek[CurrentDateUpdater.currentDay]}";
    }

    // Update is called once per frame
    void Update()
    {
        if (clockedIn)
        {
            fillBar.fillAmount += Time.deltaTime / fillSpeed;     
        }
        if (fillBar.fillAmount >= 0.47f && fillBar.fillAmount <= 0.55f && !hadBreak)
        {       
            clockedIn = false;
            if (!GenerateDispatchScript.dispatchActive && drawerCheck.GetCurrentAnimatorStateInfo(0).IsName("IDLE"))
            {
            breakroomSwitch.SetTrigger("GoBreak");
            hadBreak = true;
            lunchIcon.sprite = activeLunchBreak;
            }
            
        }
        if (clockedIn && fillBar.fillAmount >= 0.98f)
        {
            if (!GenerateDispatchScript.dispatchActive && drawerCheck.GetCurrentAnimatorStateInfo(0).IsName("IDLE"))
            {
                clockedIn = false;
                PreAlphaOnly_TurnOnPlaytestSheets.TurnOnDisc();
            }
            homeIcon.sprite = activeHomeIcon;
        }
    }

    public void ClockIn()
    {
        //fillSpeed = Random.Range(360, 481);
        clockedIn = true;
    }
    public void ClockOut()
    {
        if (!clockedIn && fillBar.fillAmount >= 0.98f)
        {
            clockedIn = false;
            SceneManager.LoadScene("OfficeToApartment");
        }
    }
    public void BreakOver()
    {
        clockedIn = true;
    }

}
