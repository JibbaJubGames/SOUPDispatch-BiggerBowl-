using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroOptionRandomizationScript : MonoBehaviour
{
    [Header("Hero Options")]
    [SerializeField] private GameObject[] heroes;

    [Header("Randomization Setup")]
    public  int selectedHeroesAmount;
    [SerializeField] private int maxHeroesAmount;
    [SerializeField] public List<GameObject> chosenHeroes;
    [SerializeField] public List<int> chosenNumbers;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Just checking, this is called every time the scene loads");
        RandomizeHeroes();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void RandomizeHeroes()
    {
        CheckForNecessity();
        while (chosenHeroes.Count < maxHeroesAmount)
        {
            int randomHero = Random.Range(0, heroes.Length);
            if (!chosenNumbers.Contains(randomHero))
            {
                chosenHeroes.Add(heroes[randomHero]);
                selectedHeroesAmount++;
                chosenNumbers.Add(randomHero);
                Debug.Log("Attempting to add to list");
            }
            else
            {
                Debug.Log("Saved from a dupe hero");
            }
        }
    }

    public void CheckForNecessity()
    {
        if (HeroGuaranteeScript.necessaryHeroDays.ContainsKey(GameManager.DayCounter))
        {
            Debug.Log("This is a start!");
            chosenHeroes.Add(HeroGuaranteeScript.necessaryHeroDays[GameManager.DayCounter]);
            selectedHeroesAmount++;
        }
    }
}
