/* Copyright (C) Team Newtons Aepfel- All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Marcel Ochsendorf <marcel.ochsendorf@gmail.com>,  
 */







using UnityEngine;
using System.Collections;

public class gui_score_text : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
  
    //GUI.Label(new Rect(Screen.width - TextWidth, 10, TextWidth, 22), "Text");
    this.GetComponent<GUIText>().text = "Throws:" + level_manager.throws + "/" + level_manager.max_throws + " Stars:" + level_manager.earned_stars + " level_orientation:" + level_manager.level_orientation + " is_moving:" + level_manager.is_any_cube_moving + " enable_gravity_gun:" + level_manager.enable_gravity_boots; 
    //this.guiText.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0));
	}
}
