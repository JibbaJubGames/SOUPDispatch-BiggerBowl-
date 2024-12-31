using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointyTutorialScripts : MonoBehaviour
{
    public Animator thisPointyAnim;
    public TMP_Text thisPointySpeech;

    public string[] pointyAnimTriggers;
    public string[] pointySpeechScript;
    public int currentPointyAnim = 0;
    public int currentPointySpeechIndex = 0;

    public GameObject[] objectsToActivateForTutorial;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextPointyPoint()
    {
        currentPointyAnim++;
        thisPointyAnim.SetTrigger(pointyAnimTriggers[currentPointyAnim]);
    }

    public void PrevPointyPoint()
    {
        currentPointyAnim--;
        thisPointyAnim.SetTrigger(pointyAnimTriggers[currentPointyAnim]);
    }

    public void NextPointyTalkPoint()
    {
        currentPointySpeechIndex++;
        thisPointySpeech.text = pointySpeechScript[currentPointySpeechIndex];
    }

    public void ActivateNonPointyGameObject(int ObjectPosition)
    {
        objectsToActivateForTutorial[ObjectPosition].SetActive(true);
    }

    public void DeactivateNonPointyGameObject(int ObjectPosition)
    {
        objectsToActivateForTutorial[ObjectPosition].SetActive(false);
    }
}
