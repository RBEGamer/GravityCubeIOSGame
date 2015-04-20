/* Copyright (C) Team Newtons Aepfel- All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Marcel Ochsendorf <marcel.ochsendorf@gmail.com>,  
 */







using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {
	public float lifetime;
	// Use this for initialization
	void Start () {
		Destroy (gameObject,lifetime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
