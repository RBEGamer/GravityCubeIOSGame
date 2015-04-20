
/* Copyright (C) Team Newtons Aepfel- All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Marcel Ochsendorf <marcel.ochsendorf@gmail.com>,  
 */






using UnityEngine;
using System.Collections;

public class player : MonoBehaviour
{
  private gravity_boots_manager gravity_boots_manager_script;
  public GameObject gravity_boots_manager;
  private Vector2 userMouse;

  public Vector3 player_speed_a; // links bewegung boden
  public Vector3 player_speed_d; // rechts bewgung boden
  public Vector3 player_speed_up; //hoch bewegung wand -> gravity boots
  public Vector3 player_speed_a_air; // links bewegung boden
  public Vector3 player_speed_d_air; // rechts bewgung boden




  public Material control_plane_up_enabled;
  public Material control_plane_up_disabled;


  public string goal_tag;
  public string enemy_tag;
  private Vector2 userTouch;
  public int raycast_range = 100;
  public GameObject control_plane_a;
  public GameObject control_plane_b;
  public string out_of_world_tag;
  public Vector3 saved_start_postion;
  public bool hold_z_axis_postion;
  public GameObject spawn_object_holder;
  public GameObject parkPosition;

  public GameObject charakter_controller;
  public GameObject anima;
  Door_Animation anima_script;
  private int randomNumber;
  

  public GameObject furz_partikel;

  

  public bool grav_boots_state;
  public bool grav_boots_prev_state;
  public int walk_dir;
  public bool is_up_dir;


  public float fall_animation_velocity;
  private charakter_animation_manager char_animation_script;


  private BoxCollider b;
  // Use this for initialization
  void Start()
  {
      
      control_plane_a = GameObject.Find("button_d");
      control_plane_b = GameObject.Find("button_c");
      spawn_object_holder = GameObject.Find("player_spawn");
      anima = GameObject.Find("Spawn_Point_v2");
      parkPosition = GameObject.Find("ParkPosition");
      

    furz_partikel.gameObject.SetActive(false);
    char_animation_script = charakter_controller.GetComponent<charakter_animation_manager>();
    char_animation_script.current_state = charakter_animation_manager.animation_type.idle2;
    anima_script = anima.GetComponent<Door_Animation>();

    anima_script.spawn();



    gravity_boots_manager_script = gravity_boots_manager.GetComponent<gravity_boots_manager>();
  }

  // Update is called once per frame
  void FixedUpdate()
  {

      

    if (hold_z_axis_postion)
    {
      if (saved_start_postion.z != this.transform.position.z)
      {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, saved_start_postion.z);
      }
    }


    if (!level_manager.is_level_rotating && !level_manager.is_spawning)
    {
      this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
      this.GetComponent<Rigidbody>().freezeRotation = true;
    }



