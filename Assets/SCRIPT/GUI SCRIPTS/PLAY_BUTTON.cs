/* Copyright (C) Team Newtons Aepfel- All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Marcel Ochsendorf <marcel.ochsendorf@gmail.com>,  
 */




using UnityEngine;
using System.Collections;

public class PLAY_BUTTON : MonoBehaviour {


	
	private bool clicked;
	private Vector2 userTouch;
	public int raycast_range = 100;
	private Vector2 userMouse;

    private float waitTime = 0.05f;
    bool waitTimeStarted = false;

	// Use this for initialization
	void Start () 
    {
        AudioManager.SetGameObjectTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update () 
    {
	if(waitTimeStarted)
    {
        this.waitTime -= Time.deltaTime;
        if(waitTimeStarted == true && waitTime <= 0.0f)
        {
            game_manager.goto_main_menu(); game_manager.goto_menu(); 
        }
    }

		
		
		
		if (SystemInfo.deviceType == DeviceType.Desktop )
		{
			//we are on a desktop device, so don't use touch
			if (Input.GetButtonDown("Fire1"))
			{
				
				userMouse = Input.mousePosition;
				Ray userTouchRayM = Camera.main.ScreenPointToRay(userMouse);
				RaycastHit raycast_infoM;
				if (Physics.Raycast(userTouchRayM, out raycast_infoM, raycast_range))
				{




          if (raycast_infoM.collider.gameObject == this.gameObject) 
          {
              AudioManager.GetObjectTag().Play(AudioManager.AudioClipManaged.ui_Click);
              waitTimeStarted = true;
          }
					
					
					
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




          if (raycast_info.collider.gameObject == this.gameObject) 
          {
              AudioManager.GetObjectTag().Play(AudioManager.AudioClipManaged.ui_Click);
              waitTimeStarted = true;
          }
					
					
					
				}
			}
		}
		




	}
}
