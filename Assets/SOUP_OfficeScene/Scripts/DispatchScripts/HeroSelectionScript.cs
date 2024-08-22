using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSelectionScript : MonoBehaviour
{
   // [SerializeField] private HeroChoiceMenuScript availableHeroes;
    [SerializeField] private AbilityComparisonScript abilityCheck;
    // Start is called before the first frame update
    void Start()
    {
        DispatchManager.DispatchCountReset();
        Debug.Log("This is firing now");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChooseThisHero()
    {
    //    abilityCheck.chosenHerosTier = availableHeroes.heroToShow.GetComponent<TierLevelScript>().tier;
    //    abilityCheck.CompareTier();
    //    abilityCheck.chosenHerosSkill = availableHeroes.heroToShow.GetComponent<SkillTypeScript>().skillType;
    //    abilityCheck.CheckSkill();
    //    abilityCheck.chosenHerosElement = availableHeroes.heroToShow.GetComponent<ElementalTypeScript>().elementalType;
    //    abilityCheck.CheckElement();
    //    DispatchDeciderScript.CompareWinOrLoss();
    }
}