    handle_inputs();

  }






  void OnCollisionEnter(Collision other)
  {
    //if the player collided with any object that has the enemy tag the player die and respawn
    if (other.transform.tag == enemy_tag)
    {
      die(true);
    }

    //if the player collided with an object that has the out of world tag the player respawn and the level is failed
    //if (other.transform.tag == out_of_world_tag) {die (true);}




  }


  void OnTriggerEnter(Collider other)
  {

    //if the player collided with the coal the level is complete and show the menu screen
    if (other.transform.tag == goal_tag)
    {
      this.transform.position = parkPosition.transform.position;
      GameObject.FindGameObjectWithTag("goal").GetComponent<Door_Animation>().OnTriggerEnter(other);
      randomNumber = Random.Range(1, 4);
        if(randomNumber == 1)
        {
          GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play(AudioManager.AudioClipManaged.youWin);
        }
        if (randomNumber == 2)
        {
          GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play(AudioManager.AudioClipManaged.youWin2);
        }
        if(randomNumber == 3)
        {
          GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play(AudioManager.AudioClipManaged.youWin3);
        }
      anima_script.SetDoorState(false);

      level_manager.level_complete();
    }


    if (other.transform.tag == enemy_tag)
    {
      die(true);
    }


  }


  //respawn the carakter first spawn the die_particles system then set the player postion to the player spawn position
  void die(bool level_failed)
  {
    this.transform.position = parkPosition.transform.position;
    
    if (level_failed) { level_manager.level_failed(); } else { anima_script.spawn(); }
    //reset velocity 
    //    this.rigidbody.velocity = Vector3.zero;
    //    this.rigidbody.angularVelocity = Vector3.zero;
    //this.transform.position = spawn_object_holder.transform.position; //set the player postion to the spawn point

    //Instantiate(death_particle_prefab, this.transform.position, Quaternion.Euler(270, 0, 0)); // set the particle system

  }
  //public void spawn()
  // {
  //   anima_script.spawn();
  //   renderer.enabled = true;
  // }














  // 0 = idle
  //1 = walk rechts
  //2 = walk up rechts
  //3 = walk links
  //4 = walk up links

  private bool local_a_key = false;
  private bool local_d_key = false;
  private bool local_r_wall = false;
  private bool local_l_wall = false;
  private bool local_mobile = false;
  private int intput_action = 0;
  private bool fall_anima = false;


  public bool anima_toggle;



  private void handle_inputs()
  {


 
    // if(this.rigidbody.rigidbody.velocity.y > )
    //  Input.GetKey(KeyCode.A) && !gravity_boots_manager_script.active_left

    local_r_wall = gravity_boots_manager_script.active_right;
    local_l_wall = gravity_boots_manager_script.active_left;
    // fall_anima = !gravity_boots_manager_script.active_final;

    if (SystemInfo.deviceType == DeviceType.Desktop)
    {
      local_mobile = false;
      local_a_key = Input.GetKey(KeyCode.A);
      local_d_key = Input.GetKey(KeyCode.D);

    }
    else if (SystemInfo.deviceType == DeviceType.Handheld)
    {
      local_mobile = true;

      if (Input.touchCount == 1)
      {
        userTouch = Input.GetTouch(0).position;
        Ray userTouchRay = Camera.main.ScreenPointToRay(userTouch);
        RaycastHit raycast_info;
        if (Physics.Raycast(userTouchRay, out raycast_info, raycast_range))
        {
          if (raycast_info.collider.gameObject == control_plane_a.gameObject)
          {
            local_a_key = true;
            local_d_key = false;
			
			if(level_manager.is_spawning == false && level_manager.is_tutorial == true && level_manager.is_tutorial1 == true
						   )
			{
				
			TutorialLevel1.secondInput = true;
			GameObject.FindGameObjectWithTag("Tutorial1").GetComponent<TutorialLevel1>().fingerLeftActiv = false;
			}
          }
          else if (raycast_info.collider.gameObject == control_plane_b.gameObject)
          {
            local_a_key = false;
            local_d_key = true;
			
			if(level_manager.is_spawning == false && level_manager.is_tutorial == true && level_manager.is_tutorial1 == true)
			{
			TutorialLevel1.firstInput = true;
			if(TutorialLevel1.firstInput == true && TutorialLevel1.secondInput == false)
			{
				GameObject.FindGameObjectWithTag("Tutorial1").GetComponent<TutorialLevel1>().fingerLeftActiv = true;
			}
				GameObject.FindGameObjectWithTag("Tutorial1").GetComponent<TutorialLevel1>().fingerRightActiv = false;
			}
			
          }
          else
          {
            local_a_key = false;
            local_d_key = false;
          }

        }

      }
      else
      {
        local_a_key = false;
        local_d_key = false;
      }
      //ende raycast

    }//ende touch







    if (this.GetComponent<Rigidbody>().GetComponent<Rigidbody>().velocity.y < fall_animation_velocity && ((!local_a_key && !local_l_wall) || (!local_d_key && !local_r_wall)))
    {
      fall_anima = true;
    }
    else
    {
      fall_anima = false;
    }










    intput_action = get_input_action(local_a_key, local_d_key, local_r_wall, local_l_wall);
   // intput_action = get_input_action(false, true, local_r_wall, local_l_wall);
    if (fall_anima)
    {
      set_animation(5);
    }
    else
    {
      set_animation(intput_action);
    }

    move_char(intput_action, fall_anima);
  }


  private void set_animation(int type)
  {

    if (type == 0)
    {
      if (anima_toggle == true)
      {
        char_animation_script.random_idle();
        anima_toggle = false;
      }
      else
      {

      }


     /// char_animation_script.current_state = charakter_animation_manager.animation_type.idle2;
      furz_partikel.gameObject.SetActive(false);
    }
    else if (type == 1)
    {
      char_animation_script.current_state = charakter_animation_manager.animation_type.walk;
      char_animation_script.walk_dir = charakter_animation_manager.walk_type.right;

      furz_partikel.gameObject.SetActive(false);

      anima_toggle = true;
    }
    else if (type == 2)
    {
     // char_animation_script.current_state = charakter_animation_manager.animation_type.walk;
      //char_animation_script.walk_dir = charakter_animation_manager.walk_type.right_up;
     // char_animation_script.current_state = charakter_animation_manager.animation_type.fall;
      furz_partikel.gameObject.SetActive(true);    
      anima_toggle = true;            
    }

    else if (type == 3)
    {
      char_animation_script.current_state = charakter_animation_manager.animation_type.walk;
      char_animation_script.walk_dir = charakter_animation_manager.walk_type.left;
      furz_partikel.gameObject.SetActive(false);
       anima_toggle = true;

    }

    else if (type == 4)
    {
     // char_animation_script.current_state = charakter_animation_manager.animation_type.walk;
    //  char_animation_script.walk_dir = charakter_animation_manager.walk_type.left_up;
      char_animation_script.current_state = charakter_animation_manager.animation_type.fall;
      furz_partikel.gameObject.SetActive(true);
      anima_toggle = true;


    }

    else if (type == 5)
    {
      char_animation_script.current_state = charakter_animation_manager.animation_type.fall;
      furz_partikel.gameObject.SetActive(false);
      anima_toggle = true;

    }

    else if (type == 6)
    {
      char_animation_script.current_state = charakter_animation_manager.animation_type.landing;
      furz_partikel.gameObject.SetActive(false);
      anima_toggle = true;

    }
    else
    {
      furz_partikel.gameObject.SetActive(false);
    }



  }


  private void move_char(int type, bool falling)
  {



    if (falling)
    {
      if (type == 0) { }
      else if (type == 1) { this.GetComponent<Rigidbody>().position += player_speed_d_air; }
      else if (type == 2) { this.GetComponent<Rigidbody>().AddForce(player_speed_up); }
      else if (type == 3) { this.GetComponent<Rigidbody>().position += player_speed_a_air; }
      else if (type == 4) { this.GetComponent<Rigidbody>().AddForce(player_speed_up); }
    }
    else
    {


      if (type == 0) { }
      else if (type == 1) { this.GetComponent<Rigidbody>().position += player_speed_d; }
      else if (type == 2) { this.GetComponent<Rigidbody>().AddForce(player_speed_up); }
      else if (type == 3) { this.GetComponent<Rigidbody>().position += player_speed_a; }
      else if (type == 4) { this.GetComponent<Rigidbody>().AddForce(player_speed_up); }

    }

  

  }




  private int get_input_action(bool key_a, bool key_b, bool wall_rechts, bool wall_links)
  {

         if (!key_a && !key_b && !wall_rechts && wall_links) { return 0; }
    else if (!key_a && !key_b && wall_rechts && !wall_links) { return 0; }
    else if (!key_a && !key_b && wall_rechts && wall_links) { return 0; }
    else if (!key_a && key_b && !wall_rechts && !wall_links) { return 1; }
    else if (!key_a && key_b && !wall_rechts && wall_links) { return 1; }
    else if (!key_a && key_b && wall_rechts && !wall_links) { return 2; }
    else if (!key_a && key_b && wall_rechts && wall_links) { return 0; }
    else if (key_a && !key_b && !wall_rechts && !wall_links) {return 3;}
    else if (key_a && !key_b && !wall_rechts && wall_links) { return 4; }
    else if (key_a && !key_b && wall_rechts && !wall_links) { return 3; }
    else if (key_a && !key_b && wall_rechts && wall_links) { return 0; }
    else if (key_a && key_b && !wall_rechts && !wall_links) { return 0; }
    else if (key_a && key_b && wall_rechts && !wall_links) { return 0; }
    else if (key_a && key_b && wall_rechts && !wall_links) { return 0; }
    else if (key_a && key_b && wall_rechts && wall_links) { return 0; }
    else { return 0; }



  }



}
