using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyHeroOptionsScript : MonoBehaviour
{
    [Header("Hero Options")]
    public GameObject[] heroOptions;
    public int shownHero = 0;

    [Header("Set Up")]
    public int heroChoices;
    public List<int> chosenHeroesToday;

    public int maxHeroOptions;

    // Start is called before the first frame update
    void Start()
    {
        InitializeHeroList();
    }

    private void InitializeHeroList()
    {
        while (chosenHeroesToday.Count < maxHeroOptions)
        {
            heroChoices = Random.Range(0, heroOptions.Length);
            if (!chosenHeroesToday.Contains(heroChoices))
            {
                chosenHeroesToday.Add(heroChoices);
            }
            else Debug.Log("Saved from a dupe hero");
        }
        heroOptions[chosenHeroesToday[shownHero]].gameObject.SetActive(true);
    }

    public void ChooseHeroForDispatch()
    {
        heroOptions[chosenHeroesToday[shownHero]].gameObject.SetActive(false);
        chosenHeroesToday.Remove(chosenHeroesToday[shownHero]);
        Debug.Log("We got here");
        shownHero = 0;
        Debug.Log("Then we got here");
        heroOptions[chosenHeroesToday[shownHero]].gameObject.SetActive(true);
    }

    public void SafetyCatchUp()
    {
        if (shownHero == chosenHeroesToday.Count - 1)
        {
            heroOptions[chosenHeroesToday[shownHero]].gameObject.SetActive(false);
            shownHero = 0;
            heroOptions[chosenHeroesToday[shownHero]].gameObject.SetActive(true);
        }
        else
        {
            heroOptions[chosenHeroesToday[shownHero]].gameObject.SetActive(false);
            shownHero++;
            heroOptions[chosenHeroesToday[shownHero]].gameObject.SetActive(true);
        }
    }
    public void SafetyCatchDown()
    {
        if (shownHero == 0)
        {
            heroOptions[chosenHeroesToday[shownHero]].gameObject.SetActive(false);
            shownHero = chosenHeroesToday.Count-1;
            heroOptions[chosenHeroesToday[shownHero]].gameObject.SetActive(true);
        }
        else
        {
            heroOptions[chosenHeroesToday[shownHero]].gameObject.SetActive(false);
            shownHero--;
            heroOptions[chosenHeroesToday[shownHero]].gameObject.SetActive(true);
        }
    }
}
