using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextSettingScript : MonoBehaviour
{
    [Header("TextBoxes")]
    [SerializeField] private TMP_Text topText;
    [SerializeField] private TMP_Text bottomText;

    [Header("Transition Type")]
    [SerializeField] private bool ApartmentToAlley;
    [SerializeField] private bool AlleyToApartment;
    [SerializeField] private bool ApartmentToOffice;
    [SerializeField] private bool OfficeToApartment;

    // Start is called before the first frame update
    void Start()
    {
        SetText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetText() 
    {
    if (ApartmentToAlley) 
        {
            ApartmentToAlleyText();
        }
    else if (AlleyToApartment) 
        {
            AlleyToApartmentText();
        }
    else if (ApartmentToOffice) 
        {
            ApartmentToOfficeText();
        }
    else if (OfficeToApartment) 
        {
            OfficeToApartmentText();
        }
    }

    private void ApartmentToAlleyText()
    {
        topText.text = "Not ready for bed...";
        bottomText.text = $"{GameManager.PlayerName} went out into town!";
    }
    private void AlleyToApartmentText()
    {
        topText.text = "Finished with their night out";
        bottomText.text = $"{GameManager.PlayerName} made their way home!";
    }
    private void ApartmentToOfficeText()
    {
        topText.text = "Ready to save more lives...";
        bottomText.text = $"{GameManager.PlayerName} heads into the office!";
    }
    private void OfficeToApartmentText()
    {
        topText.text = "After a long day of being a desk hero...";
        bottomText.text = $"{GameManager.PlayerName} goes home for some well deserved rest!";
    }
}
