using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMission : MonoBehaviour
{
    [SerializeField] private GameObject mission;
    [SerializeField] private string missionType;
    private FullMission FullMission;

    void AssignMission()
    {
        FullMission = (FullMission)mission.AddComponent(System.Type.GetType(missionType));
    }
}
