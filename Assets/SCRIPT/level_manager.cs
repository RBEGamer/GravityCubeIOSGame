/* Copyright (C) Team Newtons Aepfel- All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Marcel Ochsendorf <marcel.ochsendorf@gmail.com>,  
 */







using UnityEngine;
using System.Collections;

public class level_manager : MonoBehaviour {


  public static int level_orientation;
  public static bool is_level_rotating;
  public static float throws;
  public  static float max_throws = 10;
  public float max_throws_settings;
  public static int earned_stars;
  public static   float percent;
	private bool clicked;
	private Vector2 userTouch;
	public int raycast_range = 100;
	private Vector2 userMouse;
	public GameObject menu_holder;
	public GameObject star_holder_1;
	public GameObject star_holder_2;
	public GameObject star_holder_3;
	public static bool is_level_failed;
	public GameObject menu_button_reload;
	public GameObject menu_button_back;  
	public GameObject menu_button_next;
	public static bool is_in_menu;
  public static bool is_spawning;
	public float percent_first_star = 10.0f;
	public float percent_second_star = 33.0f;
	public float percent_third_star = 80.0f;
  public static bool is_any_cube_moving;
  public static bool enable_gravity_boots = true;
  private float waitTime = 0.1f;
  bool waitTimeStarted = false;
  public Material next_btn_enabled;
  public Material next_btn_disabled;
  public static bool is_tutorial = false;
	public bool isTutorial = false;
  private static int randomNumber;
  static bool playSound = false;
	public static bool is_gra_gun_shooting = false;
	public static bool is_tutorial1;

	public static bool is_won = false;
	// Use this for initialization
	void Start () {
        level_orientation = 0;
    throws = 0;
	  is_level_failed = false;
		is_in_menu = false;    
    is_spawning = true;
    playSound = true;
		is_gra_gun_shooting = false;
		is_won = false;
		is_tutorial1 = false;
        GameObject.Find("goal").GetComponent<Collider>().enabled = true;
	}



 
	
