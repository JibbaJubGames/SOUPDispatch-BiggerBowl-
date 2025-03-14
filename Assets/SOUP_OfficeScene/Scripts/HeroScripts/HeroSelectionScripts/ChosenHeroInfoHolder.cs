using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChosenHeroInfoHolder : MonoBehaviour
{
    public static List<int> chosenHeroesForTheDay = new List<int>();
    public static List<int> heroesUnavailableForDispatch;
    // Start is called before the first frame update
    void Start()
    {
        chosenHeroesForTheDay.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
