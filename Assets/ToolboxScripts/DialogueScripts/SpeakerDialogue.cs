using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpeakerDialogue : MonoBehaviour
{
    [Header("Dialogue Setup")]
    public TMP_Text speakerText;
    public string[] speakerDialogue;
    public int dialogueCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextLine()
    {
        dialogueCount++;
        speakerText.text = speakerDialogue[dialogueCount];
    }

    public void JumpTo(int targetLine)
    {
        speakerText.text = speakerDialogue[targetLine];
    }
}
