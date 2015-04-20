using UnityEngine;
using System.Collections;

public class ResetButton : MonoBehaviour 
{
    private bool clicked;
    private Vector2 userTouch;
    public int raycast_range = 100;
    private Vector2 userMouse;
    public GameObject sureQuestion;
    private int clickCount = 0;
	// Use this for initialization
	void Start () 
    {
        clickCount = 0;
	}
	
	// Update is called once per frame
	void Update () 
    {
       if(clickCount == 2)
       {
           ResetSave();
           clickCount = 0;
       }
        if(clickCount != 1)
        {
            sureQuestion.SetActive(false);
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
                        clickCount = clickCount + 1;
                        
                        if(clickCount == 1)
                        {
                            sureQuestion.SetActive(true);
                        }
                      

                        
                 
                    }
                    else
                    {
                      clickCount = 0;
                    }
                  



                }
            }
        }
        //if it isn't a desktop, lets see if our device is a handheld device aka a mobile device
        else if (SystemInfo.deviceType == DeviceType.Handheld)
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
                        clickCount = clickCount + 1;
						if(clickCount == 1)
						{
							sureQuestion.SetActive(true);
						}
					}
					else
					{
						clickCount = 0;
					}




                }
            }
        }
	}
    public void ResetSave()
    {
        PlayerPrefs.DeleteAll();
        game_manager.current_level = 0;
        for (int i = 0; i < game_manager.level_unlock_list.Length; i++)
        {
    
            game_manager.level_unlock_list[i] = false;
            game_manager.level_star_list[i] = 0;
        }
        game_manager.InitializeSaveData();
    }
}
