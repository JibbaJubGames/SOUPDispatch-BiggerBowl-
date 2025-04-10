using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MazeNavigationScript : MonoBehaviour
{
    public GameObject currentCell;
    public Transform playerDot;

    public Color blockadeColor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoLeft()
    {
        if (currentCell.GetComponent<SurroundingCellsScript>().cellLeft.GetComponent<Image>().color == blockadeColor)
        {
            CheckFailScript.HitWall();
            HitWallAnimScript.HitWallAnim("HitLeftWall");
            return;
        }
        else
        {
            playerDot.SetParent(currentCell.GetComponent<SurroundingCellsScript>().cellLeft.transform);
            currentCell = currentCell.GetComponent<SurroundingCellsScript>().cellLeft;
            playerDot.transform.position = currentCell.transform.position;
            CheckWinScript.CheckForWin(currentCell);
        }        
    }

    public void GoRight()
    {
        if (currentCell.GetComponent<SurroundingCellsScript>().cellRight.GetComponent<Image>().color == blockadeColor)
        {
            CheckFailScript.HitWall();
            HitWallAnimScript.HitWallAnim("HitRightWall");
            return;
        }
        else
        {
            playerDot.SetParent(currentCell.GetComponent<SurroundingCellsScript>().cellRight.transform);
            currentCell = currentCell.GetComponent<SurroundingCellsScript>().cellRight;
            playerDot.transform.position = currentCell.transform.position;
            CheckWinScript.CheckForWin(currentCell);
        }        
    }

    public void GoUp()
    {
        if (currentCell.GetComponent<SurroundingCellsScript>().cellAbove.GetComponent<Image>().color == blockadeColor)
        {
            CheckFailScript.HitWall();
            HitWallAnimScript.HitWallAnim("HitUpperWall");
            return;
        }
        else
        {
            playerDot.SetParent(currentCell.GetComponent<SurroundingCellsScript>().cellAbove.transform);
            currentCell = currentCell.GetComponent<SurroundingCellsScript>().cellAbove;
            playerDot.transform.position = currentCell.transform.position;
            CheckWinScript.CheckForWin(currentCell);
        }        
    }

    public void GoDown()
    {
        if (currentCell.GetComponent<SurroundingCellsScript>().cellBelow.GetComponent<Image>().color == blockadeColor)
        {
            CheckFailScript.HitWall();
            HitWallAnimScript.HitWallAnim("HitLowerWall");
            return;
        }
        else
        {
            playerDot.SetParent(currentCell.GetComponent<SurroundingCellsScript>().cellBelow.transform);
            currentCell = currentCell.GetComponent<SurroundingCellsScript>().cellBelow;
            playerDot.transform.position = currentCell.transform.position;
            CheckWinScript.CheckForWin(currentCell);
        } 
    }
}
