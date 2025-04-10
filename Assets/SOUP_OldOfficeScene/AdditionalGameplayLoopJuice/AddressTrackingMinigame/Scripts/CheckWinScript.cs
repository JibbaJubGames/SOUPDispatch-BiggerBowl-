using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckWinScript : MonoBehaviour
{
    public Color serializedWinColor;
    public static Color winColor;

    public static Animator statusAnim;

    public PlayerResponses addressTrigger;
    // Start is called before the first frame update
    void Start()
    {
        winColor = serializedWinColor;

        statusAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void CheckForWin(GameObject currentCell)
    {
        if (currentCell.GetComponent<Image>().color == winColor)
        {
            statusAnim.SetTrigger("BeatMaze");
        }
        else return;
    }

    public void BeatMazePlayerResponse()
    {
        addressTrigger.AddressMinigameResult(1);
    }
}
