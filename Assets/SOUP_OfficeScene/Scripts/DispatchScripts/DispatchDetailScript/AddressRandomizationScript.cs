using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AddressRandomizationScript : MonoBehaviour
{
    public GameObject[] SectorA1Address;
    public GameObject[] SectorA2Address;
    public GameObject[] SectorA3Address;
    public GameObject[] SectorA4Address;
    public GameObject[] SectorB1Address;
    public GameObject[] SectorB2Address;
    public GameObject[] SectorB3Address;
    public GameObject[] SectorB4Address;
    public GameObject[] SectorC1Address;
    public GameObject[] SectorC2Address;
    public GameObject[] SectorC3Address;
    public GameObject[] SectorC4Address;
    public GameObject[] SectorD1Address;
    public GameObject[] SectorD2Address;
    public GameObject[] SectorD3Address;
    public GameObject[] SectorD4Address;
    public GameObject[] FullAddressList;

    [SerializeField] public TMP_Text addressOnSheet;
    [SerializeField] public TMP_Text unknownSectorOnSheet;
    [SerializeField] public string sectorOnSheet;
    public int addressGenerated;
    [SerializeField] public GameObject currentDispatch;
    public GameObject selectedAddressGameObject;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void GenAddress()
    {
        currentDispatch = GameObject.Find("DispatchPaper(Clone)");
        currentDispatch.GetComponent<DispatchInfoSet>().addressNotPrankster = true;
        addressOnSheet = currentDispatch.transform.GetChild(0).transform.GetChild(5).GetComponent<TMP_Text>();
        sectorOnSheet = currentDispatch.GetComponent<AddressRandomizationScript>().sectorOnSheet;
        Debug.Log("New dispatch sheet found");
        int sectorChosen = Random.Range(1, 9);
        Debug.Log("MAKE THIS ACCEPT ALL SECTORS IN THE FINAL VERSION");
        if (sectorChosen == 1)
        {
            addressGenerated = Random.Range(0, SectorA1Address.Length);
            addressOnSheet.text = SectorA1Address[addressGenerated].GetComponentInChildren<TMP_Text>().text;
            sectorOnSheet = "Sector A1";
            if (GameManager.prankCallAddresses.ContainsKey(SectorA1Address[addressGenerated].GetComponent<PrankCallAddressCheck>().overallAddressNumber)) 
            {
            //Set prankcaller to true
            Debug.Log("Successfully caught a prankster!");
            }
            Debug.Log(addressOnSheet.text + " is the site of the emergency");
        }
        else if (sectorChosen == 2)
        {
            addressGenerated = Random.Range(0, SectorA2Address.Length);
            addressOnSheet.text = SectorA2Address[addressGenerated].GetComponentInChildren<TMP_Text>().text;
            sectorOnSheet = "Sector A2";
            if (GameManager.prankCallAddresses.ContainsKey(SectorA2Address[addressGenerated].GetComponent<PrankCallAddressCheck>().overallAddressNumber))
            {
                //Set prankcaller to true
                Debug.Log("Successfully caught a prankster!");
            }
            Debug.Log(addressOnSheet.text + " is the site of the emergency");
        }
        else if (sectorChosen == 3)
        {
            addressGenerated = Random.Range(0, SectorA3Address.Length);
            addressOnSheet.text = SectorA3Address[addressGenerated].GetComponentInChildren<TMP_Text>().text;
            sectorOnSheet = "Sector A3";
            if (GameManager.prankCallAddresses.ContainsKey(SectorA3Address[addressGenerated].GetComponent<PrankCallAddressCheck>().overallAddressNumber))
            {
                //Set prankcaller to true
                Debug.Log("Successfully caught a prankster!");
            }
            Debug.Log(addressOnSheet.text + " is the site of the emergency");
        }
        else if (sectorChosen == 4)
        {
            addressGenerated = Random.Range(0, SectorA4Address.Length);
            addressOnSheet.text = SectorA4Address[addressGenerated].GetComponentInChildren<TMP_Text>().text;
            sectorOnSheet = "Sector A4";
            if (GameManager.prankCallAddresses.ContainsKey(SectorA4Address[addressGenerated].GetComponent<PrankCallAddressCheck>().overallAddressNumber))
            {
                //Set prankcaller to true
                Debug.Log("Successfully caught a prankster!");
            }
            Debug.Log(addressOnSheet.text + " is the site of the emergency");
        }
        else if (sectorChosen == 5)
        {
            addressGenerated = Random.Range(0, SectorB1Address.Length);
            addressOnSheet.text = SectorB1Address[addressGenerated].GetComponentInChildren<TMP_Text>().text;
            sectorOnSheet = "Sector B1";
            if (GameManager.prankCallAddresses.ContainsKey(SectorB1Address[addressGenerated].GetComponent<PrankCallAddressCheck>().overallAddressNumber))
            {
                //Set prankcaller to true
                Debug.Log("Successfully caught a prankster!");
            }
            Debug.Log(addressOnSheet.text + " is the site of the emergency");
        }
        else if (sectorChosen == 6)
        {
            addressGenerated = Random.Range(0, SectorB2Address.Length);
            addressOnSheet.text = SectorB2Address[addressGenerated].GetComponentInChildren<TMP_Text>().text;
            sectorOnSheet = "Sector B2";
            if (GameManager.prankCallAddresses.ContainsKey(SectorB2Address[addressGenerated].GetComponent<PrankCallAddressCheck>().overallAddressNumber)) 
            {
            //Set prankcaller to true
            Debug.Log("Successfully caught a prankster!");
            }
            Debug.Log(addressOnSheet.text + " is the site of the emergency");
        }
        else if (sectorChosen == 7)
        {
            addressGenerated = Random.Range(0, SectorB3Address.Length);
            addressOnSheet.text = SectorB3Address[addressGenerated].GetComponentInChildren<TMP_Text>().text;
            sectorOnSheet = "Sector B3";
            if (GameManager.prankCallAddresses.ContainsKey(SectorB3Address[addressGenerated].GetComponent<PrankCallAddressCheck>().overallAddressNumber)) 
            {
            //Set prankcaller to true
            Debug.Log("Successfully caught a prankster!");
            }
            Debug.Log(addressOnSheet.text + " is the site of the emergency");
        }
        else if (sectorChosen == 8)
        {
            addressGenerated = Random.Range(0, SectorB4Address.Length);
            addressOnSheet.text = SectorB4Address[addressGenerated].GetComponentInChildren<TMP_Text>().text;
            sectorOnSheet = "Sector B4";
            if (GameManager.prankCallAddresses.ContainsKey(SectorB4Address[addressGenerated].GetComponent<PrankCallAddressCheck>().overallAddressNumber)) 
            {
            //Set prankcaller to true
            Debug.Log("Successfully caught a prankster!");
            }
            Debug.Log(addressOnSheet.text + " is the site of the emergency");
        }
        else if (sectorChosen == 9)
        {
            addressGenerated = Random.Range(0, SectorC1Address.Length);
            addressOnSheet.text = SectorC1Address[addressGenerated].GetComponentInChildren<TMP_Text>().text;
            sectorOnSheet = "Sector C1";
            if (GameManager.prankCallAddresses.ContainsKey(SectorC1Address[addressGenerated].GetComponent<PrankCallAddressCheck>().overallAddressNumber)) 
            {
            //Set prankcaller to true
            Debug.Log("Successfully caught a prankster!");
            }
            Debug.Log(addressOnSheet.text + " is the site of the emergency");
        }
        else if (sectorChosen == 10)
        {
            addressGenerated = Random.Range(0, SectorC2Address.Length);
            addressOnSheet.text = SectorC2Address[addressGenerated].GetComponentInChildren<TMP_Text>().text;
            sectorOnSheet = "Sector C2";
            if (GameManager.prankCallAddresses.ContainsKey(SectorC2Address[addressGenerated].GetComponent<PrankCallAddressCheck>().overallAddressNumber)) 
            {
            //Set prankcaller to true
            Debug.Log("Successfully caught a prankster!");
            }
            Debug.Log(addressOnSheet.text + " is the site of the emergency");
        }
        else if (sectorChosen == 11)
        {
            addressGenerated = Random.Range(0, SectorC3Address.Length);
            addressOnSheet.text = SectorC3Address[addressGenerated].GetComponentInChildren<TMP_Text>().text;
            sectorOnSheet = "Sector C3";
            if (GameManager.prankCallAddresses.ContainsKey(SectorC3Address[addressGenerated].GetComponent<PrankCallAddressCheck>().overallAddressNumber)) 
            {
            //Set prankcaller to true
            Debug.Log("Successfully caught a prankster!");
            }
            Debug.Log(addressOnSheet.text + " is the site of the emergency");
        }
        else if (sectorChosen == 12)
        {
            addressGenerated = Random.Range(0, SectorC4Address.Length);
            addressOnSheet.text = SectorC4Address[addressGenerated].GetComponentInChildren<TMP_Text>().text;
            sectorOnSheet = "Sector C4";
            if (GameManager.prankCallAddresses.ContainsKey(SectorC4Address[addressGenerated].GetComponent<PrankCallAddressCheck>().overallAddressNumber)) 
            {
            //Set prankcaller to true
            Debug.Log("Successfully caught a prankster!");
            }
            Debug.Log(addressOnSheet.text + " is the site of the emergency");
        }
        else if (sectorChosen == 13)
        {
            addressGenerated = Random.Range(0, SectorD1Address.Length);
            addressOnSheet.text = SectorD1Address[addressGenerated].GetComponentInChildren<TMP_Text>().text;
            sectorOnSheet = "Sector D1";
            if (GameManager.prankCallAddresses.ContainsKey(SectorD1Address[addressGenerated].GetComponent<PrankCallAddressCheck>().overallAddressNumber)) 
            {
            //Set prankcaller to true
            Debug.Log("Successfully caught a prankster!");
            }
            Debug.Log(addressOnSheet.text + " is the site of the emergency");
        }
        else if (sectorChosen == 14)
        {
            addressGenerated = Random.Range(0, SectorD2Address.Length);
            addressOnSheet.text = SectorD2Address[addressGenerated].GetComponentInChildren<TMP_Text>().text;
            sectorOnSheet = "Sector D2";
            if (GameManager.prankCallAddresses.ContainsKey(SectorD2Address[addressGenerated].GetComponent<PrankCallAddressCheck>().overallAddressNumber)) 
            {
            //Set prankcaller to true
            Debug.Log("Successfully caught a prankster!");
            }
            Debug.Log(addressOnSheet.text + " is the site of the emergency");
        }
        else if (sectorChosen == 15)
        {
            addressGenerated = Random.Range(0, SectorD3Address.Length);
            addressOnSheet.text = SectorD3Address[addressGenerated].GetComponentInChildren<TMP_Text>().text;
            sectorOnSheet = "Sector D3";
            if (GameManager.prankCallAddresses.ContainsKey(SectorD3Address[addressGenerated].GetComponent<PrankCallAddressCheck>().overallAddressNumber)) 
            {
            //Set prankcaller to true
            Debug.Log("Successfully caught a prankster!");
            }
            Debug.Log(addressOnSheet.text + " is the site of the emergency");
        }
        else if (sectorChosen == 16)
        {
            addressGenerated = Random.Range(0, SectorD4Address.Length);
            addressOnSheet.text = SectorD4Address[addressGenerated].GetComponentInChildren<TMP_Text>().text;
            sectorOnSheet = "Sector D4";
            if (GameManager.prankCallAddresses.ContainsKey(SectorD4Address[addressGenerated].GetComponent<PrankCallAddressCheck>().overallAddressNumber)) 
            {
                //Set prankcaller to true
                Debug.Log("Successfully caught a prankster!");
            }
            Debug.Log(addressOnSheet.text + " is the site of the emergency");
        }
        string addressString = "The address for the emergency is " + addressOnSheet.text + ". ";
        StartCoroutine(AppearLetterByLetterText.TypewriterText(addressString, 0.05f));       
    }
    
    public void GenPrankAddress()
    {
        currentDispatch = GameObject.Find("DispatchPaper(Clone)");
            addressOnSheet = currentDispatch.transform.GetChild(0).transform.GetChild(5).GetComponent<TMP_Text>();
        Debug.Log("New dispatch sheet found");

        //Method for ensuring the address is a prank address
            addressGenerated = Random.Range(0, GameManager.prankCallAddresses.Count);
            int prankAddressNumber = SaveAndLoad.playerSavePranks.prankingAddresses[addressGenerated];//Pick a random number from the prank call address dictionary
            addressOnSheet.text = FullAddressList[prankAddressNumber].GetComponent<AddressText>().addressText;
            sectorOnSheet = FullAddressList[prankAddressNumber].GetComponent<AddressText>().sectorTextForPrankCall;
            if (GameManager.prankCallAddresses.ContainsKey(FullAddressList[prankAddressNumber].GetComponent<PrankCallAddressCheck>().overallAddressNumber)) 
            {
            //Set prankcaller to true
            Debug.Log("Successfully caught a prankster!");
            }
       
        Debug.Log(addressOnSheet.text + " is the site of the emergency");
    }

    public void AddressUnknown()
    {
        addressOnSheet.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
