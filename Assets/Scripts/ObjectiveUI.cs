using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveUI : MonoBehaviour
{
    public static bool InstructionOn = false;

    public GameObject InstructionMenu;

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if (InstructionOn)
            {
                Resume();
            }
            else
            {
                OpenMenu();
            }
        }



    }

    public void Resume()
    {
        InstructionMenu.SetActive(false);
        InstructionOn = false;
    }

    public void OpenMenu()
    {
        InstructionMenu.SetActive(true);
        InstructionOn = true;
    }
}
