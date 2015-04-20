using UnityEngine;
using System.Collections;

public class TutorialLevel1 : MonoBehaviour 
{
	public GameObject tutorialFingerRight;
	public GameObject tutorialFingerLeft;
	public GameObject tutorialD;
	public GameObject tutorialA;
	public  static bool firstInput = false;
	public  static bool secondInput = false;
	public  bool fingerRightActiv;
	public  bool fingerLeftActiv;
	public bool scale_up;
	public bool scale_up_2;
	bool scaleStarted = false;
	public float minScale;
	public float maxScale;
	public float scale_speed;

	// Use this for initialization
	void Start () 
	{
		level_manager.is_tutorial = true;
		firstInput = false;
		secondInput = false;
		scale_up = true;
		tutorialA.transform.localScale -= new Vector3(minScale,minScale,minScale);
		level_manager.is_tutorial1 = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		GameObject.Find ("level_manager").GetComponent<level_manager> ().isTutorial = true;
		level_manager.is_tutorial1 = true;
		if (SystemInfo.deviceType == DeviceType.Desktop) 
		{
			
			tutorialFingerLeft.SetActive (false);
			tutorialFingerRight.SetActive (false);
			if(Input.GetKeyDown(KeyCode.D) && level_manager.is_spawning == false)
			{

				firstInput = true;
				if(firstInput == true && secondInput == false)
				{
					fingerLeftActiv = true;
				}
				fingerRightActiv = false;
			}
			if(Input.GetKeyDown(KeyCode.A) && level_manager.is_spawning == false)
			{
				secondInput = true;
				fingerLeftActiv = false;
			}
			if (fingerLeftActiv == true) 
			{
				tutorialA.SetActive (true);
			}
			if (fingerLeftActiv == false) 
			{
				tutorialA.SetActive (false);
			}
			if (fingerRightActiv == true) 
			{
				tutorialD.SetActive (true);
			}
			if (fingerRightActiv == false) 
			{
				tutorialD.SetActive (false);
			}
			if(firstInput == false)
			{
				if(scale_up){
					tutorialD.transform.localScale += new Vector3(scale_speed * Time.deltaTime,scale_speed *Time.deltaTime,scale_speed * Time.deltaTime);
					if(tutorialD.transform.localScale.x >= maxScale){
						scale_up = false;
					}
				}else{
					tutorialD.transform.localScale -= new Vector3(scale_speed * Time.deltaTime,scale_speed *Time.deltaTime,scale_speed * Time.deltaTime);
					if(tutorialD.transform.localScale.x <= minScale){
						scale_up = true;
					}
				}
			}
			if(secondInput == false)
			{
				if(scale_up_2){
					tutorialA.transform.localScale += new Vector3(scale_speed * Time.deltaTime,scale_speed *Time.deltaTime,scale_speed * Time.deltaTime);
					if(tutorialA.transform.localScale.x >= maxScale){
						scale_up_2 = false;
					}
				}else{
					tutorialA.transform.localScale -= new Vector3(scale_speed * Time.deltaTime,scale_speed *Time.deltaTime,scale_speed * Time.deltaTime);
					if(tutorialA.transform.localScale.x <= minScale){
						scale_up_2 = true;
					}
				}
			}



		}
		if (SystemInfo.deviceType == DeviceType.Handheld) 
		{
			tutorialA.SetActive(false);
			tutorialD.SetActive(false);

			if (fingerLeftActiv == true) 
			{
				tutorialFingerLeft.SetActive (true);
			}
			if (fingerLeftActiv == false) 
			{
				tutorialFingerLeft.SetActive (false);
			}
			if (fingerRightActiv == true) 
			{
				tutorialFingerRight.SetActive (true);
			}
			if (fingerRightActiv == false) 
			{
				tutorialFingerRight.SetActive (false);
			}
			if(firstInput == false)
			{
				if(scale_up){
					tutorialFingerRight.transform.localScale += new Vector3(scale_speed * Time.deltaTime,scale_speed *Time.deltaTime,scale_speed * Time.deltaTime);
					if(tutorialFingerRight.transform.localScale.x >= maxScale){
						scale_up = false;
					}
				}else{
					tutorialFingerRight.transform.localScale -= new Vector3(scale_speed * Time.deltaTime,scale_speed *Time.deltaTime,scale_speed * Time.deltaTime);
					if(tutorialFingerRight.transform.localScale.x <= minScale){
						scale_up = true;
					}
				}
			}
			if(secondInput == false)
			{
				if(scale_up_2){
					tutorialFingerLeft.transform.localScale += new Vector3(scale_speed * Time.deltaTime,scale_speed *Time.deltaTime,scale_speed * Time.deltaTime);
					if(tutorialFingerLeft.transform.localScale.x >= maxScale){
						scale_up_2 = false;
					}
				}else{
					tutorialFingerLeft.transform.localScale -= new Vector3(scale_speed * Time.deltaTime,scale_speed *Time.deltaTime,scale_speed * Time.deltaTime);
					if(tutorialFingerLeft.transform.localScale.x <= minScale){
						scale_up_2 = true;
					}
				}
			}
		}
	}
}
