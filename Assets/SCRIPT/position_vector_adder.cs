/* Copyright (C) Team Newtons Aepfel- All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Marcel Ochsendorf <marcel.ochsendorf@gmail.com>,  
 */







using UnityEngine;
using System.Collections;

public class position_vector_adder : MonoBehaviour {



  public Vector3 add_pos;
  public GameObject pivot;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
    this.transform.position =new Vector3( this.transform.position.x, add_pos.y + pivot.transform.position.y, this.transform.position.z);
	}
}
