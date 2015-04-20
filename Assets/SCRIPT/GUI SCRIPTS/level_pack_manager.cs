using UnityEngine;
using System.Collections;

public class level_pack_manager : MonoBehaviour {

  
  public int pack_nr;
  public int button_per_pack;
	// Use this for initialization

  


	void Start () {
    int range_min = (pack_nr*button_per_pack)+1;
       int range_max =  (pack_nr*button_per_pack)+button_per_pack;
	//this.name = "level_pack_button_holder_" + range_min + "-" + range_max;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
