/* Copyright (C) Team Newtons Aepfel- All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Marcel Ochsendorf <marcel.ochsendorf@gmail.com>,  
 */







using UnityEngine;
using System.Collections;

public class ios_button_enabler : MonoBehaviour {




  /* this code activates the ios names buttons if the game running on mobile devices
   * in the gamemanager script you can set the ios_buttons to true if you want so enable the buttons
   * also you can activate the buttons if the game is running on a pc,mac,linux system to play the gamewith the mouse to activate this
   * set in the gamemanager the disable_ios_buttons_on_pc variable to true
   * 
  */
  public GameObject button_holder;
  // Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
    if (game_manager.ios_buttons)
    {
      if ( SystemInfo.deviceType == DeviceType.Desktop && !game_manager.disable_ios_buttons_on_pc)
      {
        button_holder.gameObject.SetActive(true);
      }
      else
      {
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
          button_holder.gameObject.SetActive(true);
        }
        else
        {
          button_holder.gameObject.SetActive(false);
        }
        
      }
    }
    else
    {
      button_holder.gameObject.SetActive(false);
    }
	}
}
