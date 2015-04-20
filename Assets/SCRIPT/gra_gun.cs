/* Copyright (C) Team Newtons Aepfel- All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Marcel Ochsendorf <marcel.ochsendorf@gmail.com>,  
 */







using UnityEngine;
using System.Collections;

public class gra_gun : MonoBehaviour {


  public GameObject particle_fixed_acticve;
  public GameObject particle_fixed;

  public GameObject particle_gravity_invert;
  public GameObject particle_gravity;

  public GameObject cube_tecture_object;
	private bool clicked;
	private Vector2 userTouch;
	public int raycast_range = 100;
	public string unique_name;
	public bool invert_gravity;
  public bool enable_gun;
	public Material fixed_cube_normal;
	public Material fixed_cube_fixed;
	public Material gravity_cube_normal;
  public Material gravity_cube_active;
  private Vector2 userMouse;
  public bool bullet_visible;
	private float counter;
	private float dist;
	public Transform origin_pos;
	public Transform destination_pos;
	public float speed;
	public GameObject shot_obj;
	private Vector3 point_along_line;
  public bool animation_process;
  public bool do_invert = false;
	public bool invert_type;
  public bool log;
  public string bullet_name;
  public static int object_id_number;
  public string origin_name;
  public bool origin_by_name;
  public bool disable_x_axis;
  public Vector3 saved_start_postion;
  public GameObject tutorialPartSysFixed;
  public GameObject tutorialPartSysInvert;



	void do_shot_main(){
    set_nex_axis();
		if (enable_gun && !animation_process && !do_invert && !level_manager.is_level_rotating && !level_manager.is_in_menu && !level_manager.is_spawning)
    {
      shot_obj.transform.position = origin_pos.transform.position;
      dist = Vector3.Distance(origin_pos.position, destination_pos.position);
     
      counter = 0;
      animation_process = true;
      do_invert = false;
      bullet_visible = true;
    }//end if 
  }



	public bool freeze_none;
		// Use this for initialization
		void Start () {
      //animation_process = false;
      if (origin_by_name)
      {
        origin_pos = GameObject.Find(origin_name).transform;
      }

   
     


      do_invert = false;
      animation_process = false;
			this.GetComponent<Rigidbody>().useGravity = false;
      bullet_visible = false;
		//this.name = unique_name;
      shot_obj.transform.position = origin_pos.transform.position;
		}


