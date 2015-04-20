/* Copyright (C) Team Newtons Aepfel- All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Marcel Ochsendorf <marcel.ochsendorf@gmail.com>,  
 */







using UnityEngine;
using System.Collections;

public class star_enable_menu : MonoBehaviour {

	public GameObject star1;
	public GameObject star2;
	public GameObject star3;
	public  int level_nr;

  public GameObject level_pack_manager_obj;
  private level_pack_manager level_manager_script;
  public int button_pos_nr;

  public Material unlocked_bg;
  public Material locked_bg;

  public GameObject bg_plane;

  public GameObject number_tens;
  public GameObject number_ones;



  public string info = "HIER NUMBERS MATERIALS";
  public Material numbers_leer;
  public Material number_0;
  public Material number_1;
  public Material number_2;
  public Material number_3;
  public Material number_4;
  public Material number_5;
  public Material number_6;
  public Material number_7;
  public Material number_8;
  public Material number_9;

  int level_nr_e = 0, level_nr_z = 0;


  private bool clicked;
  private Vector2 userTouch;
  public int raycast_range = 100;
  private Vector2 userMouse;

  private float waitTime = 0.05f;
  bool waitTimeStarted = false;



	// Use this for initialization
	void Start () {

    level_manager_script = level_pack_manager_obj.GetComponent<level_pack_manager>();

    level_nr = (level_manager_script.pack_nr * level_manager_script.button_per_pack) + button_pos_nr;

    if (button_pos_nr < 1)
    {
      button_pos_nr = 1;
    }



    

      this.name = "level_select_btn_" + level_nr;
    //number_0.mainTexture = Resources.Load("Assets/Resources/numbers_black/Sprite_Sheet_Numbers_0") as Texture;

   // number_0.mainTexture = Resources.Load<Texture>("Assets/Resources/numbers_black/Sprite_Sheet_Numbers_0");


      if (level_nr-1  > game_manager.max_level-1)
      {
       // Destroy(this);
     // this.gameObject.SetActive(false);
      }




	}
	
	// Update is called once per frame
	void Update () 
    {
        if (waitTimeStarted)
        {
            this.waitTime -= Time.deltaTime;
            if (waitTimeStarted == true && waitTime <= 0.0f)
            {
                game_manager.load_level(level_nr - 1); 
            }
        }

    if (SystemInfo.deviceType == DeviceType.Desktop)
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
    else if (SystemInfo.deviceType == DeviceType.Handheld)
    {
      //we are on a mobile device, so lets use touch input
      if (Input.touchCount > 0)
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


   



    bool tmp1 = game_manager.level_unlock_list[level_nr - 1];
      if (tmp1 == true)
      {//level unlocked
        bg_plane.transform.GetComponent<Renderer>().material = unlocked_bg;
        number_tens.gameObject.SetActive(true);
        number_ones.gameObject.SetActive(true);

     
      
          level_nr_e = level_nr % 10;
          level_nr_z = (level_nr - level_nr_e) / 10;
        

          switch (level_nr_e)
          {
            case 0: number_ones.transform.GetComponent<Renderer>().material = number_0; break;
            case 1: number_ones.transform.GetComponent<Renderer>().material = number_1; break;
            case 2: number_ones.transform.GetComponent<Renderer>().material = number_2; break;
            case 3: number_ones.transform.GetComponent<Renderer>().material = number_3; break;
            case 4: number_ones.transform.GetComponent<Renderer>().material = number_4; break;
            case 5: number_ones.transform.GetComponent<Renderer>().material = number_5; break;
            case 6: number_ones.transform.GetComponent<Renderer>().material = number_6; break;
            case 7: number_ones.transform.GetComponent<Renderer>().material = number_7; break;
            case 8: number_ones.transform.GetComponent<Renderer>().material = number_8; break;
			case 9: number_ones.transform.GetComponent<Renderer>().material = number_9; break;
            default:
				number_ones.transform.GetComponent<Renderer>().material = numbers_leer;



              break;
          }

          switch (level_nr_z)
          {
            case 0: number_tens.transform.GetComponent<Renderer>().material = number_0; break;
            case 1: number_tens.transform.GetComponent<Renderer>().material = number_1; break;
            case 2: number_tens.transform.GetComponent<Renderer>().material = number_2; break;
            case 3: number_tens.transform.GetComponent<Renderer>().material = number_3; break;
            case 4: number_tens.transform.GetComponent<Renderer>().material = number_4; break;
            case 5: number_tens.transform.GetComponent<Renderer>().material = number_5; break;
            case 6: number_tens.transform.GetComponent<Renderer>().material = number_6; break;
            case 7: number_tens.transform.GetComponent<Renderer>().material = number_7; break;
            case 8: number_tens.transform.GetComponent<Renderer>().material = number_8; break;
			case 9: number_tens.transform.GetComponent<Renderer>().material = number_9; break;
            default:
				number_ones.transform.GetComponent<Renderer>().material = numbers_leer;
              break;
          }
   

        


      }
      else
      {
        //level_plane[i].transform.renderer.material = text_disabled_path[i];
        bg_plane.transform.GetComponent<Renderer>().material = locked_bg;
        number_tens.gameObject.SetActive(false);
        number_ones.gameObject.SetActive(false);
      }







     
   


        







		if (game_manager.level_star_list[level_nr-1] > 0) {
						star3.gameObject.SetActive (true);	
				} else {
	            star3.gameObject.SetActive (false);	
		}



		if (game_manager.level_star_list[level_nr-1] > 1) {
			star2.gameObject.SetActive (true);	
		} else {
			star2.gameObject.SetActive (false);	
		}




		if (game_manager.level_star_list[level_nr-1] > 2) {
			star1.gameObject.SetActive (true);	
		} else {
			star1.gameObject.SetActive (false);	
		}





























 

	}
}
