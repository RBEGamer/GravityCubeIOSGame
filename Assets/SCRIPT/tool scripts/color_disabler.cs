using UnityEngine;
using System.Collections;

public class color_disabler : MonoBehaviour {
  public GameObject colors_holder;
  public GameObject to_disable;
  private colors colors_holder_script;

  public colors.ColorTemplate colors_set;
	// Use this for initialization
	void Start () {
    colors_holder_script = colors_holder.GetComponent<colors>();
	}
	
	// Update is called once per frame
  void Update()
  {


    if (colors_holder_script.selected_color == colors_set)
    {
      to_disable.gameObject.SetActive(true);
    }
    else
    {
      to_disable.gameObject.SetActive(false);
    }

  


  }  
}
