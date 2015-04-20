/* Copyright (C) Team Newtons Aepfel- All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Marcel Ochsendorf <marcel.ochsendorf@gmail.com>,  
 */

using UnityEngine;
using System.Collections;

public class scale_setter : MonoBehaviour {

  
  public  float scale_z = 1.5f;
	// Use this for initialization
	void Start () {
    this.transform.localScale = new Vector3(this.transform.localScale.x, this.transform.localScale.y, scale_z);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
