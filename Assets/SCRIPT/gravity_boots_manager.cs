/* Copyright (C) Team Newtons Aepfel- All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Marcel Ochsendorf <marcel.ochsendorf@gmail.com>,  
 */







using UnityEngine;
using System.Collections;

public class gravity_boots_manager : MonoBehaviour {

 
  public GameObject raycaster_right;
  public GameObject raycaster_left;
  public GameObject raycaster_bottom;
  public bool active_right;
  public bool active_left;
  public bool active_bottom;
  public bool active_final;
  public string walls_tag;
  public bool tmp;

  gravity_boots_raycaster raycaster_right_script;
  gravity_boots_raycaster raycaster_left_script;
  gravity_boots_raycaster raycaster_bottom_script;
	// Use this for initialization
	void Start () {
	 raycaster_right_script = raycaster_right.GetComponent<gravity_boots_raycaster>();
    raycaster_left_script = raycaster_left.GetComponent<gravity_boots_raycaster>();

    raycaster_bottom_script = raycaster_bottom.GetComponent<gravity_boots_raycaster>();

    raycaster_right_script.enableTagcheck = true;
    raycaster_right_script.tagCheck = walls_tag;
    raycaster_left_script.enableTagcheck = true;
    raycaster_left_script.tagCheck = walls_tag;
  }
	
	// Update is called once per frame
	void Update () {

    active_right = raycaster_right_script.active;
    active_left = raycaster_left_script.active;


    if(!active_right && !active_left)
    {
      tmp = true;
    }
   

    if (tmp)
    {
      active_bottom = raycaster_bottom_script.active;
      tmp = false;
    }
    else
    {
      active_bottom = true;
    }


    if (level_manager.enable_gravity_boots && !level_manager.is_level_rotating)
    {
      if (active_right || active_left)
      {
        if (active_bottom)
        {
          active_final = true;
        }
        else
        {
          active_final = false;
        }

      }
      else
      {
        active_final = false;
      }
    }
    else {
      active_final = false;
    }//ende levelmanager_enable








	}//ende update
}//ende class
