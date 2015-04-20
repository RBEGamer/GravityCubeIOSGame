/* Copyright (C) Team Newtons Aepfel- All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Marcel Ochsendorf <marcel.ochsendorf@gmail.com>,  
 */








using UnityEngine;
using System.Collections;

public class fucking_rotation_shit : MonoBehaviour
{
  private Vector2 userMouse;
  private Vector2 userTouch;
  public int raycast_range = 100;

  // Public Variables
  public float rotateSpeed;    // Speed of the rotation of the cubes
  public int rotateDirection;    // Controls the direction of the rotation, -1(clockWise), 1(counterClockWise)
  private bool block_touch;
  // Private Variables
  public bool shouldRotate; // Tells the cube, that should rotate
  public Quaternion targetRotation;    // Where we are headed.
  public GameObject player_object;


  public GameObject left_screen_dividor;
  public GameObject right_screen_dividor;


  private Touch initToch = new Touch();
  private float dist = 0;

  void Start()
  {
      player_object = GameObject.FindGameObjectWithTag("Player");
    block_touch = false;
    shouldRotate = false;
    player_object.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    player_object.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
    player_object.GetComponent<Rigidbody>().freezeRotation = true;
  }



  void set_orientation(bool clock)
  {

    if (clock)
    {
      switch (level_manager.level_orientation)
      {
        case 0:
          level_manager.level_orientation = 1;
          break;

        case 1:
          level_manager.level_orientation = 2;
          break;

        case 2:
          level_manager.level_orientation = 3;
          break;

        case 3:
          level_manager.level_orientation = 0;
          break;
        default:
          level_manager.level_orientation = 0;
          transform.rotation = Quaternion.identity;
          break;
      }


    }
    else
    {
      switch (level_manager.level_orientation)
      {
        case 0:
          level_manager.level_orientation = 3;
          break;

        case 1:
          level_manager.level_orientation = 0;
          break;

        case 2:
          level_manager.level_orientation = 1;
          break;

        case 3:
          level_manager.level_orientation = 2;
          break;
        default:
          level_manager.level_orientation = 0;
          transform.rotation = Quaternion.identity;
          break;
      }

    }

  }


  void FixedUpdate()
  {



    if (Input.GetKeyDown(KeyCode.Alpha1))
    {
      player_object.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
      player_object.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
      player_object.GetComponent<Rigidbody>().freezeRotation = true;
    }

    if (Input.GetKeyDown(KeyCode.Alpha2))
    {
      player_object.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY;
    }



    if (shouldRotate)
    {
      float angle = Quaternion.Angle(transform.rotation, targetRotation);
      float maxSpin = rotateSpeed * Time.deltaTime;
      if (maxSpin >= angle)
      {
        transform.rotation = targetRotation;
        shouldRotate = false;
        player_object.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        player_object.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
        player_object.GetComponent<Rigidbody>().freezeRotation = true;
      }
      else
      {
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, maxSpin / angle);
      }




    }


    level_manager.is_level_rotating = shouldRotate;





