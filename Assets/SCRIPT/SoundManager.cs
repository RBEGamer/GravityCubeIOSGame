using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour 
{
  public AudioSource[] audioSource;
  public bool pressurePlateInScene;
  public bool laserInScene;
	// Use this for initialization
	void Start () 
  {
	if(laserInScene)
    {
      audioSource[1].Play();
    }
	}
	
	// Update is called once per frame
	void Update () 
  {
    if (!laserInScene && audioSource[1].isPlaying)
    {
      audioSource[1].Stop();
      audioSource[2].Play();
    }
    else if (laserInScene && !audioSource[1].isPlaying)
    {
      audioSource[1].Play();
    }
	}

  public void PlaySounds(int index)
  {
      audioSource[index].Play();
    
  }
}
