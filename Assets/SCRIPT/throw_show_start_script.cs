
/* Copyright (C) Team Newtons Aepfel- All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Marcel Ochsendorf <marcel.ochsendorf@gmail.com>,  
 */






using UnityEngine;
using System.Collections;

public class throw_show_start_script : MonoBehaviour {



	public int star_id;
	public string star_name_prefix;
	public static int current_earned_stars;
	// Use this for initialization
	void Start () {
		this.name =  star_name_prefix + "_" + star_id;
	}
	
	// Update is called once per frame
	void Update () {
		current_earned_stars = level_manager.earned_stars;

		//if (level_manager.is_in_menu) {
		
		if(current_earned_stars >= star_id){
				this.gameObject.SetActive(true);
			}else{
				this.gameObject.SetActive(false);
			}


		//}
	}
}
