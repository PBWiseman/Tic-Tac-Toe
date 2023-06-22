using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    public GameObject[] cells; 
    private Stack<int> moveStack = new Stack<int>();
    private int bestMove;
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
            fakeWinner = Enums.Winner.None;
            bestMove = 0;
            CalculateMinMax(maxDepth, true);
            cells[bestMove].GetComponent<CellManager>().IconChange(Enums.CellState.O);
            GameSettings.turn = Enums.Turn.Player;
            GamesManager.Instance.StateCheck();
        }
    }

    private Enums.Winner CalculateMinMax(int depth, bool max)
    {
        if (depth == 0)
        {
            evaluate();
            return fakeWinner;
        }
        if (max)
        {
            Enums.Winner maxScore = Enums.Winner.Player;
            List<int> moves = GetMoves();
            foreach(int move in moves)
            {
                moveStack.Push(move);

                fakeMove(move, Enums.CellState.O);
                Enums.Winner tempWinner = CalculateMinMax(depth -1, false);
                undoFakeMove();

                if (tempWinner > maxScore)
                {
                    maxScore = tempWinner;
                }

                if (tempWinner > fakeWinner && depth == maxDepth)
                {
                    bestMove = move;
                }
            }
            return maxScore;
        }
        else
        {
            Enums.Winner minScore = Enums.Winner.Computer;
            List<int> moves = GetMoves();
            foreach(int move in moves)
            {
                moveStack.Push(move);

                fakeMove(move, Enums.CellState.X);
                Enums.Winner tempWinner = CalculateMinMax(depth -1, false);
                undoFakeMove();

                if (tempWinner < minScore)
                {
                    minScore = tempWinner;
                }
                return minScore;
            }
        }
        return Enums.Winner.None;
    }

    private void fakeMove(int cell, Enums.CellState enter)
    {
        cells[cell].GetComponent<CellManager>().FakeState = enter;
    }

    private void undoFakeMove()
    {
        int tempMove = moveStack.Pop();
        cells[tempMove].GetComponent<CellManager>().FakeState = Enums.CellState.Empty;
    }

    private void evaluate()
    {
        //Checks all possible fake sets.
        fakeMatch(0,1,2);
        fakeMatch(3,4,5);
        fakeMatch(6,7,8);

        fakeMatch(0,3,6);
        fakeMatch(1,4,7);
        fakeMatch(2,5,8);

        fakeMatch(0,4,8);
        fakeMatch(2,4,6);
    }

    private List<int> GetMoves()
    {
        List<int> tempMoves = new List<int>();
        for(int i = 0; i < cells.Length; i++)
        {
            if (cells[i].GetComponent<CellManager>().FakeState == Enums.CellState.Empty) //If any cells are empty it adds them
            {
                tempMoves.Add(i);
            }
        }
        return tempMoves;
    }

    private void fakeMatch(int cell1, int cell2, int cell3)
    {
        if (cells[cell1].GetComponent<CellManager>().FakeState == Enums.CellState.X &&
         cells[cell2].GetComponent<CellManager>().FakeState == Enums.CellState.X &&
         cells[cell3].GetComponent<CellManager>().FakeState == Enums.CellState.X) //This checks if the three inputted cells all show X
        {
            fakeWinner = Enums.Winner.Player;
        }
        else if (cells[cell1].GetComponent<CellManager>().FakeState == Enums.CellState.O &&
         cells[cell2].GetComponent<CellManager>().FakeState == Enums.CellState.O &&
         cells[cell3].GetComponent<CellManager>().FakeState == Enums.CellState.O) //This checks if the three inputted cells all show 0
        {
            fakeWinner = Enums.Winner.Computer;
        }
    }

}
