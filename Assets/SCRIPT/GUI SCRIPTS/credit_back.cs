using UnityEngine;
using System.Collections;

public class credit_back : MonoBehaviour {

    private bool clicked;
    private Vector2 userTouch;
    public int raycast_range = 100;
    private Vector2 userMouse;


    // Use this for initialization
    void Start()
    {
        AudioManager.SetGameObjectTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {





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
                    Debug.Log("!");
                    if (raycast_infoM.collider.name == this.name)
                    {
                        game_manager.goto_main_menu();
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
                        game_manager.goto_main_menu();
                    }

                }
            }
        }





    }
}
