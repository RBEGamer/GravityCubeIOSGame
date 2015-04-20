/* Copyright (C) Team Newtons Aepfel- All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Marcel Ochsendorf <marcel.ochsendorf@gmail.com>,  
 */





using UnityEngine;
using System.Collections;

public class MOUSE_OVER : MonoBehaviour {


  private bool clicked;
  public int raycast_range = 100;
  private Vector2 userMouse;
  public bool is_over;
  public float speed;
  public GameObject button;


  public float rotationAmount = 20f;
  public float rot_max = 45f;
  public Vector3 rot;

  public bool toggle_1;
	// Use this for initialization
	void Start () {
  
	}
	
	// Update is called once per frame
	void FixedUpdate () {


	}


  void Update()
  {


    if (SystemInfo.deviceType == DeviceType.Desktop)
    {

    
    
    is_over = false;
    userMouse = Input.mousePosition;
    Ray userTouchRayM = Camera.main.ScreenPointToRay(userMouse);
    RaycastHit raycast_infoM;
    if (Physics.Raycast(userTouchRayM, out raycast_infoM, raycast_range))
    {
      if (raycast_infoM.collider.name == button.name) { is_over = true; } else { is_over = false; }
    }







    if (is_over)
    {
      if (rot.y < rot_max)
      {
        rot = transform.rotation.eulerAngles; rot.y = rot.y + rotationAmount * Time.deltaTime;
        transform.eulerAngles = rot;

        //rot.y -= 360;
      }
      else //if (rot.y < 360)
      {
       // rot.y += 360;


        if (rot.y > 182.5f)
        {
          rot.y = 0;
        }


      }
  
    }
    else
    {
      //!over






      if (rot.y > 0)
      {
        rot = transform.rotation.eulerAngles; rot.y = rot.y - rotationAmount * Time.deltaTime;
        transform.eulerAngles = rot;

        //rot.y -= 360;
      }
      else //if (rot.y > 360)
      {
      //  rot.y -= 360;

        if (rot.y < 182.5f)
        {
          rot.y = 0;
        }


      }








    }
  
  }
  }
}
