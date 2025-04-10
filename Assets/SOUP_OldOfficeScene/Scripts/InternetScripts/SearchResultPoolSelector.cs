using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchResultPoolSelector : MonoBehaviour
{
    [SerializeField] GameObject[] poolHolders;
    public GameObject poolUsed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SelectPool(int poolToUse)
    {
        poolUsed = poolHolders[poolToUse];
    }
}
