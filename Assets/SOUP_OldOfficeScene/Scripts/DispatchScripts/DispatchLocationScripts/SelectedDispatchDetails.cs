using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedDispatchDetails : MonoBehaviour
{
    public static GameObject hoveringChosenDispatch;
    [SerializeField] public static GameObject whoScribbles;
    [SerializeField] public static GameObject whatScribbles;
    [SerializeField] public static GameObject whereScribbles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public static void FiguredOutWho()
    {
        whoScribbles.GetComponent<Animator>().SetTrigger("Found");
    }
    public static void FiguredOutWhere()
    {
        whereScribbles.GetComponent<Animator>().SetTrigger("Found");
    }
    public static void FiguredOutWhat()
    {
        whatScribbles.GetComponent<Animator>().SetTrigger("Found");
    }
}
