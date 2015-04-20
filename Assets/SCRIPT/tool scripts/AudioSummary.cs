using UnityEngine;
using System.Collections;

// Version: 1.0 by Sebastian
// Initial Version

[System.Serializable]
// class/struct which contains information about one single audioClip
public class SoundSummary 
{
    public AudioManager.AudioClipManaged name; // name of the audio-clip, which is defined in AudioCollector enum
    public AudioClip clip; // the real audio file, .wav / .mp3 / whatever
	public float volume;
	public float panLevel;
	public int priority;
	public bool loop;

}
