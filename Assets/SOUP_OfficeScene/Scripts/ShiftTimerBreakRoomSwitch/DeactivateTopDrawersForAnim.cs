using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateTopDrawersForAnim : MonoBehaviour
{
    [SerializeField] private GameObject leftDrawer;
    [SerializeField] private GameObject midDrawer;
    [SerializeField] private GameObject rightDrawer;
    [SerializeField] private GameObject backdrop;
    private bool backdropActiveAtLunch;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BreakRoomSwitch()
    {
        leftDrawer.SetActive(false);
        midDrawer.SetActive(false);
        rightDrawer.SetActive(false);
        backdrop.SetActive(false);
    }

    public void OfficeRoomSwitch()
    {
        leftDrawer.SetActive(true);
        midDrawer.SetActive(true);
        rightDrawer.SetActive(true);
        backdrop.SetActive(backdropActiveAtLunch);
    }
}
