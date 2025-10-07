using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameTagSelectedScript : MonoBehaviour
{
    public static bool choseName = false;
    public static GameObject chosenNameTag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void ChangedNameChoice()
    {
        if (chosenNameTag.GetComponent<NameTagScript>().blank) 
        {
            chosenNameTag.GetComponent<NameTagScript>().nameTagInputField.enabled = false;
            chosenNameTag.GetComponent<NameTagScript>().nameTagInputField.text = "";
        }
        chosenNameTag.GetComponent<NameTagScript>().nameResponse.bozmunResponse.text = "Oh... okay? Who are you then..?";
        chosenNameTag.GetComponent<BoxCollider2D>().isTrigger = false;
        chosenNameTag.transform.localScale = Vector3.one;
        chosenNameTag.transform.SetSiblingIndex(chosenNameTag.transform.parent.childCount - 3);
        chosenNameTag.GetComponent<NameTagScript>().hand.SetActive(true);
        chosenNameTag.GetComponent<NameTagScript>().hand.transform.SetSiblingIndex(chosenNameTag.transform.parent.childCount - 3);
        choseName = false;
        chosenNameTag = null;
    }
}
