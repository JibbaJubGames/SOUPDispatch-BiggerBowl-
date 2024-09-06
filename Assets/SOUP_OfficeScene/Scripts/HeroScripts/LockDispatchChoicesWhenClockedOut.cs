using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockDispatchChoicesWhenClockedOut : MonoBehaviour
{
    public DispatchNotificationScript lockOut;
    public GameObject noHeroNeeded;
    public GameObject heroDispatchButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!lockOut.dispatchActive)
        {
            heroDispatchButton.SetActive(false);
            noHeroNeeded.SetActive(true);
        }
        else if (lockOut.dispatchActive)
        {
            heroDispatchButton.SetActive(true);
            noHeroNeeded.SetActive(false);
        }
    }


}
