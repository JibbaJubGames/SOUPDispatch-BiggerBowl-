using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeroSelection : MonoBehaviour
{
    [SerializeField] private Sprite[] heroPics;
    [SerializeField] private Image heroImageHolder;
    [SerializeField] private int chosenHeroNumber;

    [SerializeField] private Transform heroDetailsSpawnPoint;
    [SerializeField] private GameObject[] heroDetails;
    [SerializeField] private GameObject selectedHero;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        Debug.Log("Called hero choice from awake");
        SetHeroChoice();
    }

    private void SetHeroChoice()
    {
        int randomChoice = Random.Range (0, heroPics.Length);
        if (!ChosenHeroInfoHolder.chosenHeroesForTheDay.Contains(randomChoice))
 // add this back in once you figure out how to save the heroes that died:
 // && !GameManager.fallenHeroesList.Contains(randomChoice)            
            {
            heroImageHolder.sprite = heroPics[randomChoice];
            ChosenHeroInfoHolder.chosenHeroesForTheDay.Add (randomChoice);
            chosenHeroNumber = randomChoice;
            }
        else
        {
            Debug.Log("Saved from a dupe, " + randomChoice + " was already chosen for today");
            SetHeroChoice();
        }
    }

    public void HoveringThisHero()
    {
        selectedHero = Instantiate(heroDetails[chosenHeroNumber], heroDetailsSpawnPoint);
    }

    public void StoppedHoveringHero()
    {
        Destroy(selectedHero);
    }
}
