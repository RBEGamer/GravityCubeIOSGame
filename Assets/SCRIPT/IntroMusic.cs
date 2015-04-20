using UnityEngine;
using System.Collections;

public class IntroMusic : MonoBehaviour 
{
    
	// Use this for initialization
	void Start () 
    {
        AudioManager.SetGameObjectTag("AudioManager");
        AudioManager.GetObjectTag().Play(AudioManager.AudioClipManaged.intro1);
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
