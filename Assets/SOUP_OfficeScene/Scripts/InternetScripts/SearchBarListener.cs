using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SearchBarListener : MonoBehaviour
{
    public static TMP_InputField searchBar;
    public TMP_InputField nonStaticSearchBar;
    public static bool usingSearchBar;

    [SerializeField]
    private Animator anim;

    public DisplaySearchResults searchResults;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (searchBar == null)
        {
            searchBar = nonStaticSearchBar;
        }
        else return;
    }

    public void SetSearchBar()
    {
            searchBar = nonStaticSearchBar;
    }

    public static void ClickedSearchBar()
    {
        usingSearchBar = true;
        searchBar.caretWidth = 3;
    }

    public void ClickedSearchButton()
    {
        usingSearchBar = true;
        Debug.Log($"We've now searched for {searchBar.text.ToString()}");
        searchResults.GatherSearchResults(searchBar.text.ToString());
        searchResults.ActivateLoadPage();
        anim.SetTrigger("Loading");
        usingSearchBar = false;
    }

    public static void ClickedOffSearchBar()
    {
        usingSearchBar=false;
        searchBar.caretWidth = 0;
    }

    public void SearchForQuery()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log($"We've now searched for {searchBar.text.ToString()}");
            searchResults.GatherSearchResults(searchBar.text.ToString());
            searchResults.ActivateLoadPage();
            anim.SetTrigger("Loading");
        }
        else Debug.Log("We're not searching");
    }
}
