using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enums : MonoBehaviour
{
    public enum Turn
    {
        Player, //0
        Computer, //1
        None, //2
    }

    public enum CellState
    {
        Empty, //0
        X, //1
        O, //2
    }

    public enum Winner
    {
        None, //0    
        Player, //1
        Draw, //2
        Computer, //3
    }
}
