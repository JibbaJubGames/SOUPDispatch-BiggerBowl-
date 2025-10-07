using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperatorsOnDutyList : MonoBehaviour
{
    [SerializeField] public static int[] operatorNumbers;
    // Start is called before the first frame update
    void Start()
    {
        System.Array.Resize(ref operatorNumbers, 15);
        SetOperators();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetOperators()
    {
        for (int i = 0; i < operatorNumbers.Length; i++)
        {
            operatorNumbers[i] = Random.Range(1000,10000);
        }
    }
}
