/* Copyright (C) Team Newtons Aepfel- All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Marcel Ochsendorf <marcel.ochsendorf@gmail.com>,  
 */







using UnityEngine;
using System.Collections;

public class level_settings : MonoBehaviour {



  public float settings_max_throws;
  public float settings_percent_first_star;
  public float settings_percent_second_star;
  public float settings_percent_third_star;
  public static bool settings_enable_gravity_boots;



  public bool set_settings_in_update;
	// Use this for initialization
	void Start () {
    set_settings();
	}
	
	// Update is called once per frame
	void Update () {
    if (set_settings_in_update)
    {
      set_settings();
    }
	}



  void set_settings()
  {
    level_manager.max_throws = settings_max_throws;
   // level_manager.percent_first_star = settings_percent_first_star;
   // level_manager.percent_second_star = settings_percent_second_star;
   // level_manager.percent_first_star = settings_percent_third_star;
    //level_manager.enable_gravity_boots = settings_enable_gravity_boots;
  }
}
