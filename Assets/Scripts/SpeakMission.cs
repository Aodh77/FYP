using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakMission : Missions
{
    public string ItemID;
    //public string itemName;

    private void Start()
    {
        //GameObject Spawner = GameObject.Find("Spawner");
        //VoiceSpawner voiceSpawner = Spawner.GetComponent<VoiceSpawner>();
        //itemName = voiceSpawner.ItemName;
    }
    public SpeakMission(FullMission fullMission, string itemID, string description, bool completed, int currentAmount, int reqAmount)
    {
        this.FullMission = fullMission;
        this.ItemID = itemID;
        this.Description = description;
        this.Completed = completed;
        this.CurrentAmount = currentAmount;
        this.ReqAmount = reqAmount;
    }

    public override void Init()
    {
        base.Init();
        GameEvents.current.onItemSpawn += VoiceSpawn;
    }

    void VoiceSpawn()
    {
        
            this.CurrentAmount++;
            Evaluate();
            Debug.Log("chair mission");
        
    }
}
