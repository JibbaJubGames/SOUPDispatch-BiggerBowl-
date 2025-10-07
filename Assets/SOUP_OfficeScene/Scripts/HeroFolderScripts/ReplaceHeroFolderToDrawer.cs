using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaceHeroFolderToDrawer : MonoBehaviour
{
    public GameObject thisHerosFolder;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReplaceInDrawer (Transform parentObject)
    {
        Instantiate(thisHerosFolder, parentObject);
    }
}