    if (SystemInfo.deviceType == DeviceType.Desktop)
    {
      //we are on a desktop device, so don't use touch
      if (!shouldRotate && Input.GetKeyDown(KeyCode.Q))
      {
        rotate_countclock();
		GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play(AudioManager.AudioClipManaged.levelFrameDrehen);

		if(GameObject.FindGameObjectWithTag("Tutorial")== null)
			return;//.fingerLeftActiv = false;

        if (level_manager.is_tutorial && level_manager.is_spawning == false)
        {
				
	      TutorialFinger.firstInput = true;
			GameObject.FindGameObjectWithTag("Tutorial").GetComponent<TutorialFinger>().fingerLeftActiv = false;
          //if(!GameObject.FindGameObjectWithTag("Tutorial").GetComponent<TutorialFinger>()== null)
			//			return;//.fingerLeftActiv = false;
		  if(TutorialFinger.firstInput == true && TutorialFinger.secondInput == false)
		  {			
          GameObject.FindGameObjectWithTag("Tutorial").GetComponent<TutorialFinger>().fingerRightActiv = true;
		  }
        }
        //GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play(AudioManager.AudioClipManaged.levelFrameDrehen);
      }
      else if (!shouldRotate && Input.GetKeyDown(KeyCode.E))
      {
        rotate_clock();
		GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play(AudioManager.AudioClipManaged.levelFrameDrehen);
				if(GameObject.FindGameObjectWithTag("Tutorial")== null)
					return;
		if (level_manager.is_tutorial&& level_manager.is_spawning == false)
        {
		  
		if(TutorialFinger.firstInput == true)
		{
		  TutorialFinger.secondInput = true;
          GameObject.FindGameObjectWithTag("Tutorial").GetComponent<TutorialFinger>().fingerLeftActiv = false;
		}
          GameObject.FindGameObjectWithTag("Tutorial").GetComponent<TutorialFinger>().fingerRightActiv = false;
		
        }
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play(AudioManager.AudioClipManaged.levelFrameDrehen);
	  }






      //we are on a desktop device, so don't use touch
      if (Input.GetButtonDown("Fire1"))
      {
        userMouse = Input.mousePosition;
        Ray userTouchRayM = Camera.main.ScreenPointToRay(userMouse);
        RaycastHit raycast_infoM;
        if (Physics.Raycast(userTouchRayM, out raycast_infoM, raycast_range))
        {

          


        }
      }






    }
    //if it isn't a desktop, lets see if our device is a handheld device aka a mobile device
    else if (SystemInfo.deviceType == DeviceType.Handheld)
    {
      //we are on a mobile device, so lets use touch input



      //we are on a mobile device, so lets use touch input
      if (Input.touchCount == 1 && !block_touch)
      {
        /*
        userTouch = Input.GetTouch(0).position;
        Ray userTouchRay = Camera.mainCamera.ScreenPointToRay(userTouch);
        RaycastHit raycast_info;
        if (Physics.Raycast(userTouchRay, out raycast_info, raycast_range))
        {
          if (raycast_info.collider.name == control_plane_a.name)
          {
            block_touch = true;
            rotate_clock();

          }
          else if (raycast_info.collider.name == control_plane_b.name)
          {
            block_touch = true;
            rotate_countclock();

          }
        }
      }
      else
      {
        block_touch = false;


}


*/




        foreach (Touch t in Input.touches)
        {
          if (t.phase == TouchPhase.Began)
          {
            initToch = t;
          }
          else if (t.phase == TouchPhase.Moved)
          {
            float deltaX = initToch.position.x - t.position.x;
            float deltaY = initToch.position.y - t.position.y;
            dist = Mathf.Sqrt((deltaX * deltaX) + (deltaY * deltaY));
            bool swipedSideways = Mathf.Abs(deltaX) > Mathf.Abs(deltaY);
            if (dist > 100f)
            {
              //swiped left
              if (swipedSideways && deltaX > 0)
              {
                Debug.Log("left");

                //swiped right
              }
              else if (swipedSideways && deltaX <= 0)
              {
                Debug.Log("right");
                //swiped down
              }
              else if (!swipedSideways && deltaY > 0)
              {
                Debug.Log("down");
                //block_touch = true;

                if (check_rotation_direction_by_swipe_gesture(initToch))
                {
                  rotate_countclock();
									GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play(AudioManager.AudioClipManaged.levelFrameDrehen);
									if(GameObject.FindGameObjectWithTag("Tutorial")== null)
										return;
									if (level_manager.is_tutorial&& level_manager.is_spawning == false)
									{
										TutorialFinger.firstInput = true;
										GameObject.FindGameObjectWithTag("Tutorial").GetComponent<TutorialFinger>().fingerLeftActiv = false;
										if(TutorialFinger.firstInput == true && TutorialFinger.secondInput == false)
										{
											
											GameObject.FindGameObjectWithTag("Tutorial").GetComponent<TutorialFinger>().fingerRightActiv = true;
										}
									}
                }
                else
                {
                  rotate_clock();
									GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play(AudioManager.AudioClipManaged.levelFrameDrehen);
									if(GameObject.FindGameObjectWithTag("Tutorial")== null)
										return;
									if (level_manager.is_tutorial&& level_manager.is_spawning == false)
									{
										
										if(TutorialFinger.firstInput == true)
										{
											TutorialFinger.secondInput = true;
											GameObject.FindGameObjectWithTag("Tutorial").GetComponent<TutorialFinger>().fingerLeftActiv = false;
										}
										GameObject.FindGameObjectWithTag("Tutorial").GetComponent<TutorialFinger>().fingerRightActiv = false;
									}
                  
                }
                
                //swiped up
              }
              else if (!swipedSideways && deltaY <= 0)
              {
                Debug.Log("up");
                //block_touch = true;

                if (!check_rotation_direction_by_swipe_gesture(initToch))
                {
                  rotate_countclock();
									GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play(AudioManager.AudioClipManaged.levelFrameDrehen);
									if(GameObject.FindGameObjectWithTag("Tutorial")== null)
										return;
									if (level_manager.is_tutorial&& level_manager.is_spawning == false)
									{
										TutorialFinger.firstInput = true;
										GameObject.FindGameObjectWithTag("Tutorial").GetComponent<TutorialFinger>().fingerLeftActiv = false;
										if(TutorialFinger.firstInput == true && TutorialFinger.secondInput == false)
										{
											
											GameObject.FindGameObjectWithTag("Tutorial").GetComponent<TutorialFinger>().fingerRightActiv = true;
										}
									}
                }
                else
                {
                  rotate_clock();
									GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play(AudioManager.AudioClipManaged.levelFrameDrehen);
									if(GameObject.FindGameObjectWithTag("Tutorial")== null)
										return;
									if (level_manager.is_tutorial&& level_manager.is_spawning == false)
									{
										
										if(TutorialFinger.firstInput == true)
										{
											TutorialFinger.secondInput = true;
											GameObject.FindGameObjectWithTag("Tutorial").GetComponent<TutorialFinger>().fingerLeftActiv = false;
										}
										GameObject.FindGameObjectWithTag("Tutorial").GetComponent<TutorialFinger>().fingerRightActiv = false;
									}
                }
                GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play(AudioManager.AudioClipManaged.levelFrameDrehen);


              }
              else
              {
                Debug.Log("nothing");
              }


            }
          }
          else if (t.phase == TouchPhase.Ended)
          {
            initToch = new Touch();
            //hier raycasten




          }//ende t.phase



        }//ende foreach









      }

    }
  }//ende void





  bool check_rotation_direction_by_swipe_gesture(Touch start_point)
  {


    Ray userTouchRay = Camera.main.ScreenPointToRay(start_point.position);
    RaycastHit raycast_info;
    if (Physics.Raycast(userTouchRay, out raycast_info, raycast_range))
    {
      if (raycast_info.collider.gameObject == left_screen_dividor.gameObject)
      {
        Debug.Log("left_dividor");
        return true;
      }
      else if (raycast_info.collider.gameObject == right_screen_dividor.gameObject)
      {
        Debug.Log("right_dividor");
        return false;
      }
    }













    return true;
  }



  void rotate_countclock()
  {




		if (!shouldRotate && !level_manager.is_in_menu && !level_manager.is_any_cube_moving && !level_manager.is_spawning && !level_manager.is_gra_gun_shooting)
    {
      set_orientation(false);
      // Since we know the intended rotation is by 90 degrees, we can do this
      targetRotation = Quaternion.LookRotation(transform.forward, transform.right * -rotateDirection);
      shouldRotate = true;     // Start rotating the tube
      player_object.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY;

      level_manager.add_throw();

    //  level_manager.is_level_rotating = shouldRotate;
    }

  }

  void rotate_clock()
  {


		if (!shouldRotate & !level_manager.is_in_menu && !level_manager.is_any_cube_moving && !level_manager.is_spawning && !level_manager.is_gra_gun_shooting)
    {
      set_orientation(true);
      // Since we know the intended rotation is by 90 degrees, we can do this
      targetRotation = Quaternion.LookRotation(transform.forward, transform.right * rotateDirection);
      shouldRotate = true;     // Start rotating the tube
      player_object.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY;

      level_manager.add_throw();

   //   level_manager.is_level_rotating = shouldRotate;
    }




  }
}




