using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamesManager : MonoBehaviour
{
    public GameObject[] cells;
    // Start is called before the first frame update
    void Start()
    {
        GameSettings.turn = Enums.Turn.Player;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameSettings.turn == Enums.Turn.Computer) //This just doesnt check the cases if it isnt the players turn so they cant double move
        {
            return;
        }
        //This is ugly but it works. Gets the key pressed and stores the cell array position I want. If multiple pressed gets the latest one.
        int cell;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            cell = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            cell = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            cell = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            cell = 3;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            cell = 4;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            cell = 5;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            cell = 6;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            cell = 7;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            cell = 8;
        }
        else //This is so that if no valid move was made it ends and doesn't set the turn back to the computer
        {
            return;
        }
        cells[cell].GetComponent<CellManager>().IconChange(Enums.CellState.X);
        GameSettings.turn = Enums.Turn.Computer;
    }


}
