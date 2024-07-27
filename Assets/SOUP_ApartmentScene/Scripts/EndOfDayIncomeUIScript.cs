using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndOfDayIncomeUIScript : MonoBehaviour
{

    [Header("Dispatch Quality Counts")]
    public TMP_Text perfectDispatches;
    public TMP_Text goodDispatches;
    public TMP_Text badDispatches;
    public TMP_Text bonuses;
    public TMP_Text piggyBank;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DailyIncomeDisplay()
    {
        perfectDispatches.text = $"{DispatchManager.perfectDispatchCount} X $250";
        goodDispatches.text = $"{DispatchManager.goodDispatchCount} X $100";
        badDispatches.text = $"{DispatchManager.badDispatchCount} X -$100";
        MoneyManager.UpdatePiggyBank();
        piggyBank.text = $"${MoneyManager.playerCashCount}";
    }
}
