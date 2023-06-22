using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamesManager : MonoBehaviour
{
    public GameObject[] cells;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //This is ugly but it works
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            cells[0].GetComponent<CellManager>().IconChange('X');
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            cells[1].GetComponent<CellManager>().IconChange('X');
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            cells[2].GetComponent<CellManager>().IconChange('X');
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            cells[3].GetComponent<CellManager>().IconChange('X');
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            cells[4].GetComponent<CellManager>().IconChange('X');
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            cells[5].GetComponent<CellManager>().IconChange('X');
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            cells[6].GetComponent<CellManager>().IconChange('X');
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            cells[7].GetComponent<CellManager>().IconChange('X');
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            cells[8].GetComponent<CellManager>().IconChange('X');
        }

    }


}
