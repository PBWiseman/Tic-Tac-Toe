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


    public void IconChange(char activate)
    {
        if (activate == 'X')
        {
            XIcon.SetActive(true);
        }
        else if (activate == 'O')
        {
            OIcon.SetActive(true);
        }
        else if (activate == 'E')
        {
            XIcon.SetActive(false);
            OIcon.SetActive(false);
        }
        else 
        {
            Debug.Log("Error. Wrong char:");
            Debug.Log(activate);
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("Mouse Click Detected");
    }
}
