/* Copyright (C) Team Newtons Aepfel- All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Marcel Ochsendorf <marcel.ochsendorf@gmail.com>,  
 */






using UnityEngine;
using System.Collections;

public class pause_button : MonoBehaviour {


	private bool clicked;
	private Vector2 userTouch;
	public int raycast_range = 100;
	private Vector2 userMouse;


  public Material resume;
  public Material pause;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
		if (level_manager.is_level_failed ||  level_manager.is_won) {
					this.GetComponent<Renderer>().enabled = false;
						this.GetComponent<Collider>().enabled = false;
				} else {
				
		
			this.GetComponent<Renderer>().enabled = true;
			this.GetComponent<Collider>().enabled = true;

			if (level_manager.is_in_menu)
			{
				this.transform.GetComponent<Renderer>().material = resume;
				//this.renderer.enabled = false;
			}
			else
			{
				this.transform.GetComponent<Renderer>().material = pause;
				//this.renderer.enabled = true;
			}




		
		}





		/*
    if ( level_manager.is_in_menu)
    {
      this.renderer.enabled = false;
		
    }
    else
    {
      this.renderer.enabled = true;
		
    }
*/



		if (SystemInfo.deviceType == DeviceType.Desktop )
		{
			//we are on a desktop device, so don't use touch
			if (Input.GetButtonDown("Fire1") && !level_manager.is_level_failed)
			{
				userMouse = Input.mousePosition;
				Ray userTouchRayM = Camera.main.ScreenPointToRay(userMouse);
				RaycastHit raycast_infoM;
				if (Physics.Raycast(userTouchRayM, out raycast_infoM, raycast_range))
				{
					if (raycast_infoM.collider.gameObject == this.gameObject){level_manager.is_in_menu = !level_manager.is_in_menu;}		
				}
			}
		}
		//if it isn't a desktop, lets see if our device is a handheld device aka a mobile device
		else if (SystemInfo.deviceType == DeviceType.Handheld )
		{
			//we are on a mobile device, so lets use touch input
      if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
			{
				userTouch = Input.GetTouch(0).position;
				Ray userTouchRay = Camera.main.ScreenPointToRay(userTouch);
				RaycastHit raycast_info;
				if (Physics.Raycast(userTouchRay, out raycast_info, raycast_range))
				{
					if (raycast_info.collider.gameObject == this.gameObject){level_manager.is_in_menu = !level_manager.is_in_menu;}
				}
			}
		}





	}
}
