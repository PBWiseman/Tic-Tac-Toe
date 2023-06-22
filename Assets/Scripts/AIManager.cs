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
            GamesManager.Instance.StateCheck();
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
}
