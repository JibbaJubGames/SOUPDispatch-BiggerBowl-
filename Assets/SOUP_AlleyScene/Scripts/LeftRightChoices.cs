using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeftRightChoices : MonoBehaviour
{
    [Header("Shop Choices")]
    [SerializeField] private Sprite[] ItemsToPurchase;
    [SerializeField] private string[] ItemNames;
    [SerializeField] private string[] ItemDescription;

    [Header("Shop Holders")]
    [SerializeField] private Image CurrentChoiceImage;
    [SerializeField] private TMP_Text CurrentChoiceName;
    [SerializeField] private TMP_Text CurrentChoiceDescription;

    [Header("Detail Holders")]
    [SerializeField] private int CurrentSelectionNumber;
    // Start is called before the first frame update
    void Start()
    {
        CurrentSelectionNumber = 0;
        UpdateChoice();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetMenu()
    {
        CurrentSelectionNumber = 0;
        UpdateChoice();
    }

    public void NextChoice()
    {
        CurrentSelectionNumber++;
        SafetyMeasure();
        UpdateChoice();
    }
    public void PreviousChoice()
    {
        CurrentSelectionNumber--;
        SafetyMeasure();
        UpdateChoice();
    }

    private void SafetyMeasure()
    {
        if (CurrentSelectionNumber > ItemsToPurchase.Length-1)
        {
            CurrentSelectionNumber = 0;
        }
        else if (CurrentSelectionNumber < 0)
        {
            CurrentSelectionNumber = ItemsToPurchase.Length - 1;
        }
    }

    private void UpdateChoice()
    {
        CurrentChoiceImage.sprite = ItemsToPurchase[CurrentSelectionNumber];
        CurrentChoiceName.text = ItemNames[CurrentSelectionNumber];
        CurrentChoiceDescription.text = ItemDescription[CurrentSelectionNumber];
    }
}
