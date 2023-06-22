using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamesManager : MonoBehaviour
{
    public GameObject[] cells;
    public Enums.Winner winner;
    // Start is called before the first frame update
    void Start()
    {
        GameSettings.turn = Enums.Turn.Player;
        winner = Enums.Winner.None;
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
        StateCheck();
        GameSettings.turn = Enums.Turn.Computer;
    }

    public void StateCheck()
    {
        drawCheck(); //This is called first so that if all cells are filled but someone wins it will set winner to draw and then to the actual winner
        winCheck();
        switch (winner)
        {
            case Enums.Winner.Player:
                Debug.Log("Player wins");
                break;
            case Enums.Winner.Computer:
                Debug.Log("CPU wins");
                break;
            case Enums.Winner.Draw:
                Debug.Log("Draw");
                break;
        }
    }

    private void winCheck() //Checks if a win
    {
        //Checks all possible sets
        match(0,1,2);
        match(3,4,5);
        match(6,7,8);

        match(0,3,4);
        match(1,4,7);
        match(2,5,8);

        match(0,4,8);
        match(2,4,6);
    }

    private void drawCheck()
    {
        foreach(GameObject cell in cells)
        {
            if (cell.GetComponent<CellManager>().State == Enums.CellState.Empty) //If any cells are empty it plays on
            {
                return;
            }
        }
        winner = Enums.Winner.Draw;
    }

    private void match(int cell1, int cell2, int cell3)
    {
        if (cells[cell1].GetComponent<CellManager>().State == Enums.CellState.X &&
         cells[cell2].GetComponent<CellManager>().State == Enums.CellState.X &&
         cells[cell3].GetComponent<CellManager>().State == Enums.CellState.X) //This checks if the three inputted cells all show X
        {
            winner = Enums.Winner.Player;
        }
        else if (cells[cell1].GetComponent<CellManager>().State == Enums.CellState.O &&
         cells[cell2].GetComponent<CellManager>().State == Enums.CellState.O &&
         cells[cell3].GetComponent<CellManager>().State == Enums.CellState.O) //This checks if the three inputted cells all show 0
        {
            winner = Enums.Winner.Computer;
        }
    }

}
