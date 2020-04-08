using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindMission : Missions
{
    public FindMission(FullMission fullMission, string description, bool completed, int currentAmount, int reqAmount)
    {
        this.FullMission = fullMission;
        this.Description = description;
        this.Completed = completed;
        this.CurrentAmount = currentAmount;
        this.ReqAmount = reqAmount;
    }

    public override void Init()
    {
        base.Init();
        GameEvents.current.onItemTrigger += ItemFound;
    }


    void ItemFound()
    {
        this.CurrentAmount++;
        Evaluate();
        Debug.Log("hi");
    }
}
