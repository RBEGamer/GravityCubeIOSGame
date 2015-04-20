/* Copyright (C) Team Newtons Aepfel- All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Marcel Ochsendorf <marcel.ochsendorf@gmail.com>,  
 */







using UnityEngine;
using System.Collections;

public class new_gravity_script : MonoBehaviour {


  public bool active;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
    if (active)
    {
     this.GetComponent<Rigidbody>().velocity = new Vector3(0, Physics.gravity.y, 0);
      if (this.GetComponent<Rigidbody>().useGravity) { this.GetComponent<Rigidbody>().useGravity = false; }
     if (this.GetComponent<Rigidbody>().isKinematic) { this.GetComponent<Rigidbody>().isKinematic = true; } 

    }
    else
    {
      if (!this.GetComponent<Rigidbody>().useGravity) { this.GetComponent<Rigidbody>().useGravity = true; }
      if (this.GetComponent<Rigidbody>().isKinematic) { this.GetComponent<Rigidbody>().isKinematic = false; }
    }



	}
}
