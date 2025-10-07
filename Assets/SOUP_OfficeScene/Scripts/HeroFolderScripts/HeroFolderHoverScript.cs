using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroFolderHoverScript : MonoBehaviour
{
    [SerializeField] private GameObject heroPeek;
    [SerializeField] private GameObject heroProfile;
    [SerializeField] public Transform heroProfileSlot;
    [SerializeField] public bool heroProfileShowing;

    private bool heroProfileSlotSet;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!heroProfileSlotSet)
        {
            heroProfileSlot = GameObject.Find("HeroProfileHolder").transform.GetChild(0);
            heroProfileSlotSet = true;
        }
    }

    public void HoverProfile()
    {
        if (!HeroHolderLockScript.heroLocked)
        {
            heroPeek.gameObject.SetActive(true);
            this.gameObject.transform.localScale = new Vector3(1, 1.25f, 1);
        }
    }

    public void HideProfile()
    {
        if (!HeroHolderLockScript.heroLocked)
        {
            heroPeek.gameObject.SetActive(false);
            this.gameObject.transform.localScale = Vector3.one;
        }
    }

    public void DetailedProfile()
    {
        if (!heroProfileShowing && !HeroHolderLockScript.heroLocked)
        {
            if (heroProfileSlot.childCount > 2)
            {
                Destroy(heroProfileSlot.GetChild(1).gameObject);
            }
            GameObject spawnedProfile = Instantiate(heroProfile, heroProfileSlot);
            spawnedProfile.transform.SetSiblingIndex(1);
            heroProfileShowing = true;
            HeroHolderLockScript.heroLocked = true;
            HeroHolderLockScript.lockedHero = this.gameObject;
        }
        else if (heroProfileShowing)
        {
            if (heroProfileSlot.childCount >= 3)
            {
                Destroy(heroProfileSlot.GetChild(1).gameObject);
            }
            heroProfileShowing = false;
            HeroHolderLockScript.heroLocked = false;
            HeroHolderLockScript.lockedHero = null;
        }
    }
}
