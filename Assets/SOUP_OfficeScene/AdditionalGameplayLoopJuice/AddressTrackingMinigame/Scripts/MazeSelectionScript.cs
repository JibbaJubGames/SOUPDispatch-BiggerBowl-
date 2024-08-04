using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeSelectionScript : MonoBehaviour
{
    public GameObject[] mazeList;
    public GameObject selectedMaze;
    public int mazeChoice;

    public Transform mazeScreenCenter;
    // Start is called before the first frame update
    void Start()
    {
        SelectMaze();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectMaze()
    {
        mazeChoice = Random.Range(0, mazeList.Length);
        selectedMaze = GameObject.Instantiate(mazeList[mazeChoice], mazeScreenCenter);       
    }
}
