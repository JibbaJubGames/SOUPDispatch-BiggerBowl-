using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroChoiceMenuScript : MonoBehaviour
{
    [Header("Hero Options")]
    public GameObject spawnPoint;
    public GameObject heroToShow;
    public int selectedHeroes = 0;

    [Header("Hero Reference Script")]
    [SerializeField]
    private HeroOptionRandomizationScript referenceScript;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void InitialHeroChoice()
    {
        if (heroToShow != null) Destroy(heroToShow);
        heroToShow = Instantiate(referenceScript.chosenHeroes[selectedHeroes], spawnPoint.transform);
        Debug.Log($"Displaying {referenceScript.chosenHeroes[selectedHeroes]} at spawnpoint {selectedHeroes}");
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ShowNextHeroChoice()
    {
        SelectionSafetyCatchUp();
        Destroy(heroToShow);
        heroToShow = Instantiate(referenceScript.chosenHeroes[selectedHeroes], spawnPoint.transform);
        Debug.Log($"Displaying {referenceScript.chosenHeroes[selectedHeroes]} at spawnpoint {selectedHeroes}");
    }

    public void ShowPrevHeroChoice()
    {
        SelectionSafetyCatchDown(); 
        Destroy(heroToShow);
        heroToShow = Instantiate(referenceScript.chosenHeroes[selectedHeroes], spawnPoint.transform);
        Debug.Log($"Displaying {referenceScript.chosenHeroes[selectedHeroes]} at spawnpoint {selectedHeroes}");
    }

    public void SelectionSafetyCatchDown()
    {
        if (selectedHeroes == 0)
        {
            selectedHeroes = referenceScript.chosenHeroes.Count - 1;
        }
        else
        {
            selectedHeroes--;
        }
    }

    public void SelectionSafetyCatchUp()
    {
        if (selectedHeroes == referenceScript.chosenHeroes.Count - 1)
        {
            selectedHeroes = 0;
        }
        else
        {
            selectedHeroes++;
        }
    }
}
