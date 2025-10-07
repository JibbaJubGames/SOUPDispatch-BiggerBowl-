using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CycleSectorOptions : MonoBehaviour
{
    [SerializeField] private string[] sectorLetters;
    [SerializeField] private int sectorLetterChoice;
    [SerializeField] private string[] sectorNumbers;
    [SerializeField] private int sectorNumberChoice;
    [SerializeField] private TMP_Text sectorLetterText;
    [SerializeField] private TMP_Text sectorNumberText;
    [SerializeField] private AddressRandomizationScript addressRandomizationScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SectorLetterUp()
    {
        if (sectorLetterChoice != 3)
        {
            sectorLetterChoice++;
            sectorLetterText.text = sectorLetters[sectorLetterChoice];
            addressRandomizationScript.sectorOnSheet = "Sector " + sectorLetters[sectorLetterChoice] + sectorNumbers[sectorNumberChoice];
        }
        else if (sectorLetterChoice == 3) 
        {
            sectorLetterChoice = 0;
            sectorLetterText.text = sectorLetters[sectorLetterChoice];
            addressRandomizationScript.sectorOnSheet = "Sector " + sectorLetters[sectorLetterChoice] + sectorNumbers[sectorNumberChoice];
        }
    }

    public void SectorNumberUp()
    {
        if (sectorNumberChoice != 3)
        {
            sectorNumberChoice++;
            sectorNumberText.text = sectorNumbers[sectorNumberChoice];
            addressRandomizationScript.sectorOnSheet = "Sector " + sectorLetters[sectorLetterChoice] + sectorNumbers[sectorNumberChoice];
        }
        else if ( sectorNumberChoice == 3)
        {
            sectorNumberChoice = 0;
            sectorNumberText.text = sectorNumbers[sectorNumberChoice];
            addressRandomizationScript.sectorOnSheet = "Sector " + sectorLetters[sectorLetterChoice] + sectorNumbers[sectorNumberChoice];
        }
    }
}
