using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusHolders : MonoBehaviour
{
    public static GameObject homeObject;
    public static bool focusSpaceOneFull;
    public static bool focusSpaceTwoFull;
    // Start is called before the first frame update
    void Start()
    {
        if (homeObject == null)
        {
            homeObject = this.gameObject;
        }
        else if (homeObject != this.gameObject && homeObject != null)
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
