/* Copyright (C) Team Newtons Aepfel- All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Marcel Ochsendorf <marcel.ochsendorf@gmail.com>,  
 */







using UnityEngine;
using System.Collections;

public class soud_manager : MonoBehaviour {







 
  public  GameObject menu_click;
  static AudioSource src_menu_click;
	// Use this for initialization
	void Start () {
    DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {
     src_menu_click = menu_click.GetComponent<AudioSource>();
	}



  public static  void play_menu_click()
  {



      src_menu_click.Play();
    

  }



 
}
