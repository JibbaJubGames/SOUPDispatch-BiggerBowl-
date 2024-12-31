using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class DisplaySearchResults : MonoBehaviour
{
    [Header("Realistic Load Off")]
    [SerializeField]
    private GameObject[] loadingPagePieces;

    private float loadOffTimer;
    private float loadOffWaitTime;
    private bool loadOffWaitActive;

    [Header("Keyword Info")]
    public string[] searchedKeyword;
    public int[] keywordCategoryDividers;
    public string[] keywordCategories;

    [Header("Results Gameobjects")]
    [SerializeField]
    private TMP_Text tempResults;
    public GameObject resultsPage;
    public TMP_InputField resultsSearchBar;

    [Header("Displayed Results")]
    [SerializeField] private RectTransform resultsLog;
    [SerializeField] private int resultsCount;
    [SerializeField] private GameObject resultsHolder;
    [SerializeField] private SearchResultPoolSelector pools;
    [SerializeField] private WebsiteSelection noResultsSwap;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (loadOffWaitActive)
        {
            loadOffTimer += Time.deltaTime;
            if (loadOffTimer > loadOffWaitTime)
            {
                Debug.Log("Done loading");
                TurnOffLoad();
                loadOffWaitActive = false;
            }
        }
    }

    public void SetWaitTime()
    {
        resultsPage.SetActive(false);
        loadOffWaitTime = Random.Range(2f, 4.5f);
        loadOffWaitActive = true;
    }

    public void ActivateLoadPage()
    {
        loadingPagePieces[0].SetActive(true);
    }

    public void TurnOffLoad()
    {
        loadOffTimer = 0;
        for (int i = 0; i < loadingPagePieces.Length; i++)
        {
            loadingPagePieces[i].gameObject.SetActive(false);
        }
        resultsPage.SetActive(true);
    }

    public void GatherSearchResults(string keyword)
    {
        bool foundResults = false;
        resultsSearchBar.text = keyword;
        for(int i = 0;i < searchedKeyword.Length;i++)
        {
            if (keyword.Contains(searchedKeyword[i]) && !foundResults)
            {
                Debug.Log($"Searching for {searchedKeyword[i]}");
                for (int j = 1; j < keywordCategoryDividers.Length; j++)
                {
                    if (i < keywordCategoryDividers[j] && i >= keywordCategoryDividers[j - 1])
                    {
                        Debug.Log("We're in category divider" + keywordCategories[j]);
                        pools.SelectPool(j);
                        DisplayResults(pools.poolUsed.GetComponent<SearchResultPool>().results.Length);
                        foundResults = true;
                    }
                }
            Debug.Log($"This was run {i} times");
            }
            Debug.Log("Found our results");
                //noResultsSwap.GoToWebsite();
        }
    }

    public void DisplayResults(int resultsCount)
    {
        for (int i = 0; i < resultsHolder.transform.childCount; i++)
        {
            Destroy (resultsHolder.transform.GetChild(i).gameObject);
        }
        resultsLog.transform.position = new Vector2 (resultsLog.transform.position.x, 0f);
        resultsLog.sizeDelta = new Vector2(0, resultsCount * 85 + 20);
        for (int i = 0; i < resultsCount; i++)
        {
            Instantiate(pools.poolUsed.GetComponent<SearchResultPool>().results[i], resultsHolder.transform);
        }
    }
}
