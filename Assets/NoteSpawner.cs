using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{

    public Vector2 spawnpos;
    public Vector2 removepos;
    public float beatofthisnote;
    public float beatsshowninadvance;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.Lerp(spawnpos, removepos,
            (beatsshowninadvance - (beatofthisnote - beat.instance.songPositionInBeats)) / beatsshowninadvance);
    }
}
