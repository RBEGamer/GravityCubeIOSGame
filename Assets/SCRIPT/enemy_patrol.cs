/* Copyright (C) Team Newtons Aepfel- All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Marcel Ochsendorf <marcel.ochsendorf@gmail.com>,  
 */







using UnityEngine;
using System.Collections;

public class enemy_patrol : MonoBehaviour {


	public Transform[] way_points;
	private int current_point;
	public int start_point;
	public float move_speed;
  public bool enable_patrol;
	public bool include_rotation;
	// Use this for initialization
	void Start () {
		this.transform.position = way_points [start_point].position;
		current_point = start_point;
	}
	
	// Update is called once per frame
	void Update () {
	
						if (this.transform.position == way_points [current_point].position) {
								if (current_point < way_points.Length - 1) {
										current_point++;
								} else {
										current_point = 0;
								}
						}
            if (!level_manager.is_in_menu && enable_patrol)
            {
						
			this.transform.position = Vector3.MoveTowards (this.transform.position, way_points [current_point].position, move_speed * Time.deltaTime);
			if(include_rotation){
				this.transform.rotation =  way_points [current_point].rotation;
			}


				}
	}
}
