using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FullMission : MonoBehaviour
{
    public List<Missions> Mission;
    public string Name;
    public string Description;
    public bool Completed; 

    public void CheckMissions()
    {
        Completed = Mission.All(m => m.Completed);
        if (Completed)
        {
            FinishMission();
            Debug.Log("hi3");
        }
    }

    void FinishMission()
    {
        Debug.Log("Mission complete");
    }
}
