using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MentionNextDetailScript : MonoBehaviour
{
    public bool badgeSaid;
    public bool addressSaid;
    public bool emergencySaid;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BringUpAddress()
    {
        addressSaid = true;
        this.gameObject.GetComponent<AddressRandomizationScript>().GenAddress();
    }

    public void BringUpEmergency()
    {
        emergencySaid = true;
        this.gameObject.GetComponent<GenerateDispatchScript>().currentDispatch.GetComponent<DispatchEmergencyDetails>().SetTier();
    }
}