    public bool save_new_pos;
		void FixedUpdate() {


      if (origin_by_name)
      {
        origin_pos = GameObject.Find(origin_name).transform;
      }

   
/*


      if (saved_start_postion.x != this.transform.position.x && !level_manager.is_level_rotating)
      {
        this.transform.position = new Vector3(saved_start_postion.x, this.transform.position.y, this.transform.position.z);
      }
      else
      {
        set_nex_axis();
      }

      */


     








     

      if (disable_x_axis) { this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ; } else { this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ; }

			float gravity = Physics.gravity.magnitude;
		this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
		//this.rigidbody.constraints = RigidbodyConstraints.FreezePositionZ;

		if (invert_type) {
 
			this.GetComponent<Rigidbody>().useGravity = false;
						if (invert_gravity) {
              cube_tecture_object.transform.GetComponent<Renderer>().material = gravity_cube_active;
              particle_gravity_invert.gameObject.SetActive(true);
              particle_gravity.gameObject.SetActive(false);
				if(level_manager.is_tutorial == true)
				{
                 tutorialPartSysInvert.SetActive(false);
				}
							//	this.rigidbody.AddForce (-Physics.gravity);
              //this.rigidbody.AddForce(new Vector3(0, -Physics.gravity.y, 0), ForceMode.Acceleration);
              this.GetComponent<Rigidbody>().velocity = new Vector3(0, -Physics.gravity.y, 0);
              //this.rigidbody.AddForce(new Vector3(0, -Physics.gravity.y, 0), ForceMode.Impulse);
              //this.rigidbody.AddRelativeForce(new Vector3(0, -Physics.gravity.y, 0), ForceMode.Acceleration);
						} else {
              cube_tecture_object.transform.GetComponent<Renderer>().material = gravity_cube_normal;
              particle_gravity_invert.gameObject.SetActive(false);
              particle_gravity.gameObject.SetActive(true);
							//	this.rigidbody.AddForce (Physics.gravity);
              //this.rigidbody.AddForce(new Vector3(0, Physics.gravity.y, 0), ForceMode.Acceleration);
              this.GetComponent<Rigidbody>().velocity = new Vector3(0, Physics.gravity.y, 0);
             // this.rigidbody.AddForce(new Vector3(0, Physics.gravity.y, 0), ForceMode.Impulse);
              //this.rigidbody.AddRelativeForce(new Vector3(0, Physics.gravity.y, 0), ForceMode.Acceleration);
            


						}
				} else {
				

			if (invert_gravity) {
        cube_tecture_object.transform.GetComponent<Renderer>().material = fixed_cube_fixed;
        particle_fixed.gameObject.SetActive(false);
        particle_fixed_acticve.gameObject.SetActive(true);
				if (level_manager.is_tutorial == true)
				{
        			tutorialPartSysFixed.SetActive(false);
				}
				this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
				freeze_none = true;
				this.GetComponent<Rigidbody>().useGravity = false;
        this.GetComponent<Rigidbody>().isKinematic = true;
			} else {
        cube_tecture_object.transform.GetComponent<Renderer>().material = fixed_cube_normal;
        particle_fixed.gameObject.SetActive(true);
        particle_fixed_acticve.gameObject.SetActive(false);
				//this.rigidbody.useGravity = true;
        this.GetComponent<Rigidbody>().isKinematic = false;
        this.GetComponent<Rigidbody>().useGravity = false;
       // this.rigidbody.AddForce(new Vector3(0, Physics.gravity.y, 0));
       this.GetComponent<Rigidbody>().velocity = new Vector3(0, Physics.gravity.y, 0);
        //this.rigidbody.AddForce(new Vector3(0, Physics.gravity.y, 0), ForceMode.Impulse);

				if(freeze_none){
					this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;	
					this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
					freeze_none = false;

				}
			}
		}

      if (log)
      {
        Debug.Log("objectname:" + this.name + " gra_gun.cs : anim : " + animation_process + " invert:" + do_invert + " count : " + counter + " dist:" + dist);
      }
      if (animation_process) {
        if (counter < dist)
        {
          counter += 0.1f / speed;
          float x = Mathf.Lerp(0, dist, counter);
          Vector3 pointA = origin_pos.position;
          Vector3 pointB = destination_pos.position;
          point_along_line = x * Vector3.Normalize(pointB - pointA) + pointA;
          shot_obj.transform.position = point_along_line;


          if (saved_start_postion.x != this.transform.position.x)
          {
            this.transform.position = new Vector3(saved_start_postion.x, this.transform.position.y, this.transform.position.z);
          }



        }
        else {
          animation_process = false;
         // do_invert = true;
        } // end if





        if (shot_obj.transform.position == destination_pos.position)
        {
          shot_finish();
        }
        if (shot_obj.GetComponent<Collider>().bounds.Contains(destination_pos.position))
        {
          shot_finish();
        }
	



      }//end if
        shot_obj.SetActive(bullet_visible);
      if (do_invert && !animation_process)
      {
        invert_gravity = !invert_gravity;
        do_invert = false;
			//level_manager.add_throw();
      }

		level_manager.is_gra_gun_shooting = animation_process;
		}



		void Update() {
		//this.name = unique_name;




     // shot_obj = GameObject.Find(bullet_name + "_" + object_id_number);








    if (SystemInfo.deviceType == DeviceType.Desktop)
    {
      //we are on a desktop device, so don't use touch
      if (Input.GetButtonDown("Fire1"))
      {
      
        userMouse = Input.mousePosition;
        Ray userTouchRayM = Camera.main.ScreenPointToRay(userMouse);
        RaycastHit raycast_infoM;
        if (Physics.Raycast(userTouchRayM, out raycast_infoM, raycast_range))
        {
          if (raycast_infoM.collider.name == this.name)
          {
			GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play(AudioManager.AudioClipManaged.schuss, this.gameObject);
            do_shot_main();
           
          }
        }
      }
    }
    //if it isn't a desktop, lets see if our device is a handheld device aka a mobile device
    else if (SystemInfo.deviceType == DeviceType.Handheld)
    {
      //we are on a mobile device, so lets use touch input
      if (Input.touchCount > 0)
      {
        userTouch = Input.GetTouch(0).position;
        Ray userTouchRay = Camera.main.ScreenPointToRay(userTouch);
        RaycastHit raycast_info;
        if (Physics.Raycast(userTouchRay, out raycast_info, raycast_range))
        {
          if (raycast_info.collider.name == this.name)
          {
			GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play(AudioManager.AudioClipManaged.schuss, this.gameObject);
            do_shot_main();
           

          }
        }
      }
    }





  





		
		


} // ende update



    public void shot_finish() {
      animation_process = false;
      do_invert = true;
      bullet_visible = false;
    }

    public static void finish_animation()
    {
     // shot_finish();
    }




    void OnTriggerEnter(Collider other)
    {
      GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play(AudioManager.AudioClipManaged.cube_farbwechsel, this.gameObject);
      if (other == shot_obj)
      {
        
        shot_finish();
      }
    }
    void OnCollisionEnter(Collision other)
    {
      GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play(AudioManager.AudioClipManaged.cube_auftreffen, this.gameObject);
    }


    public void set_nex_axis() {
      saved_start_postion = this.transform.position; //save the start_position of the player the we can spawn the on them
    }




  
}
