using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroGuaranteeScript : MonoBehaviour
{
    public bool initialized = false;

    [SerializeField]
     public static Dictionary<int, int> necessaryHeroDays = new Dictionary<int, int>();

    [SerializeField]
    public int[] heroesThatWillBeNecessary;


    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        if (!initialized)
        {
            necessaryHeroDays.Add(3, heroesThatWillBeNecessary[0]);
            initialized = true;
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
