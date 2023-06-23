using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    public GameObject[] cells; 
    private Stack<int> moveStack = new Stack<int>();
    private int bestMove;
    private int bestMoveScore;
    public int maxDepth = 4;
    public static AIManager Instance;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void AIMove()
    {
        bestMove = 9; //Impossible move. Will be changed
        bestMoveScore = int.MinValue;
        CalculateMinMax(maxDepth, true);
        cells[bestMove].GetComponent<CellManager>().IconChange(Enums.CellState.O);
    }

    private int CalculateMinMax(int depth, bool max) //I have no idea why this isn't working.
    {
        if (depth == 0)
        {
            return evaluate();
        }
        if (max)
        {
            int maxScore = int.MinValue;
            List<int> moves = GetMoves();
            foreach(int move in moves)
            {
                moveStack.Push(move);

                fakeMove(move, Enums.CellState.O);
                int score = CalculateMinMax(depth - 1, false);
                undoFakeMove();

                if (score > maxScore)
                {
                    maxScore = score;
                }

                if (score > bestMoveScore && depth == maxDepth)
                {
                    bestMoveScore = score;
                    bestMove = move;
                }
            }
            return maxScore;
        }
        else
        {
            int minScore = int.MaxValue;
            List<int> moves = GetMoves();
            foreach(int move in moves)
            {
                moveStack.Push(move);

                fakeMove(move, Enums.CellState.X);
                int score = CalculateMinMax(depth -1, false);
                undoFakeMove();

                if (score < minScore)
                {
                    minScore = score;
                }
            }
            return minScore;
        }
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

    private int evaluate()
    {
        Enums.Winner fakeWinner = Enums.Winner.None;
        fakeWinner = fakeDraw(); //Checks if all cells are filled. If so it will be a draw if not set to someone winning
        //Checks all possible fake sets.
        fakeWinner = fakeMatch(0,1,2,fakeWinner);
        fakeWinner = fakeMatch(3,4,5,fakeWinner);
        fakeWinner = fakeMatch(6,7,8,fakeWinner);

        fakeWinner = fakeMatch(0,3,6,fakeWinner);
        fakeWinner = fakeMatch(1,4,7,fakeWinner);
        fakeWinner = fakeMatch(2,5,8,fakeWinner);

        fakeWinner = fakeMatch(0,4,8,fakeWinner);
        fakeWinner = fakeMatch(2,4,6,fakeWinner);   
        switch (fakeWinner)
        {
            case Enums.Winner.Player:
                return -1;
            case Enums.Winner.Draw:
                return 0;
            case Enums.Winner.None:
                return 1;
            case Enums.Winner.Computer:
                return 2;
            default:
                return 999; //This is just here so I dont get an error about missing return paths. Should never be used.
        }
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

    private Enums.Winner fakeMatch(int cell1, int cell2, int cell3, Enums.Winner currentWinner)
    {
        if (currentWinner == Enums.Winner.None || currentWinner == Enums.Winner.Draw) //If there hasn't already been a winner found
        {
            if (cells[cell1].GetComponent<CellManager>().FakeState == Enums.CellState.X &&
            cells[cell2].GetComponent<CellManager>().FakeState == Enums.CellState.X &&
            cells[cell3].GetComponent<CellManager>().FakeState == Enums.CellState.X) //This checks if the three inputted cells all show X
            {
                return Enums.Winner.Player;
            }
            else if (cells[cell1].GetComponent<CellManager>().FakeState == Enums.CellState.O &&
            cells[cell2].GetComponent<CellManager>().FakeState == Enums.CellState.O &&
            cells[cell3].GetComponent<CellManager>().FakeState == Enums.CellState.O) //This checks if the three inputted cells all show 0
            {
                return Enums.Winner.Computer;
            }
        }
        return currentWinner;
    }

    private Enums.Winner fakeDraw()
    {
        foreach(GameObject cell in cells)
        {
            if (cell.GetComponent<CellManager>().FakeState == Enums.CellState.Empty) //If any cells are empty it plays on
            {
                return Enums.Winner.None;
            }
        }
        return Enums.Winner.Draw;
    }


}
