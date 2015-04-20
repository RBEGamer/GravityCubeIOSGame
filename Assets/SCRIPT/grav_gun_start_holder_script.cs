/* Copyright (C) Team Newtons Aepfel- All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Marcel Ochsendorf <marcel.ochsendorf@gmail.com>,  
 */







using UnityEngine;
using System.Collections;

public class grav_gun_start_holder_script : MonoBehaviour {




	public GameObject start_pos;
	// Use this for initialization
	void Start () {
		this.transform.position = start_pos.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = start_pos.transform.position;
	}
}
