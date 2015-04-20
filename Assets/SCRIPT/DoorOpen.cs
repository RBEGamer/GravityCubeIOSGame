using UnityEngine;
using System.Collections;

public class DoorOpen : MonoBehaviour 
{
    public enum ButtonType
    {
        Plate, Lever, Time
    }

    bool doorstate = false;
    public float doorTimeOpen = 5;
    float timeLeft;
    public ButtonType buttonType;
    public GameObject doorToToggle;
    Door_Animation door;
    public string tag_gravity_gun_bullet;
	public AnimationClip timerAnim;
	private Animator animator;
	float speed = 1.0f;
	public GameObject timer;
	// Use this for initialization
	void Start () 
    {
        timeLeft = doorTimeOpen;
        door = doorToToggle.GetComponent<Door_Animation>();
	if (timer == null || timerAnim == null) 
		{
			Debug.LogError("No Timer");
			return;
		}
		this.animator = GameObject.Find ("Timer").GetComponent<Animator>();
		/*if (doorTimeOpen != 1) {
				
						int j = 0;
					    for (float i = doorTimeOpen - 1.0f; i > 0.0f; i = i - 1.0f) {

								j++;
								if (j > 10) {
										speed -= 0.01f;
								} else {
										speed -= 0.1f;
								}
						}
			}*/

		this.animator.speed = 1f / doorTimeOpen;
		timer.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () 
    {

        switch (buttonType)
        {
            case ButtonType.Lever:

                break;
            case ButtonType.Plate:

                break;
            case ButtonType.Time:
                if (doorstate)
                {
                    timeLeft -= Time.deltaTime;
				timer.SetActive(true);
                    //Debug.Log(timeLeft);
                    if (timeLeft <= 0)
					{
						doorstate = false;
                        if (door.doorOpen)
                        door.SetDoorState(false);
                        timeLeft = doorTimeOpen;
					timer.SetActive(false);
					    
                    }
                }
                break;
        }
	}
    void OnTriggerEnter(Collider other)
    {
      if (other.gameObject.tag != tag_gravity_gun_bullet)
      {
        switch (buttonType)
        {
          case ButtonType.Lever:
            if (!doorstate)
            {
              
              doorstate = true;
              if (!door.doorOpen)
                door.SetDoorState(true);
            }
            //else
            //{
            //  doorstate = false;
            //  if (door.doorOpen)
            //    door.SetDoorState(false);
            //}
            break;
          case ButtonType.Time:
            if (!doorstate)
            {
              doorstate = true;
              if (!door.doorOpen)
                door.SetDoorState(true);
            }
            break;
          default:
            break;
        }
      }
    }

    void OnTriggerExit(Collider collisionInfo)
    {
      
        if (buttonType == ButtonType.Plate)
        {
          doorstate = false;
          if (door.doorOpen)
            door.SetDoorState(false);
        }
      
    }

    void OnTriggerStay(Collider collisionInfo)
    {

      if (collisionInfo.gameObject.tag != tag_gravity_gun_bullet)
      {
        if (buttonType == ButtonType.Plate)
        {
          //foreach (ContactPoint contact in collisionInfo.contacts)
          //{
          if (!doorstate)
          {
            doorstate = true;
            if (!door.doorOpen)
              door.SetDoorState(true);
          }
        }

      }
    }


}
