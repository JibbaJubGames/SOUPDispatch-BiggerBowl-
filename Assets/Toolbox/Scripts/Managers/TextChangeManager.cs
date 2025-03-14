using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextChangeManager : MonoBehaviour
{

    [SerializeField]
    private TMP_Text textToChange;

    [SerializeField]
    private string textToChangeOriginalText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeText(string newText)
    {
        if (textToChange.text != null)
        {
            textToChangeOriginalText = textToChange.text.ToString();
            textToChange.text = newText;
        }
        else
        {
            textToChange.text = newText;
        }
    }

    public void ResetText()
    {
        if (textToChangeOriginalText != null)
        {
            textToChange.text = textToChangeOriginalText;
        }
        else
        {
            textToChange.text = null;
        }
    }
}
