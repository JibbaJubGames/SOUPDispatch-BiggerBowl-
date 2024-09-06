using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static int playerCashCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void UpdatePiggyBank()
    {
        playerCashCount += DispatchManager.perfectDispatchCount * 250;
        playerCashCount += DispatchManager.goodDispatchCount * 100;
        playerCashCount -= DispatchManager.badDispatchCount * 100;
    }
}
