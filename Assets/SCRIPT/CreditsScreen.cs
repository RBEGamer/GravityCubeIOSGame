using UnityEngine;
using System.Collections;

public class CreditsScreen : MonoBehaviour 
{
	public GameObject programmer;
	public GameObject artist;
	public GameObject gameDesign;
	public GameObject sound;
	public GameObject player;
	public float timer;
	bool timerActive;
	Vector3 startPoint;

	// Use this for initialization
	void Start () 
	{
		startPoint = new Vector3(-31f,-15f,0);
		programmer.transform.position = startPoint;
		artist.transform.position = startPoint;
		gameDesign.transform.position = startPoint;
		sound.transform.position = startPoint;
		timerActive = true;
		//Destroy(GameObject.Find("BackgroundMusicHolder"));
		GameObject.Find ("BackgroundMusicHolder").GetComponentInChildren<AudioSource>().enabled = false;
		timer = 0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer += Time.deltaTime;
		if (timerActive == true && timer >= 0 && timer <= 5.5)
		{
			programmer.transform.position += new Vector3(0,0.1f,0);
			programmer.transform.localScale += new Vector3(0.001f,0,0.001f);
			player.GetComponent<Animation>()["idle_1"].speed = 1.6f;
			player.GetComponent<Animation>().wrapMode = WrapMode.Once;
			player.GetComponent<Animation>().Play("idle_1");

		}
		if( timer >=6&& timer<= 8)
		{
			programmer.transform.position += new Vector3(0,0.045f,0);
			programmer.transform.localScale -= new Vector3(0.01f,0,0.01f);
		}
		if (timer >= 6 && timer <= 11) 
		{

			artist.transform.position += new Vector3(0,0.1f,0);
			artist.transform.localScale += new Vector3(0.001f,0,0.001f);
			player.GetComponent<Animation>()["idle_3"].speed = 1.6f;
			player.GetComponent<Animation>().wrapMode = WrapMode.Once;
			player.GetComponent<Animation>().Play("idle_3");
		}
		if(timer>=12&& timer<= 14)
		{
			artist.transform.position -= new Vector3(0.11f,0,0);
			artist.transform.localScale -= new Vector3(0.01f,0,0.01f);
		}
		if (timer >= 11 && timer <= 15.5) 
		{

			sound.transform.position += new Vector3(0,0.1f,0);
			sound.transform.localScale += new Vector3(0.001f,0,0.001f);
			player.GetComponent<Animation>()["idle_4"].speed = 1.6f;
			player.GetComponent<Animation>().wrapMode = WrapMode.Once;
			player.GetComponent<Animation>().Play("idle_4");
		}
		if (timer >= 17 && timer <= 19) 
		{
			sound.transform.position += new Vector3(0.07f,0.005f,0);
			sound.transform.localScale -= new Vector3(0.01f,0,0.01f);
		}
		if (timer >= 18 && timer <= 22.2) 
		{
			gameDesign.transform.position += new Vector3(0,0.1f,0);
			gameDesign.transform.localScale += new Vector3(0.001f,0,0.001f);
			player.GetComponent<Animation>()["idle_1"].speed = 1.6f;
			player.GetComponent<Animation>().wrapMode = WrapMode.Once;
			player.GetComponent<Animation>().Play("idle_1");
		}
		if (timer >= 24 && timer <= 26) 
		{
			gameDesign.transform.position += new Vector3(0,0.003f,0);
			gameDesign.transform.localScale -= new Vector3(0.01f,0,0.01f);
		}
		if (timer >= 26) 
		{
			player.GetComponent<Animation>()["idle_2"].speed = 1.0f;
			player.GetComponent<Animation>().Play("idle_2");
		}

	}
}
