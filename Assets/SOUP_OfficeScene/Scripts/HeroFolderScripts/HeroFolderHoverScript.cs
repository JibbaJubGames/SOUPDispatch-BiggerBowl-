using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroFolderHoverScript : MonoBehaviour
{
    [SerializeField] private Sprite hoveredSprite;
    [SerializeField] private Sprite regularSprite;
    [SerializeField] private GameObject heroProfile;
    [SerializeField] public Transform heroProfileSlot;
    [SerializeField] public bool heroProfileShowing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HoverProfile()
    {
        if (!HeroHolderLockScript.heroLocked)
        {
            this.GetComponent<Image>().sprite = hoveredSprite;
            this.gameObject.transform.localScale = new Vector3(1, 1.25f, 1);
        }
    }

    public void HideProfile()
    {
        if (!HeroHolderLockScript.heroLocked)
        {
            this.GetComponent<Image>().sprite = regularSprite;
            this.gameObject.transform.localScale = Vector3.one;
        }
    }

    public void DetailedProfile()
    {
        if (!heroProfileShowing)
        {
            if (heroProfileSlot.childCount != 0)
            {
                Destroy(heroProfileSlot.GetChild(0).gameObject);
            }
            Instantiate(heroProfile, heroProfileSlot);
            heroProfileShowing = true;
            HeroHolderLockScript.heroLocked = true;
        }
        else if (heroProfileShowing)
        {
            if (heroProfileSlot.childCount != 0)
            {
                Destroy(heroProfileSlot.GetChild(0).gameObject);
            }
            heroProfileShowing = false;
            HeroHolderLockScript.heroLocked = false;
        }
    }
}
