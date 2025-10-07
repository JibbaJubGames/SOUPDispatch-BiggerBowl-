using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandbookPages : MonoBehaviour
{
    [SerializeField] public List<GameObject> handbookPages;
    [SerializeField]    public int currentPage;

    public GameObject nextPageButton;
    public GameObject prevPageButton;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //The above method adds the sheet into the page, as well as infinite blank sheets.
        //find a new method to only add the sheet we require (possibly a check in start instead)
    }

    public void OpenBook()
    {
        handbookPages[currentPage].SetActive(true);
        nextPageButton.SetActive(true);
        prevPageButton.SetActive(true);
    }
    public void CloseBook()
    {
        handbookPages[currentPage].gameObject.SetActive(false);
        prevPageButton.gameObject.SetActive(false);
        nextPageButton.SetActive(false);
    }

    public void PageCycleUp()
    {   
        if (currentPage == handbookPages.Count-1)
        {
            handbookPages[currentPage].gameObject.SetActive(false);
            currentPage = 0;
            handbookPages[currentPage].gameObject.SetActive(true);
        }
        else if (currentPage < handbookPages.Count)
        {
            currentPage++;
            handbookPages[currentPage-1].gameObject.SetActive(false);
            handbookPages[currentPage].gameObject.SetActive(true);
        }
    }
    public void PageCycleDown()
    {   
        if (currentPage == 0)
        {
            handbookPages[currentPage].gameObject.SetActive(false);
            currentPage = handbookPages.Count - 1;
            handbookPages[currentPage].gameObject.SetActive(true);
        }
        else if (currentPage < handbookPages.Count)
        {
            currentPage--;
            handbookPages[currentPage+1].gameObject.SetActive(false);
            handbookPages[currentPage].gameObject.SetActive(true);
        }
    }
}
