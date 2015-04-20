
/* Copyright (C) Team Newtons Aepfel- All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Marcel Ochsendorf <marcel.ochsendorf@gmail.com>,  
 */






using UnityEngine;
using System.Collections;

public class object_follower : MonoBehaviour {

	public Transform dest_transform;
  public Vector3 postion_correction;
	public bool include_rotation;
	// Use this for initialization
	void Start () 
  {
  
	}
	
	// Update is called once per frame
	void Update () 
  {
    this.transform.position = dest_transform.position + postion_correction ;
    
		if (include_rotation) 
    {
			this.transform.rotation = dest_transform.transform.rotation;		
		}

	}
}
