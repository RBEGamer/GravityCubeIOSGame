/* Copyright (C) Team Newtons Aepfel- All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Marcel Ochsendorf <marcel.ochsendorf@gmail.com>,  
 */


using UnityEngine;
using System.Collections;

public class portal_manager : MonoBehaviour {
  public float port_delay;
  float time_left;
  public bool portal_state;
	// Use this for initialization
	void Start () {
    portal_state = false;
    time_left = port_delay;
	}
	
	// Update is called once per frame
	void Update () {

    //Debug.Log(portal_state);
    if (portal_state)
    {
      //Debug.Log(time_left);
      time_left -= Time.deltaTime;
      if (time_left <= 0)
      {
        portal_state = false;
        time_left = port_delay;
      }
    }
	}


  public void ported()
  {
   // Debug.Log("porteed");

    time_left = port_delay;
    portal_state = true;
  }
}
