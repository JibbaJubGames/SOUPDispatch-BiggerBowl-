using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckFailScript : MonoBehaviour
{
    public static int strikeCount;

    public Image[] strikes;
    public static Image[] staticStrikes = new Image[3];

    public Sprite failedStrike;
    public static Sprite staticFailedStrike;
    public Sprite greyStrike;
    public static Sprite staticGreyStrike;

    public static Animator statusAnim;
    // Start is called before the first frame update
    void Start()
    {
        staticStrikes[0] = strikes[0];
        staticStrikes[1] = strikes[1];
        staticStrikes[2] = strikes[2];

        staticFailedStrike = failedStrike;
        staticGreyStrike = greyStrike;

        statusAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void HitWall()
    {
        strikeCount++;
        FailedMaze();
    }

    public static void FailedMaze()
    {
        if (strikeCount == 3)
        {
            Debug.Log("We failed :(");
            statusAnim.SetTrigger("FailedMaze");
            //To do: 
        }
        else Debug.Log($"Strike {strikeCount}");
    }

    public static void UpdateStrikeCount()
    {
        if (strikeCount == 1)
        {
            staticStrikes[0].sprite = staticFailedStrike;
            Debug.Log("Strike one should be red");
        }
        else if (strikeCount == 2)
        {
            staticStrikes[1].sprite = staticFailedStrike;
            Debug.Log("Strike two should be red");
        }
        else if (strikeCount == 3)
        {
            staticStrikes[2].sprite = staticFailedStrike;
            Debug.Log("Strike three should be red");
        }
        else if (strikeCount == 0)
        {
            staticStrikes[0].sprite = staticGreyStrike;
            staticStrikes[1].sprite = staticGreyStrike;
            staticStrikes[2].sprite = staticGreyStrike;
        }
    }
}
