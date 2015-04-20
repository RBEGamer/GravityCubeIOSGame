using UnityEngine;
using System.Collections;

public class disable_in_menu : MonoBehaviour {
  public GameObject obj_to_disable;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
    if (level_manager.is_in_menu)
    {
      obj_to_disable.gameObject.SetActive(false);
    }
    else
    {
      obj_to_disable.gameObject.SetActive(true);
    }
	}
}
