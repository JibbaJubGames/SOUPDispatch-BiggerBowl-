using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityMap : MonoBehaviour
{
    public HandbookPages addressBookContents;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SectorSelect(int sector)
    {
        int oldpage = addressBookContents.currentPage;
        addressBookContents.handbookPages[oldpage].gameObject.SetActive(false);
        addressBookContents.currentPage = sector;
        addressBookContents.handbookPages[sector].gameObject.SetActive(true);
    }
}
