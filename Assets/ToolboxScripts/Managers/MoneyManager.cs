using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public int playerCashCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdatePiggyBank()
    {
        playerCashCount += DispatchManager.perfectDispatchCount * 25;
        playerCashCount += DispatchManager.goodDispatchCount * 10;
        playerCashCount -= DispatchManager.badDispatchCount * 10;
    }
}
