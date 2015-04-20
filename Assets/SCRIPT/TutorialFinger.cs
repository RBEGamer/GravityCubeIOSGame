using UnityEngine;
using System.Collections;

public class TutorialFinger : MonoBehaviour 
{
    public GameObject tutorialFingerRight;
    public GameObject tutorialFingerLeft;
	public GameObject tutorialE;
	public GameObject tutorialQ;
    public  static bool firstInput = false;
    public  static bool secondInput = false;
    public bool fingerRightActiv;
    public bool fingerLeftActiv;
    Vector3 start_Right;
    Vector3 start_Left;
    Vector3 waitPos;
    bool waitPosTrue = false;
    private float waitTime = 1.0f;
    bool waitTimeStarted = false;
	public bool scale_up;
	public bool scale_up_2;
	bool scaleStarted = false;
	public float minScale;
	public float maxScale;
	public float scale_speed;
     //Use this for initialization
	void Start () 
    {
        start_Right = tutorialFingerRight.transform.position;
        start_Left = tutorialFingerLeft.transform.position;
        waitPos = new Vector3(100, 100, 100);
        level_manager.is_tutorial = true;
		firstInput = false;
		secondInput = false;
		level_manager.is_tutorial1 = false;
		scale_up = true;
		tutorialQ.transform.localScale -= new Vector3(minScale,minScale,minScale);
	}
    
	
     //Update is called once per frame
	void Update ()
    {
		GameObject.Find ("level_manager").GetComponent<level_manager> ().isTutorial = true;
		if (SystemInfo.deviceType == DeviceType.Desktop) 
		{

			tutorialFingerLeft.SetActive(false);
			tutorialFingerRight.SetActive(false);
			if (fingerLeftActiv == true) {
				tutorialQ.SetActive (true);
			}
			if (fingerLeftActiv == false) {
				tutorialQ.SetActive (false);
			}
			if (fingerRightActiv == true) {
				tutorialE.SetActive (true);
			}
			if (fingerRightActiv == false) {
				tutorialE.SetActive (false);
			}

      
			

			/*
			if (firstInput == false && scale_up == false && tutorialQ.transform.localScale.x >= 3.5f) {
				tutorialQ.transform.localScale -= new Vector3(0.1f,0.1f,0.1f);

			}
			if (secondInput == false) {
				tutorialE.transform.localScale -= new Vector3 (0.1f,0.1f,0.1f);
			}
			if (scale_up == true && tutorialQ.transform.localScale.x <= 1.5f) {
				tutorialQ.transform.localScale += new Vector3(0.1f,0.1f,0.1f);

			}
		*/
				

			if(firstInput == false)
			{
			if(scale_up){
				tutorialQ.transform.localScale += new Vector3(scale_speed * Time.deltaTime,scale_speed *Time.deltaTime,scale_speed * Time.deltaTime);
				if(tutorialQ.transform.localScale.x >= maxScale){
					scale_up = false;
				}
			}else{
				tutorialQ.transform.localScale -= new Vector3(scale_speed * Time.deltaTime,scale_speed *Time.deltaTime,scale_speed * Time.deltaTime);
				if(tutorialQ.transform.localScale.x <= minScale){
					scale_up = true;
				}
			}
			}
			if(secondInput == false)
			{
				if(scale_up_2){
					tutorialE.transform.localScale += new Vector3(scale_speed * Time.deltaTime,scale_speed *Time.deltaTime,scale_speed * Time.deltaTime);
					if(tutorialE.transform.localScale.x >= maxScale){
						scale_up_2 = false;
					}
				}else{
					tutorialE.transform.localScale -= new Vector3(scale_speed * Time.deltaTime,scale_speed *Time.deltaTime,scale_speed * Time.deltaTime);
					if(tutorialE.transform.localScale.x <= minScale){
						scale_up_2 = true;
					}
				}
			}








			}

		if (SystemInfo.deviceType == DeviceType.Handheld) 
		{
			tutorialE.SetActive(false);
			tutorialQ.SetActive(false);
						if (waitTimeStarted) {
								this.waitTime -= Time.deltaTime;
						}
						if (fingerLeftActiv == true) {
								tutorialFingerLeft.SetActive (true);
						}
						if (fingerLeftActiv == false) {
								tutorialFingerLeft.SetActive (false);
						}
						if (fingerRightActiv == true) {
								tutorialFingerRight.SetActive (true);
						}
						if (fingerRightActiv == false) {
								tutorialFingerRight.SetActive (false);
						}
						if (firstInput == false) {
								tutorialFingerLeft.transform.position -= new Vector3 (0, 0.15f, 0);
						}
						if (secondInput == false) {
								tutorialFingerRight.transform.position -= new Vector3 (0, 0.15f, 0);
						}

						if (tutorialFingerRight.transform.position.y <= start_Left.y - 8) {
								waitPosTrue = true;
						}
						if (waitPosTrue == true) {
								tutorialFingerRight.transform.position = waitPos;
								tutorialFingerLeft.transform.position = waitPos;

								if (waitPosTrue == true) {

               
										waitTimeStarted = true;
										if (waitTimeStarted == true && waitTime <= 0.0f) {
                 
												tutorialFingerRight.transform.position = start_Right;
												tutorialFingerLeft.transform.position = start_Left;
												waitTime = 1.0f;
												waitTimeStarted = false;
												waitPosTrue = false;


										}
								}

						}
				}
	
	}

}