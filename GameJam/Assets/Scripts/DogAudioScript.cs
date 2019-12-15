using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogAudioScript : MonoBehaviour
{
    public AudioSource AudioMaker;

    public AudioClip[] AudioDogWalk;

    public AudioClip[] AudioDogBark;

    public AudioClip[] AudioDogHa;

    private int WalkIndex;
    private int BarkIndex;
    private int HaIndex;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool DogAudioIsPlaying()
    {
        return AudioMaker.isPlaying;
    }

    public void PlayWalkAudio()
    {
        WalkIndex = PlayAudio(AudioDogWalk, WalkIndex);
    }

    public void PlayBarkAudio()
    {
        BarkIndex = PlayAudio(AudioDogBark, BarkIndex);
    }

    public void PlayHaAudio()
    {
        HaIndex = PlayAudio(AudioDogHa, HaIndex);
    }

    private int PlayAudio(AudioClip[] AudioArray,int Index)
    {
        int NewIndex = Index;
        if (NewIndex >= AudioArray.Length)
        {
            NewIndex -= AudioArray.Length;
        }

        AudioMaker.clip = AudioArray[NewIndex];
        AudioMaker.Play();
        NewIndex++;
        return NewIndex;
    }
}
