using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroProfileSlotSafetyScript : MonoBehaviour
{
    [SerializeField] public Transform heroProfileHolderObject;
    [SerializeField] public Transform cleanHeroProfileHolderObject;
    [SerializeField] public GameObject heroProfile;
    [SerializeField] public GameObject cleanHeroProfile;
    [SerializeField] public HeroHolderLockScript heroHover; 
    
    [Header("ProfileReset")]
    [SerializeField] private Transform heroFolders;
    // Start is called before the first frame update
    void Start()
    {
        cleanHeroProfile = heroProfile;
        Instantiate(cleanHeroProfile, cleanHeroProfileHolderObject);
        cleanHeroProfileHolderObject.GetChild(0).gameObject.name = "CleanHeroProfile";
        cleanHeroProfile = cleanHeroProfileHolderObject.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        CheckFolderSlot();
    }

    public void CheckFolderSlot()
    {
        if (heroProfileHolderObject.childCount == 0) 
        {
        Instantiate (cleanHeroProfile, heroProfileHolderObject.transform);
        for (int i = 0; i < heroFolders.childCount; i++)
            {
                heroFolders.GetChild(i).GetComponent<HeroFolderHoverScript>().heroProfileSlot = heroProfileHolderObject.GetChild(0).transform;
            }
        }
    }
}
