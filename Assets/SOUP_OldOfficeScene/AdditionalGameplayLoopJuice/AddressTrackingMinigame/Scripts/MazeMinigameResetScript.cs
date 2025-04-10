using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeMinigameResetScript : MonoBehaviour
{
    public MazeSelectionScript mazeSelectionScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetAddressTrackMinigame()
    {
        CheckFailScript.strikeCount = 0;
        CheckFailScript.UpdateStrikeCount();
        mazeSelectionScript.SelectMaze();
    }
}
