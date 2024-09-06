using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyHeroOptionsScript : MonoBehaviour
{
    [Header("Hero Options")]
    public GameObject[] heroOptions;
    public int shownHero = 0;
    private Animator chosenHeroAnim;

    [Header("Set Up")]
    public int heroChoices;
    public List<int> chosenHeroesToday;
    public DispatchNotificationScript notifReset;

    public int maxHeroOptions;

    private bool choseHeroForDispatch;
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
        if (!choseHeroForDispatch)
        {
            choseHeroForDispatch = true;
            DispatchMatchupSetup.SetHeroElement(heroOptions[chosenHeroesToday[shownHero]].gameObject.GetComponent<ElementalTypeScript>().elementalType);
            DispatchMatchupSetup.SetHeroElement(heroOptions[chosenHeroesToday[shownHero]].gameObject.GetComponent<SkillTypeScript>().skillType);
            DispatchVictoryCheckerScript.CompareVictory();
            heroOptions[chosenHeroesToday[shownHero]].GetComponent<Animator>().SetTrigger("ChoseHero");
            Invoke("AfterHeroBounceAnim", 0.75f);
        }
        else Debug.Log("Already chose a hero!");
    }

    public void AfterHeroBounceAnim()
    {
        heroOptions[chosenHeroesToday[shownHero]].gameObject.SetActive(false);
        chosenHeroesToday.Remove(chosenHeroesToday[shownHero]);
        notifReset.EndedDispatch();
        choseHeroForDispatch = false;
        shownHero = 0;
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
