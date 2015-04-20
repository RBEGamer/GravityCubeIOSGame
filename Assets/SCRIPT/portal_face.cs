/* Copyright (C) Team Newtons Aepfel- All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Marcel Ochsendorf <marcel.ochsendorf@gmail.com>,  
 */







using UnityEngine;
using System.Collections;

public class portal_face : MonoBehaviour {


  public GameObject other_portal_pivot;
  public bool is_this_the_blue_portal;
  public string player_tag;
  public GameObject player_object;
  public bool find_player_by_tag;
  public bool isTeleporting = false;
  public Vector3 saved_object_height;
  public GameObject portal_manager_script_holder;
  private portal_manager portal_manager_script;

 
 // public GameObject burst_particles;

  //private ParticleSystem particlesystem;

	// Use this for initialization
	void Start () {

    isTeleporting = false;
    //get the player object by tag
    if (find_player_by_tag)
    {
      player_object = GameObject.FindGameObjectWithTag(player_tag);
    }
    portal_manager_script = portal_manager_script_holder.GetComponent<portal_manager>();
   // other_burst_portal_particles = other_burst_portal.GetComponent<ParticleSystem>();
   // particlesystem = other_burst_portal.GetComponent<ParticleSystem>();

	}
	
	// Update is called once per frame
	void Update () {




	}



  void OnCollisionStay(Collision other)
  {


   


 //   if (other.gameObject == player_object)
 //   {
    if (!isTeleporting && !portal_manager_script.portal_state)
  //  if (!isTeleporting )
      {
   //     burst_particles.SetActive(true);
        //(Instantiate(burst_particles, other_portal_pivot.transform.position, Quaternion.identity);
      
        portal_manager_script.ported();
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play(AudioManager.AudioClipManaged.teleport, this.gameObject);
        saved_object_height = other.gameObject.transform.position;
       // other_portal.transform.position = new Vector3(other_portal.transform.position.x, saved_object_height.y, other.transform.position.z);
      //  burst_particles.SetActive(false);
        TeleportTo(other.gameObject);
       
      }

   // burst_particles.SetActive(false);
      isTeleporting = false;
      
  //  }

  }



  public void TeleportTo(GameObject g)
  {
    // Teleporting
    g.transform.position = other_portal_pivot.transform.position - (other_portal_pivot.transform.up * 0.65f);
    g.GetComponent<Rigidbody>().velocity = other_portal_pivot.transform.up * g.GetComponent<Rigidbody>().velocity.magnitude;
     g.GetComponent<Rigidbody>().velocity =  g.GetComponent<Rigidbody>().velocity;
    isTeleporting = true;
  }



}
