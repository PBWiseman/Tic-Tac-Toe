using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CellManager : MonoBehaviour
{

    public GameObject XIcon;
    public GameObject OIcon;
    public Enums.CellState State;

    // Start is called before the first frame update
    void Start()
    {
        XIcon.SetActive(false);
        OIcon.SetActive(false);
        State = Enums.CellState.Empty;
    }

    public void IconChange(Enums.CellState state)
    {
        State = state;
        if (State == Enums.CellState.X)
        {
            XIcon.SetActive(true);
        }
        else if (State == Enums.CellState.O)
        {
            OIcon.SetActive(true);
        }
        else if (State == Enums.CellState.Empty)
        {
            XIcon.SetActive(false);
            OIcon.SetActive(false);
        }
    }
}
