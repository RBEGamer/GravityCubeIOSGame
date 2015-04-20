
using UnityEngine;
using System.Collections;

public class Door_Animation : MonoBehaviour 
{
   // Animator anim;
    bool anima_state;
    bool idle = true;
    public bool isSpawnpoint;
    bool isFinished = false;
    public GameObject spawn_object_holder;
    public GameObject player_obj;
    public GameObject goal;
    public bool openAtStart;
   public GameObject state_object;
   private int randomNumber;
   bool playSound;
   public static bool isFirstSoundFinished;


	// Use this for initialization
	void Start () 
    {
      playSound = true;
      isFirstSoundFinished = false;
        player_obj = GameObject.FindGameObjectWithTag("Player");
      state_object.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
      //  player_script = player_obj.GetComponent<player>();
        if (isSpawnpoint == false)
        {
            goal.SetActive(false);
        }
        GetComponent<Animation>().Play("Idle");
        if (isSpawnpoint == true)
        {
            GetComponent<Animation>().Play("Open");
            state_object.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        }
        if(openAtStart == true)
        {
            GetComponent<Animation>().Play("Open");
            state_object.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
            if(GetComponent<Animation>().IsPlaying("Open")== false)
            {
                GetComponent<Animation>().Play("OpenIdle");
            }
            goal.SetActive(true);
        }
        randomNumber = Random.Range(1, 4);
        
        //player_obj.renderer.enabled = false;    
	}
    

	// Update is called once per frame
	void Update () 
    {

        if (isSpawnpoint == false)
        {
            if (anima_state && !idle)
            {
                this.GetComponent<Animation>().wrapMode = WrapMode.Once;
                this.GetComponent<Animation>().Play("Open");
                state_object.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
                idle = true;
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 0);
            }
            else if (!anima_state && !idle)
            {
                this.GetComponent<Animation>().wrapMode = WrapMode.Once;
                this.GetComponent<Animation>().Play("Close");
                state_object.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
                idle = true;
            }
          if(GetComponent<Animation>().IsPlaying("Idle")== true)
          {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 2);
          }
        }
        
        if (isSpawnpoint == true)
        {
          if (this.GetComponent<Animation>().IsPlaying("Open") == false && GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().IsAudioSoundPlaying(AudioManager.AudioClipManaged.tür, this.gameObject)==false)
          {

            
            // player_script.spawn();
                if (!isFinished)
                {
                  level_manager.is_spawning = false;
                    GetComponent<Animation>().Play("OpenIdle");
                    player_obj.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    player_obj.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                    player_obj.transform.position = spawn_object_holder.transform.position;//set the player postion to the spawn point
                    if (playSound == true)
                    {
                     
                      if (randomNumber == 1)
                      {
                        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play(AudioManager.AudioClipManaged.spawn1, this.gameObject);
                        
                      }
                      if (randomNumber == 2)
                      {
                        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play(AudioManager.AudioClipManaged.spawn2, this.gameObject);
                        
                      }
                      if (randomNumber == 3)
                      {
                        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play(AudioManager.AudioClipManaged.spawn3, this.gameObject);
                        
                      }
                      playSound = false;
                    }
                
                    isFinished = true;
                }
                if (randomNumber == 1 && GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().IsAudioSoundPlaying(AudioManager.AudioClipManaged.spawn1, this.gameObject) == false)
                {
                  isFirstSoundFinished = true;
                 // Debug.Log(isFirstSoundFinished);
                }
                if (randomNumber == 2 && GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().IsAudioSoundPlaying(AudioManager.AudioClipManaged.spawn2, this.gameObject) == false)
                {
                  isFirstSoundFinished = true;
              //    Debug.Log(isFirstSoundFinished);
                }
                if (randomNumber == 3 && GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().IsAudioSoundPlaying(AudioManager.AudioClipManaged.spawn3, this.gameObject) == false)
                {
                  isFirstSoundFinished = true;
              //    Debug.Log(isFirstSoundFinished);
                }

                

            }
        }
 
   
	}

    public bool doorOpen { get { return anima_state; } }
  
    public void SetDoorState(bool open)
    {
        if (open)
        {
            idle = false;
            anima_state = true;
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play(AudioManager.AudioClipManaged.tür, this.gameObject);
            if (isSpawnpoint == false && this.GetComponent<Animation>().IsPlaying("Open") == false)
            {
                goal.SetActive(true);
            }
        } else
        {
            idle = false;
            anima_state = false;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (isSpawnpoint == true)
        {
            GetComponent<Animation>().Play("Close");
            state_object.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 2);
        }
        //if (isSpawnpoint == false)
        //{
        //    animation.Play("Close");
        //}
        GetComponent<Collider>().enabled = false;
    }

    public void spawn()
    {
        if (isSpawnpoint == true)
        {
            GetComponent<Animation>().Play("Open");
            state_object.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play(AudioManager.AudioClipManaged.tür,this.gameObject);            
            isFinished = false;
        }
        
    }
    public void OnTriggerEnter(Collider other)
    {

        if (other.transform.tag == "goal" && isSpawnpoint == false)
        {
            
            GetComponent<Animation>().Play("Close");
            state_object.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        }
        
    }

    


}
