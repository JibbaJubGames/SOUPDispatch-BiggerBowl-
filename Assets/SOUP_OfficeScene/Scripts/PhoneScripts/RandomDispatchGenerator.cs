using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomDispatchGenerator : MonoBehaviour
{
    [Header("Subject")]
    public string[] SubjectOptions;
    public int SubjectChoice;

    [Header("What Happened")]
    public string[] ProblemOptions;
    public int ProblemChoice;

    [Header("Where")]
    public string[] LocationOptions;
    public int LocationChoice;

    [Header("Dispatch")]
    public TMP_Text DispatchCall;

    public void GenerateDispatch()
    {
        SubjectChoice = Random.Range(0, SubjectOptions.Length);

        ProblemChoice = Random.Range(0, ProblemOptions.Length);

        LocationChoice = Random.Range(0, LocationOptions.Length);

        DispatchCall.text = $"{SubjectOptions[SubjectChoice]} {ProblemOptions[ProblemChoice]} {LocationOptions[LocationChoice]}";
    }
}