	// Update is called once per frame
	void Update () 
    {
        if(waitTimeStarted)
        {
            this.waitTime -= Time.deltaTime;
            if(waitTimeStarted == true && waitTime <= 0.0f)
            {
                reset_level();
            }
        }
		if (isTutorial == true) 
		{

			is_tutorial = true;
		} else if (isTutorial == false) 
		{
			is_tutorial = false;
		}
		max_throws = max_throws_settings;
    //ESCAPE TO MENU
    if (Input.GetKeyDown(KeyCode.Escape)){is_in_menu = !is_in_menu;}









		//throw_show_start_script.current_earned_stars = earned_stars;


	//	Debug.Log(game_manager.level_unlock_list[game_manager.current_level+1]);
						//menu_button_next.gameObject.SetActive (true);		
			
		if (game_manager.level_unlock_list[game_manager.current_level + 1] && is_in_menu) {
      //menu_button_next.gameObject.SetActive (true);	

      if (is_in_menu && game_manager.current_level < game_manager.max_level-1) {
        menu_button_next.transform.GetComponent<Renderer>().material = next_btn_enabled;
      }
      else
      {
        menu_button_next.transform.GetComponent<Renderer>().material = next_btn_disabled;
      }

    }else{
      //menu_button_next.gameObject.SetActive (false);
      menu_button_next.transform.GetComponent<Renderer>().material = next_btn_disabled;
    }

		if (is_in_menu){menu_holder.gameObject.SetActive(true);} else {menu_holder.gameObject.SetActive (false);}
		if (earned_stars >= 1 && !is_level_failed) {star_holder_1.gameObject.SetActive (true);} else {star_holder_1.gameObject.SetActive (false);}
		if (earned_stars >= 2 && !is_level_failed) {star_holder_2.gameObject.SetActive (true);} else {star_holder_2.gameObject.SetActive (false);}
		if (earned_stars >= 3 && !is_level_failed) {star_holder_3.gameObject.SetActive (true);} else {star_holder_3.gameObject.SetActive (false);}




     percent  = 100-((throws/max_throws)*100);
				if (percent >= percent_third_star) {
						earned_stars = 3;
				} else if (percent >= percent_second_star) {
						earned_stars = 2;
				} else if (percent >= percent_first_star) {
						earned_stars = 1;
				} else {
						earned_stars = 0;
				}


    if (throws > max_throws){level_failed();}


		if (SystemInfo.deviceType == DeviceType.Desktop && is_in_menu)
		{
			//we are on a desktop device, so don't use touch
			if (Input.GetButtonDown("Fire1"))
			{
				
				userMouse = Input.mousePosition;
				Ray userTouchRayM = Camera.main.ScreenPointToRay(userMouse);
				RaycastHit raycast_infoM;
				if (Physics.Raycast(userTouchRayM, out raycast_infoM, raycast_range))
				{
					if (raycast_infoM.collider.name == menu_button_reload.name)
					{
						
                        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play(AudioManager.AudioClipManaged.ui_Reload);
                        waitTimeStarted = true;
					}

					if (raycast_infoM.collider.name == menu_button_back.name)
					{
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play(AudioManager.AudioClipManaged.ui_Click);
						game_manager.goto_menu();	
					}


          if (raycast_infoM.collider.name == menu_button_next.name && game_manager.level_unlock_list[game_manager.current_level + 1] && is_in_menu)
					{
						if(earned_stars > 0)
                        {
                          GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play(AudioManager.AudioClipManaged.ui_Click);
							game_manager.load_next_level();
						}else{
							
						}
						
					}


				}
			}
		}
		//if it isn't a desktop, lets see if our device is a handheld device aka a mobile device
		else if (SystemInfo.deviceType == DeviceType.Handheld && is_in_menu)
		{
			//we are on a mobile device, so lets use touch input
			if (Input.touchCount > 0)
			{
				userTouch = Input.GetTouch(0).position;
				Ray userTouchRay = Camera.main.ScreenPointToRay(userTouch);
				RaycastHit raycast_info;
				if (Physics.Raycast(userTouchRay, out raycast_info, raycast_range))
				{
					if (raycast_info.collider.name == menu_button_reload.name)
					{
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play(AudioManager.AudioClipManaged.ui_Reload);
                        waitTimeStarted = true;
                    }


					if (raycast_info.collider.name == menu_button_back.name)
					{
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play(AudioManager.AudioClipManaged.ui_Click);
						game_manager.goto_menu();	
					}


          if (raycast_info.collider.name == menu_button_next.name && game_manager.level_unlock_list[game_manager.current_level + 1] && is_in_menu)
					{
						if(earned_stars > 0)
                        {
                            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play(AudioManager.AudioClipManaged.ui_Click);
							game_manager.load_next_level();
						}else{

						}

					}


				}
			}
		}




























	}


	public static  void level_complete(){
		is_won = true;
    Debug.Log("Level Complete");
		//game_manager.level_complete ();
		game_manager.unlock_next_level(earned_stars);
		is_in_menu = true;
		is_level_failed = false;
    // save currentLevel
    int lastLevel = PlayerPrefs.GetInt("currentLevel");
    if (lastLevel < game_manager.current_level)
    {
      PlayerPrefs.SetInt("currentLevel", game_manager.current_level);
    }
    //Debug.Log("Setze Level auf : " + game_manager.current_level.ToString());

    // save stars for completed level
    int lastTryStars = PlayerPrefs.GetInt("level_" + game_manager.current_level);

    if (earned_stars > lastTryStars)
    {
      PlayerPrefs.SetInt("level_" + game_manager.current_level, earned_stars);
    }

    PlayerPrefs.Save();
	}	


	public static  void level_failed(){
    Debug.Log("Level  Failed");
    GameObject.Find("goal").GetComponent<Collider>().enabled = false;
		//game_manager.level_complete ();
		//game_manager.unlock_next_level(earned_stars);
		is_in_menu = true;    
		is_level_failed = true;
    if (playSound == true)
    {
      randomNumber = Random.Range(1, 4);
      if (randomNumber == 1)
      {
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play(AudioManager.AudioClipManaged.youLose);
      }
      if (randomNumber == 2)
      {
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play(AudioManager.AudioClipManaged.youLose2);
      }
      if (randomNumber == 3)
      {
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play(AudioManager.AudioClipManaged.youLose3);
      }
      playSound = false;
    }
    

	}	


	public static void reset_level(){
		is_in_menu = false;
		is_level_failed = false;
		//game_manager.load_level(game_manager.current_level);
    Application.LoadLevel(Application.loadedLevel);
	}

	public static void add_throw(){
		throws++;
	}

}
