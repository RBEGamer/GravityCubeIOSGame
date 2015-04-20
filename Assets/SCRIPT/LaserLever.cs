



using UnityEngine;
using System.Collections;
using System.Collections.Generic; //required for list

public class LaserLever : MonoBehaviour 
{
    public List<GameObject> lasers;

  public enum ButtonType{disable, Plate, Time}
  
  public ButtonType buttonType;
  float timeLeft;
  public float laserInactiveTime = 5;
  bool laserState = false;
  public GameObject button_prefab;
  public GameObject laser;
  //public GameObject _beam;
  //public GameObject hitMarker;
  //public GameObject laser_pivot;
  public string tag_gravity_gun_bullet;
	public AnimationClip timerAnim;
	private Animator animator;
	float speed = 1.0f;
	public GameObject timer;
  
  // Use this for initialization
  void Start()
  {
    timeLeft = laserInactiveTime;
    laser.GetComponent<LaserSound>().playSounds();
		if (timer == null || timerAnim == null) 
		{

			return;
		}  
		Debug.Log ("deineMudda");
		this.animator = timer.GetComponent<Animator> ();

		this.animator.speed = 1f / laserInactiveTime;
		timer.SetActive (false);
				
  }

  // Update is called once per frame
  void Update()
  {
    
    switch (buttonType)
    {
      case ButtonType.disable:

        break;
      case ButtonType.Plate:

        break;
      case ButtonType.Time:
        if (laserState)
        {
          timeLeft -= Time.deltaTime;
				timer.SetActive(true);
          if (timeLeft < 0)
          {
            laserState = false;
            //Camera.main.GetComponent<SoundManager>().laserInScene = true;
            laser.GetComponent<LaserSound>().isLaserOn = true;
            laser.GetComponent<LaserSound>().playSounds();
            enableLasers();
					timer.SetActive(false);
              //_beam.SetActive(true);
              //hitMarker.SetActive(true);
              //laser_pivot.SetActive(true);
            timeLeft = laserInactiveTime;
          }
        }
        break;
    }
  }
  void OnTriggerEnter(Collider other)
  {
    GetComponent<Animation>().Play("Activate");
    //Camera.main.GetComponent<SoundManager>().PlaySounds(0);
    GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play(AudioManager.AudioClipManaged.schalter);
    if (other.tag != tag_gravity_gun_bullet) {
      button_prefab.GetComponent<Animation>().Play("Activate");
    switch (buttonType)
    {
      case ButtonType.disable:
        if (!laserState)
        {
          laserState = true;
          //Camera.main.GetComponent<SoundManager>().laserInScene = false;
          laser.GetComponent<LaserSound>().isLaserOn = false; 
          laser.GetComponent<LaserSound>().playSounds();
          disableLasers();
        }
        
        break;
      case ButtonType.Plate:
        if (buttonType == ButtonType.Plate)
        {
          laserState = false;
          //Camera.main.GetComponent<SoundManager>().laserInScene = false;
          laser.GetComponent<LaserSound>().isLaserOn = false;
          laser.GetComponent<LaserSound>().playSounds();
          disableLasers();
          //_beam.SetActive(false);
          //hitMarker.SetActive(false);
          //laser_pivot.SetActive(false);  
        }
        break;
      case ButtonType.Time:
        if (laserState == false)
        {
         
          laserState = true;
          //Camera.main.GetComponent<SoundManager>().laserInScene = false;
          laser.GetComponent<LaserSound>().isLaserOn = false;
          laser.GetComponent<LaserSound>().playSounds();
          disableLasers();
            //_beam.SetActive(false);
            //hitMarker.SetActive(false);
            //laser_pivot.SetActive(false); 
        }
        break;
      default:
        break;
    }//ENDE SWITCH
    }//ende tag
  }
  
  void OnTriggerExit(Collider colliderInfo)
  {
    GetComponent<Animation>().Play("Deactivate");
    if (colliderInfo.tag != tag_gravity_gun_bullet)
    {
      button_prefab.GetComponent<Animation>().Play("Deactivate");
      if (buttonType == ButtonType.Plate)
      {
        laserState = true;
        //Camera.main.GetComponent<SoundManager>().laserInScene = true;
        laser.GetComponent<LaserSound>().isLaserOn = true;
        laser.GetComponent<LaserSound>().playSounds();
        enableLasers();
        //_beam.SetActive(true);
        //hitMarker.SetActive(true);
        //laser_pivot.SetActive(true);
      }
    }
  }

  void OnTriggerStay(Collider colliderInfo)
  {
    //button_prefab.animation.Play("Idle");
    //if (buttonType == ButtonType.Plate)
    //{
    //    laserState = false;
    //    //Camera.main.GetComponent<SoundManager>().laserInScene = false;
    //    laser.GetComponent<LaserSound>().isLaserOn = false;
    //    laser.GetComponent<LaserSound>().playSounds();
    //    disableLasers();
    //      //_beam.SetActive(false);
    //      //hitMarker.SetActive(false);
    //      //laser_pivot.SetActive(false);  
    //}
  }
    void disableLasers()
  {
      foreach (GameObject laser in lasers)
      {
       
          laser.SetActive(false);
      }
  }
    void enableLasers()
    {
        foreach(GameObject laser in lasers)
        {
          
            laser.SetActive(true);
        }
    }
}
