using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DispatchTimerBar : MonoBehaviour
{
    public Slider dispatchTimer;
    public int testEnergyLevel;

    public DispatchNotificationScript dispatchStatus;
    // Start is called before the first frame update
    void Start()
    {
        dispatchTimer = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dispatchStatus.dispatchActive && dispatchTimer.value >= 0)
        {
            dispatchTimer.value -= Time.deltaTime / (GameManager.playerEnergy * 12);
            if (dispatchTimer.value <= 0) dispatchStatus.EndedDispatch();
        }
        else return;
    }

    public void ResetDispatchTimer()
    {
        dispatchTimer.value = 1;
    }
}
