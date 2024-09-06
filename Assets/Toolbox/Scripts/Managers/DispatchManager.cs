using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispatchManager : MonoBehaviour
{
    public static int perfectDispatchCount;
    public static int goodDispatchCount;
    public static int badDispatchCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void DispatchCountReset()
    {
        perfectDispatchCount = 0;
        goodDispatchCount = 0;
        badDispatchCount = 0;
    }

    public static void PerfectDispatch()
    {
        perfectDispatchCount++;
    }

    public static void GoodDispatch()
    {
        goodDispatchCount++;
    }

    public static void BadDispatch()
    {
        badDispatchCount++;
    }
}
