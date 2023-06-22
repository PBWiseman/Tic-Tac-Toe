using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CellManager : MonoBehaviour
{

    public GameObject XIcon;
    public GameObject OIcon;

    // Start is called before the first frame update
    void Start()
    {
        XIcon.SetActive(false);
        OIcon.SetActive(false);
    }

    public void IconChange(Enums.CellState state)
    {
        if (state == Enums.CellState.X)
        {
            XIcon.SetActive(true);
        }
        else if (state == Enums.CellState.O)
        {
            OIcon.SetActive(true);
        }
        else if (state == Enums.CellState.Empty)
        {
            XIcon.SetActive(false);
            OIcon.SetActive(false);
        }
    }
}
