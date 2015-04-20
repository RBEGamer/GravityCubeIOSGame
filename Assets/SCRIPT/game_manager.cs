 /* Copyright (C) Team Newtons Aepfel- All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Marcel Ochsendorf <marcel.ochsendorf@gmail.com>,  
 */







using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class game_manager : MonoBehaviour {

 


	public static int current_score;
	public static int high_score;
	public static int current_level = 0;
	public static int unlocked_level;
	public const  int max_level = 48;
	private bool block_touch;
	public const int menu_level_count = 4;
  public static bool ios_buttons = true;
  public static bool disable_ios_buttons_on_pc = true;
  public static bool[] level_unlock_list = new bool[max_level + menu_level_count];
  public static int[] level_star_list = new int[max_level + menu_level_count];
  public static bool activate_z_axis_correction = true;
  public static bool is_mobile_device;




 


  void Awake() 
  {
    DontDestroyOnLoad(this);





    if (SystemInfo.deviceType == DeviceType.Desktop)
    {
      is_mobile_device = false;
    }
    else if (SystemInfo.deviceType == DeviceType.Handheld)
    {
      is_mobile_device = true;
    }
  



  }


     void Start()
    {
		//damit das script weiterhin ausgeführ wird wird das gameobject <game_amanger_script> hier nicht zerstört
		
    //high_score = 0;
		//level_scenes = new List<int>();
		//current_level = 0;

		//for (int i = 0; i < level_unlock_list.Length; i++) {
		//	game_manager.level_unlock_list[i] = false;
		//		}
    /*
    int enable_to = 0;
    for (int i = 0; i < enable_to; i++)
    {
      level_unlock_list[i] = true;
      level_star_list[i] =3 ;      
    }
     * */
        InitializeSaveData();

  }
    public static void InitializeSaveData()
    {
        // set first level
        level_unlock_list[0] = true;
        level_star_list[0] = PlayerPrefs.GetInt("level_0");

        // unlock level based on PlayerPrefs
        int lastLevel = PlayerPrefs.GetInt("currentLevel", current_level);



        // set all other levels; starting with second level
        for (int i = 1; i <= lastLevel; i++)
        {
            game_manager.level_unlock_list[i] = true;

            if (i == lastLevel)
            {
                game_manager.level_unlock_list[i + 1] = true;
            }

            level_star_list[i] = PlayerPrefs.GetInt("level_" + i);
        }

        // check if level 0 is completed -> if a level is completed he owns at least one star
        if (PlayerPrefs.GetInt("level_0") > 0)
        {
            // grant access to second levels
            game_manager.level_unlock_list[1] = true;
        }


        Debug.Log("Game_Manager.cs Start() currentLevel: " + PlayerPrefs.GetInt("currentLevel", current_level));
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.U))
        //{
        //    PlayerPrefs.DeleteAll();
        //    current_level = 0;
        //    for (int i=0; i < game_manager.level_unlock_list.Length; i++)
        //    {
        //        Debug.Log (i);
        //        game_manager.level_unlock_list[i] = false;
        //        level_star_list[i] = 0;
        //    }
        //    Start();
        //}

    }


  



		

		



	public static void unlock_next_level(int stars){
		int tmp = current_level + 1;

    if (level_star_list[current_level] < stars)
    {
      level_star_list[current_level] = stars;
    }
    else
    {
//level_star_list[current_level] = stars;
    }


		Debug.Log("Stars:" + stars + " in level:" + current_level);
		level_unlock_list [tmp] = true;			
	}


	public static void load_next_level(){
		int tmp = current_level + 1;
    if (tmp+1 < max_level)
    {
			current_level++;
			load_level(current_level);		
		} else {
      goto_credits();
		}
	}



	public static void load_level(int level_id){
		if (level_unlock_list[level_id] == true) {


      if (Application.CanStreamedLevelBeLoaded("level_" + (level_id + 1)))
      {
        Application.LoadLevel("level_" + (level_id + 1));
      }
      else
      {
        goto_menu();
      }
            


      current_level = level_id;
      Debug.Log("Set current level to :" + level_id); 
		}
	}




	public static void goto_menu(){
		Application.LoadLevel("level_selection");	
	}


  public static void goto_main_menu()
  {
    Application.LoadLevel("main_menu");	
  }


  public static void goto_credits()
  {
      Application.LoadLevel("credits");
  }


}
