using UnityEngine;
using System.Collections;

public class charakter_animation_manager : MonoBehaviour
{




  public enum animation_type
  {
    idle1, shot, walk, fall, landing, idle2, idle3, idle4
  }

  public enum walk_type
  {
    left, right
  }

  public float animation_walk_speed = 2.5f;
  public float animation_speed_normal = 1.0f;
  public float animation_speed_idle = 1.6f;
  public Transform left_walk_rotation;
  public Transform right_walk_rotation;
  public Transform top_rotation;
  public animation_type current_state;
  public walk_type walk_dir; // 0 = nicht // 1 = rechts // 2 = links // 3 == right-up // 4=  left_up
  bool playSound;

	public float soundTimer;
 bool startCounter = true;
  // Use this for initialization
  void Start()
  {
    current_state = animation_type.idle2;
    this.transform.localRotation = top_rotation.localRotation;
    playSound = true;

  }




  public void random_idle()
  {
 

    switch ( Random.Range(0, 4))

    {
      case 0:
        current_state = animation_type.idle1;
        break;

      case 1:
        current_state = animation_type.idle2;
        break;

      case 2:
        current_state = animation_type.idle3;
        break;

      case 3:
        current_state = animation_type.idle4;
        break;

      default:
        current_state = animation_type.idle2;
        break;
    }
  }


  // Update is called once per frame
  void Update()
  {
		if (startCounter == true) 
		{
			soundTimer -= Time.deltaTime;
			if(soundTimer <= 0)
			{
				soundTimer = Random.Range(30,50);

			}
		}


    switch (current_state)
    {
      case animation_type.idle1:
        this.GetComponent<Animation>()["idle_1"].speed = animation_speed_idle;
        this.transform.localRotation = top_rotation.localRotation;
        this.GetComponent<Animation>().Play("idle_1");
        if (GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().IsAudioSoundPlaying(AudioManager.AudioClipManaged.idle1, this.gameObject) == false)
        {

          if (soundTimer <= 1 && playSound == true && level_manager.is_in_menu == false && level_manager.is_spawning == false && Door_Animation.isFirstSoundFinished == true && GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().IsAudioSoundPlaying(AudioManager.AudioClipManaged.idle2, this.gameObject) == false && GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().IsAudioSoundPlaying(AudioManager.AudioClipManaged.grrIdle3, this.gameObject) == false && GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().IsAudioSoundPlaying(AudioManager.AudioClipManaged.idle4, this.gameObject) == false)
          {
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play(AudioManager.AudioClipManaged.idle1, this.gameObject);
            playSound = false;
          }
        }
        break;
      case animation_type.idle2:
        this.GetComponent<Animation>()["idle_2"].speed = animation_speed_idle;
        this.transform.localRotation = top_rotation.localRotation;
        this.GetComponent<Animation>().Play("idle_2");
        if (GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().IsAudioSoundPlaying(AudioManager.AudioClipManaged.idle2, this.gameObject) == false)
        {

				if (soundTimer <= 1 &&playSound == true && level_manager.is_in_menu == false && level_manager.is_spawning == false && Door_Animation.isFirstSoundFinished == true && Door_Animation.isFirstSoundFinished == true && GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().IsAudioSoundPlaying(AudioManager.AudioClipManaged.idle1, this.gameObject) == false && GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().IsAudioSoundPlaying(AudioManager.AudioClipManaged.grrIdle3, this.gameObject) == false && GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().IsAudioSoundPlaying(AudioManager.AudioClipManaged.idle4, this.gameObject) == false)
          {
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play(AudioManager.AudioClipManaged.idle2, this.gameObject);
            playSound = false;
          }
        }
        break;
      case animation_type.idle3:
        this.GetComponent<Animation>()["idle_3"].speed = animation_speed_idle;
        this.transform.localRotation = top_rotation.localRotation;
        this.GetComponent<Animation>().Play("idle_3");
        if (GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().IsAudioSoundPlaying(AudioManager.AudioClipManaged.grrIdle3, this.gameObject) == false)
        {

				if (soundTimer <= 1 &&playSound == true && level_manager.is_in_menu == false && level_manager.is_spawning == false && Door_Animation.isFirstSoundFinished == true && Door_Animation.isFirstSoundFinished == true && GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().IsAudioSoundPlaying(AudioManager.AudioClipManaged.idle2, this.gameObject) == false && GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().IsAudioSoundPlaying(AudioManager.AudioClipManaged.idle1, this.gameObject) == false && GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().IsAudioSoundPlaying(AudioManager.AudioClipManaged.idle4, this.gameObject) == false)
          {
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play(AudioManager.AudioClipManaged.grrIdle3, this.gameObject);
            playSound = false;
          }
        }
        break;
      case animation_type.idle4:
        this.GetComponent<Animation>()["idle_4"].speed = animation_speed_idle;
        this.transform.localRotation = top_rotation.localRotation;
        this.GetComponent<Animation>().Play("idle_4");
        if (GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().IsAudioSoundPlaying(AudioManager.AudioClipManaged.idle4, this.gameObject) == false)
        {
			
				if (soundTimer <= 1 &&playSound == true && level_manager.is_in_menu == false && level_manager.is_spawning == false && Door_Animation.isFirstSoundFinished == true && Door_Animation.isFirstSoundFinished == true && GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().IsAudioSoundPlaying(AudioManager.AudioClipManaged.idle2, this.gameObject) == false && GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().IsAudioSoundPlaying(AudioManager.AudioClipManaged.grrIdle3, this.gameObject) == false && GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().IsAudioSoundPlaying(AudioManager.AudioClipManaged.idle1, this.gameObject) == false)
          {
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play(AudioManager.AudioClipManaged.idle4, this.gameObject);
            playSound = false;
          }
        }
        break;
      case animation_type.shot:
        this.GetComponent<Animation>()["shot"].speed = animation_speed_normal;
        this.transform.localRotation = top_rotation.localRotation;
        this.GetComponent<Animation>().Play("shot");
        break;
      case animation_type.walk:
        this.GetComponent<Animation>()["walk"].speed = animation_walk_speed;
        this.GetComponent<Animation>().Play("walk");
        playSound = true;


        switch (walk_dir)
        {
          case walk_type.left:

            this.transform.localRotation = left_walk_rotation.localRotation;
            break;
          case walk_type.right:

            this.transform.localRotation = right_walk_rotation.localRotation;
            break;
          default:
            this.transform.localRotation = top_rotation.localRotation;
            break;
        }





        break;
      case animation_type.fall:
        this.GetComponent<Animation>()["fall"].speed = animation_speed_normal;
        this.transform.localRotation = top_rotation.localRotation;
        this.GetComponent<Animation>().Play("fall");
        break;
      case animation_type.landing:
        this.GetComponent<Animation>()["landing"].speed = animation_speed_normal;
        this.transform.localRotation = top_rotation.localRotation;
        this.GetComponent<Animation>().Play("landing");
        break;
      default:
        break;
    }

  }
}
