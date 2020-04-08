using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missions : MonoBehaviour
{
    public FullMission FullMission;
    public string Description;
    public bool Completed;
    public int CurrentAmount;
    public int ReqAmount; 

    public virtual void Init()
    {

    }

    public void Evaluate()
    {
        if (CurrentAmount >= ReqAmount)
        {
            Complete();
            Debug.Log("hi2");
        }
    }


    public void Complete()
    {
        FullMission.CheckMissions();
        Completed = true;
        Debug.Log("hiii");
    }
}
