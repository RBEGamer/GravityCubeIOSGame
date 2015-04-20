using UnityEngine;
using System.Collections;

public class LaserSound : MonoBehaviour 
{
  public bool isLaserOn;
	// Use this for initialization
	void Start () 
  {
    playSounds();
    
	}
	
	// Update is called once per frame
	void Update () 
  {
    
	}
  public void playSounds()
  {
    if (isLaserOn == true)
    {
      GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play(AudioManager.AudioClipManaged.laser, this.gameObject);
    }
    if (isLaserOn == false)
    {
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().StopSound(AudioManager.AudioClipManaged.laser, this.gameObject);
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play(AudioManager.AudioClipManaged.laserAus, this.gameObject);
    }
  }
}
