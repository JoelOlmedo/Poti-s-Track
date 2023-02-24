using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class beat : MonoBehaviour
{
    //Song beats per minute
    //This is determined by the song you're trying to sync up to
    public float songBpm;

    //The number of seconds for each song beat
    public float secPerBeat;

    //Current song position, in seconds
    public float songPosition;

    //Current song position, in beats
    public float songPositionInBeats;

    //How many seconds have passed since the song started
    public float dspSongTime;

    //the number of beats in each loop
    public float beatsPerLoop;

    //the total number of loops completed since the looping clip first started
    public int completedLoops = 0;

    //The current position of the song within the loop in beats.
    public float loopPositionInBeats;

    public float loopPositionInAnalog;

    public static beat instance;

    public GameObject nodePrefab;

    //an AudioSource attached to this GameObject that will play the music.
    public AudioSource musicSource;

    float bpm;
    float[] notes = {1f,2f,2.5f,3f,3.5f,4.5f};
    int nextIndex = 0;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        //Load the AudioSource attached to the Conductor GameObject
        musicSource = GetComponent<AudioSource>();

        //Calculate the number of seconds in each beat
        secPerBeat = 60f / songBpm;

        //Record the time when the music starts
        dspSongTime = (float)AudioSettings.dspTime;

        //Start the music
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (songPositionInBeats >= (completedLoops + 1) * beatsPerLoop)
            completedLoops++;
        loopPositionInBeats = songPositionInBeats - completedLoops * beatsPerLoop;

        //determine how many seconds since the song started
        songPosition = (float)(AudioSettings.dspTime - dspSongTime - 9);

        //determine how many beats since the song started
        songPositionInBeats = songPosition / secPerBeat;

        if (nextIndex < notes.Length && notes[nextIndex] < songPositionInBeats + 3)
        {
            MusicNote musicNote = ((GameObject) Instantiate(nodePrefab, Vector2.zero, Quaternion.identity)).GetComponent<MusicNote>();


            //initialize the fields of the music note

            nextIndex++;
        }

        loopPositionInAnalog = loopPositionInBeats / beatsPerLoop;
    }


}
