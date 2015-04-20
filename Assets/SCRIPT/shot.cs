/* Copyright (C) Team Newtons Aepfel- All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Marcel Ochsendorf <marcel.ochsendorf@gmail.com>,  
 */







using UnityEngine;
using System.Collections;

public class shot : MonoBehaviour {

	private float counter;
	private float dist;
	public Transform origin_pos;
	public Transform destination_pos;
	public float speed;
	public float final_dist;


	// Use this for initialization
	void Start () {
		do_shot ();
	}




	public void do_shot(){

		dist = Vector3.Distance(origin_pos.position,destination_pos.position);
		final_dist = dist;
	}


	void Update () {

		if(counter < dist){
			counter += 0.1f / speed;
			float x = Mathf.Lerp(0, dist, counter);
			Vector3 pointA = origin_pos.position;
			Vector3 pointB = destination_pos.position;
			
			Vector3 point_along_line = x * Vector3.Normalize(pointB - pointA) + pointA;
			this.transform.position = point_along_line;

			
		}


	}
}
