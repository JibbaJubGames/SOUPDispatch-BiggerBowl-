using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeftRightChoices : MonoBehaviour
{
    [Header("Shop Choices")]
    [SerializeField] public Animator ItemsToPurchase;
    [SerializeField] public string[] AnimTriggers;
    [SerializeField] public string[] ItemDescription;
    [SerializeField] public string[] ItemNames;
    [SerializeField] public int[] ItemPrices;
    [SerializeField] public int[] CoffeeEnergyBonus;

    [Header("Shop Holders")]
    [SerializeField] public TMP_Text CurrentChoicePrice;
    [SerializeField] public TMP_Text CurrentChoiceName;
    [SerializeField] public TMP_Text CurrentChoiceDescription;

    [Header("Detail Holders")]
    [SerializeField] public int CurrentSelectionNumber;

    [Header("Safety Lock")]
    private float clickLockTimer;
    private float clickLockThreshold = 0.5f;
    private bool clickLockActive;
    public Button nextChoiceButton;
    public Button prevChoiceButton;
    // Start is called before the first frame update
    void Start()
    {
        CurrentSelectionNumber = 0;
        UpdateChoice();
    }

    // Update is called once per frame
    void Update()
    {
        if (clickLockActive)
        {
            clickLockTimer += Time.deltaTime;
            if (clickLockTimer > clickLockThreshold)
            {
                nextChoiceButton.interactable = true;
                prevChoiceButton.interactable = true;
                clickLockActive = false;
                clickLockTimer = 0;
            }
        }
    }

    public void ResetMenu()
    {
        CurrentSelectionNumber = 0;
        UpdateChoice();
    }

    public void NextChoice()
    {
        if (!clickLockActive)
        {
            nextChoiceButton.interactable = false;
            clickLockActive = true;
            CurrentSelectionNumber++;
            SafetyMeasure();
            UpdateChoice();
        }
    }
    public void PreviousChoice()
    {
        if (!clickLockActive)
        {
            prevChoiceButton.interactable = false;
            clickLockActive = true;
            CurrentSelectionNumber--;
            SafetyMeasure();
            UpdateChoice();
        }
    }

    private void SafetyMeasure()
    {
        if (CurrentSelectionNumber > ItemNames.Length-1)
        {
            CurrentSelectionNumber = 0;
        }
        else if (CurrentSelectionNumber < 0)
        {
            CurrentSelectionNumber = ItemNames.Length - 1;
        }
    }

    private void UpdateChoice()
    {
        CurrentChoicePrice.text = $"${ItemPrices[CurrentSelectionNumber].ToString()}";
        CurrentChoiceName.text = ItemNames[CurrentSelectionNumber];
        CurrentChoiceDescription.text = ItemDescription[CurrentSelectionNumber];
    }
}
