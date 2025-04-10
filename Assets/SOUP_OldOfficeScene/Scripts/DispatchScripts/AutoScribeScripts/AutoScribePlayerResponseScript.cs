using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoScribePlayerResponseScript : MonoBehaviour
{
    [SerializeField] private int currentQ;
    [SerializeField] private GameObject[] questionButtons;
    [SerializeField] private GameObject OptionA;
    [SerializeField] private GameObject OptionB;
    [SerializeField] private GameObject PreviousButton;
    [SerializeField] private Animator questionsAnim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PreviousOption()
    {
        Debug.Log($"Asking question number{currentQ}");
        if (currentQ == 0) 
        {
            if (PreviousButton != null)
            {
            Instantiate(PreviousButton, OptionA.transform);
            }
            Instantiate(questionButtons[questionButtons.Length-1], OptionB.transform);
            PreviousButton = questionButtons[questionButtons.Length - 1];
            currentQ = questionButtons.Length - 1;
        }
        else if (currentQ > 0)
        {
            if (PreviousButton != null)
            {
                Instantiate(PreviousButton, OptionA.transform);
            }
            Instantiate(questionButtons[currentQ-1], OptionB.transform);
            PreviousButton = questionButtons[currentQ - 1];
            currentQ--;
        }
        questionsAnim.SetTrigger("AskedNext");
    }

    public void NextOption()
    {

        Debug.Log($"Asking question number{currentQ}");
        if (currentQ == questionButtons.Length-1)
        {
            if (PreviousButton != null)
            {
                Instantiate(PreviousButton, OptionB.transform);
            }
            Instantiate(questionButtons[0], OptionA.transform);
            PreviousButton = questionButtons[0];
            currentQ = 0;
        }
        else if (currentQ < questionButtons.Length-1)
        {
            if (PreviousButton != null)
            {
                Instantiate(PreviousButton, OptionB.transform);
            }
            Instantiate(questionButtons[currentQ+1], OptionA.transform);
            PreviousButton = questionButtons[currentQ + 1];
            currentQ++;
        }
        questionsAnim.SetTrigger("AskedPrev");
    }

    public void InitializeOption()
    {

        Debug.Log($"Asking question number{currentQ}");
        if (currentQ == questionButtons.Length-1)
        {
            if (PreviousButton != null)
            {
                Instantiate(PreviousButton, OptionB.transform);
            }
            Instantiate(questionButtons[0], OptionA.transform);
            PreviousButton = questionButtons[0];
            currentQ = 0;
        }
        else if (currentQ < questionButtons.Length-1)
        {
            if (PreviousButton != null)
            {
                Instantiate(PreviousButton, OptionB.transform);
            }
            Instantiate(questionButtons[currentQ+1], OptionA.transform);
            PreviousButton = questionButtons[currentQ + 1];
            currentQ++;
        }
    }

    public void AskedWhat()
    {
        SelectedDispatchDetails.FiguredOutWhat();
    }

    public void AskedWhere()
    {
        SelectedDispatchDetails.FiguredOutWhere();
    }

    public void AskedWho()
    {
        SelectedDispatchDetails.FiguredOutWho();
    }
}
