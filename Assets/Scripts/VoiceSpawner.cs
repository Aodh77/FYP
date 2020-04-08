using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceSpawner : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    
    public  string ItemName;
    public Transform Spawnpoint;
    public GameObject prefab;
    public GameObject prefab2;

    private void Start()
    {
       

        actions.Add("chair", SpawnChair);
        actions.Add("mirror", SpawnMirror);

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecongizedSpeech;
        keywordRecognizer.Start();
    }

    private void RecongizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    private void SpawnChair()
    {
        Instantiate(prefab, Spawnpoint.position, Spawnpoint.rotation);
        GameEvents.current.itemSpawn();
        ItemName = "chair";
    }

    private void SpawnMirror()
    {
        Instantiate(prefab2, Spawnpoint.position, Spawnpoint.rotation);
        GameEvents.current.itemSpawn();
        ItemName = "Mirror";
    }
}
