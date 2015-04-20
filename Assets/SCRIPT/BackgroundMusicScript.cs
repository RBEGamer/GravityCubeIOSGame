using UnityEngine;
using System.Collections;

public class BackgroundMusicScript : MonoBehaviour 
{

  public bool main_menu = false;
  public float switch_delay = 20;
  private float delay_counter;
  public GameObject music_holder;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        music_holder.gameObject.SetActive(false);
    }

	// Use this for initialization
	void Start () 
    {
      delay_counter = 0;
        //if (!is_music_running)
        //{
        //    music_holder.gameObject.SetActive(true);
        //    //is_music_running = true;
        //}
        
	}
	
	// Update is called once per frame
  void Update()
  {
    
      //if(is_music_running == true)
      //{
      //    music_holder.gameObject.SetActive(false);
      //}
      if(main_menu == false)
      {

        delay_counter = delay_counter + Time.deltaTime;

		if (delay_counter >= switch_delay && GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().IsAudioSoundPlaying(AudioManager.AudioClipManaged.intro1)==false)
        {
          music_holder.gameObject.SetActive(true);
          Application.LoadLevel("main_menu");
          main_menu = true;
        }
		if(Input.anyKeyDown)
			{
				music_holder.gameObject.SetActive(true);
				GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().StopSound(AudioManager.AudioClipManaged.intro1);
				Application.LoadLevel("main_menu");
				main_menu = true;
			}

      }
      
  }
}
