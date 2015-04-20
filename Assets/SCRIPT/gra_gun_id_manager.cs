/* Copyright (C) Team Newtons Aepfel- All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Marcel Ochsendorf <marcel.ochsendorf@gmail.com>,  
 */







using UnityEngine;
using System.Collections;

public class gra_gun_id_manager : MonoBehaviour {

  public string tag_name_invert; //here is the tag name for the invert cubes
  public string rename_to_invert; //and here is the final name of the found objects
  public string tag_name_fixed;//here is the tag name for the fixed position cubes
  public string rename_to_fixed;//and here is the final name of the found objects
  //the counters for the ending letter like _0, _1, _2
	private int counter1 = 0; 
	private int counter2 = 0;
	public  int counter_start; //here you can change the counter start eg to start at 5 to 10
	public static  bool make_update; // if that true all objects going to rename
    
	// Use this for initialization
	void Start () {
		rename_objects (); //start the rename cycle
	}
	
	// Update is called once per frame
	void Update () { 
		if (make_update) {
			make_update = false;
			rename_objects ();
		}  
	}



	void rename_objects(){
    //reset the counters
		counter1 = counter_start; 
		counter2 = counter_start;
    //find all objects with the specific tags and then rename the object to the destination string wither counter end
		foreach(GameObject go in GameObject.FindGameObjectsWithTag(tag_name_invert)) {
			go.name = rename_to_invert + "_" + counter1;
			counter1++;
		}
    //find all objects with the specific tags and then rename the object to the destination string wither counter end	
		foreach(GameObject go in GameObject.FindGameObjectsWithTag(tag_name_fixed)) {
			go.name = rename_to_fixed + "_" + counter2;
			counter2++;
		}
	}
    
}
