/* Copyright (C) Team Newtons Aepfel- All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Marcel Ochsendorf <marcel.ochsendorf@gmail.com>,  
 */







using UnityEngine;
using System.Collections;

public class z_axis_corrector : MonoBehaviour {


  public Vector3 saved_start_postion;
  public bool hold_axis_postion;
  public bool override_game_manager_config;
  public bool final_bool;


  public bool hold_y;
  public bool hold_x;
  public bool hold_z;
  public bool save_start_pos;
	// Use this for initialization
	void Start () {
    if (save_start_pos) { saved_start_postion = this.transform.position; } //save the start_position of the player the we can spawn the on them
	}
	
	// Update is called once per frame
	void Update () {

    if (override_game_manager_config)
    {
      final_bool = hold_axis_postion;
    }
    else
    {
      final_bool = game_manager.activate_z_axis_correction;
    }


    if (final_bool)
    {
      if (saved_start_postion.z != this.transform.position.z && hold_z)
      {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, saved_start_postion.z);
      }


      if (saved_start_postion.y != this.transform.position.z && hold_y)
      {
        this.transform.position = new Vector3(this.transform.position.x, saved_start_postion.y, this.transform.position.z);
      }

      if (saved_start_postion.x != this.transform.position.z && hold_x)
      {
        this.transform.position = new Vector3(saved_start_postion.x, this.transform.position.y, this.transform.position.z);
      }
    }








	}
}
