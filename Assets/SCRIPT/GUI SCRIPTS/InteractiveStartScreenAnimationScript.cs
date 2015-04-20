using UnityEngine;
using System.Collections;

public class InteractiveStartScreenAnimationScript : MonoBehaviour
{
  public GameObject fixedCube;
  public GameObject invertCube;
  public GameObject creditsCube;
  private float animaSpeed;
  private Vector2 userMouse;
  private Vector2 userTouch;
  public int raycast_range = 100;
  private int randomNumber;
  private float time = 0.55f;
  bool animationStarted = false;

  // Use this for initialization
  void Start()
  {

    fixedCube.GetComponent<Animation>().Play("Start");
    invertCube.GetComponent<Animation>().Play("Start");
    creditsCube.GetComponent<Animation>().Play("Idle");
    creditsCube.GetComponent<Collider>().enabled = false;
    
  }

  // Update is called once per frame
  void Update()
  {
      if (animationStarted)
      {
          time -= Time.deltaTime;
          if (animationStarted == true && time <= 0.0f)
          {
              creditsCube.GetComponent<Collider>().enabled = true;
              AudioManager.GetObjectTag().Play(AudioManager.AudioClipManaged.cube_auftreffen);
              animationStarted = false;
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

          if (raycast_infoM.collider.gameObject == invertCube.gameObject)
          {
            Random.Range(1, 4);
            randomNumber = Random.Range(1, 4);
            if (randomNumber == 1)
            {
              invertCube.GetComponent<Animation>().Play("1stJump");
              AudioManager.GetObjectTag().Play(AudioManager.AudioClipManaged.jumpCubeJump);
            
            
            }
            if (randomNumber == 2)
            {
              invertCube.GetComponent<Animation>().Play("2ndJump");
              AudioManager.GetObjectTag().Play(AudioManager.AudioClipManaged.jumpCubeDrehung);
             
            }
            if (randomNumber == 3)
            {
              invertCube.GetComponent<Animation>().Play("3edJump");
              AudioManager.GetObjectTag().Play(AudioManager.AudioClipManaged.jumpCubeHighJump);
						
              
            }
          }
          if (raycast_infoM.collider.gameObject == fixedCube)
          {

            fixedCube.GetComponent<Animation>().Play("Fall");
            AudioManager.GetObjectTag().Play(AudioManager.AudioClipManaged.jumpCubeJump);
            
              creditsCube.GetComponent<Animation>()["fall"].speed = 0.5f;
              creditsCube.GetComponent<Animation>().Play("fall");
              animationStarted = true;
 
                
              
       
            fixedCube.GetComponent<Collider>().enabled = false;
            
            
          }




        }
      }






    }
    //if it isn't a desktop, lets see if our device is a handheld device aka a mobile device
    else if (SystemInfo.deviceType == DeviceType.Handheld)
    {
      //we are on a mobile device, so lets use touch input



      //we are on a mobile device, so lets use touch input
      if (Input.touchCount >= 1 && Input.GetTouch(0).phase == TouchPhase.Began)
      {
        userTouch = Input.GetTouch(0).position;
        Ray userTouchRay = Camera.main.ScreenPointToRay(userTouch);
        RaycastHit raycast_info;
        if (Physics.Raycast(userTouchRay, out raycast_info, raycast_range))
        {
          if (raycast_info.collider.gameObject == invertCube.gameObject)
          {
            Random.Range(1, 4);
            randomNumber = Random.Range(1, 4);
            if (randomNumber == 1)
            {
              invertCube.GetComponent<Animation>().Play("1stJump");
              AudioManager.GetObjectTag().Play(AudioManager.AudioClipManaged.jumpCubeJump);
          
            }
            if (randomNumber == 2)
            {
              invertCube.GetComponent<Animation>().Play("2ndJump");
              AudioManager.GetObjectTag().Play(AudioManager.AudioClipManaged.jumpCubeDrehung);
            
            }
            if (randomNumber == 3)
            {
              invertCube.GetComponent<Animation>().Play("3edJump");
              AudioManager.GetObjectTag().Play(AudioManager.AudioClipManaged.jumpCubeHighJump);
						}
          }
          if (raycast_info.collider.gameObject == fixedCube)
          {

            fixedCube.GetComponent<Animation>().Play("Fall");
            AudioManager.GetObjectTag().Play(AudioManager.AudioClipManaged.jumpCubeJump);

            creditsCube.GetComponent<Animation>()["fall"].speed = 0.5f;
            creditsCube.GetComponent<Animation>().Play("fall");
						

            fixedCube.GetComponent<Collider>().enabled = false;
            
          
          }


        }




      }
    }
  }
}

  