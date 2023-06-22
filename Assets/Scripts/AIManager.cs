using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    public GameObject[] cells; 
    private int bestMove;
    private int myScore = 0;
    private int opponentScore = 0;
    public int maxDepth = 4;
    private Enums.Winner fakeWinner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameSettings.turn == Enums.Turn.Computer)
        {
            List<int> moves = GetMoves();
            cells[moves[0]].GetComponent<CellManager>().IconChange(Enums.CellState.O);
            GameSettings.turn = Enums.Turn.Player;
        }
    }

    private List<int> GetMoves()
    {
        List<int> tempMoves = new List<int>();
        for(int i = 0; i < cells.Length; i++)
        {
            if (cells[i].GetComponent<CellManager>().State == Enums.CellState.Empty) //If any cells are empty it adds them
            {
                tempMoves.Add(i);
            }
        }
        return tempMoves;
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
        fakeWinner = Enums.Winner.Draw;
    }

    private void match(int cell1, int cell2, int cell3)
    {
        if (cells[cell1].GetComponent<CellManager>().State == Enums.CellState.X &&
         cells[cell2].GetComponent<CellManager>().State == Enums.CellState.X &&
         cells[cell3].GetComponent<CellManager>().State == Enums.CellState.X) //This checks if the three inputted cells all show X
        {
            fakeWinner = Enums.Winner.Player;
        }
        else if (cells[cell1].GetComponent<CellManager>().State == Enums.CellState.O &&
         cells[cell2].GetComponent<CellManager>().State == Enums.CellState.O &&
         cells[cell3].GetComponent<CellManager>().State == Enums.CellState.O) //This checks if the three inputted cells all show 0
        {
            fakeWinner = Enums.Winner.Computer;
        }
    }

}
