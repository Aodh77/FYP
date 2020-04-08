using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Room1 : FullMission
{
    private void Start()
    {
        Name = "Room 1 mission";
        Description = " put 2 objects in the zone";


        

        Mission = new List<Missions>
        {
            new FindMission(this, "find bedside table", false, 0, 1),
            new SpeakMission(this, "chair", "spawn chair", false, 0, 1)
        };

        Mission.ForEach(g => g.Init());
    }
}
