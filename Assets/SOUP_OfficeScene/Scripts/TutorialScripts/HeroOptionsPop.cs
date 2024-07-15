using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroOptionsPop : MonoBehaviour
{
    [SerializeField] private Animator tutoralHeroOptions;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PopIn()
    {
        tutoralHeroOptions.SetTrigger("ShowHeroes");
    }

    public void PopOut()
    {
        tutoralHeroOptions.SetTrigger("HideHeroes");
    }
}
